using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

[System.Serializable]
public class LeaderboardScoreData
{
    public string player;
    public string time;
    public string id;
}

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;

    private List<LeaderboardScoreData> _topTen = new();
    public List<LeaderboardScoreData> TopTen { get {return _topTen; } }

    public UnityEvent<List<LeaderboardScoreData>> TopTenUpdated = new();

    public float LowestTop10Time { 
        get
        {
            if (_topTen.Count <= 0) return 0;

            return float.Parse(_topTen.Last().time);
        }
    }

    public string LowestTop10Id
    {
        get
        {
            if (_topTen.Count <= 0) return null;

            return _topTen.Last().id;
        }
    }

    public int TopTenLength
    {
        get
        {
            return _topTen.Count;
        }
    }

    private string databaseUrl = "https://pbj-road-trip-default-rtdb.firebaseio.com";
    private string table = "leaderboard";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine("GetTop10");
    }

    public IEnumerator SubmitScore(string playerName, float time)
    {
        if (time < LowestTop10Time && _topTen.Count >= 10) yield break;

        LeaderboardScoreData data = new(){ player = playerName, time = time.ToString() };
        string json = JsonUtility.ToJson(data);

        string path = databaseUrl+"/"+table+".json";
        UnityWebRequest postRequest = new UnityWebRequest(path, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        postRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        postRequest.downloadHandler = new DownloadHandlerBuffer();
        postRequest.SetRequestHeader("Content-Type", "application/json");

        yield return postRequest.SendWebRequest();

        if (postRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score submitted!");

            if (_topTen.Count >= 10)
            {
                StartCoroutine("DeleteScore", LowestTop10Id); 
            }
        } else
        {
            Debug.LogError("Submit failed: " + postRequest.error);
        }            
    }

    public IEnumerator DeleteScore(string id)
    {
        string path = databaseUrl+"/" + table + "/" + id +".json";
        UnityWebRequest deleteRequest = UnityWebRequest.Delete(path);

        yield return deleteRequest.SendWebRequest();

        if (deleteRequest.result == UnityWebRequest.Result.Success)
            Debug.Log("Score deleted!");
        else
            Debug.LogError("Failed to delete: " + deleteRequest.error);
    }

    public IEnumerator GetTop10()
    {
        string path = databaseUrl+"/"+table+".json";
        UnityWebRequest req = UnityWebRequest.Get(path);

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            string json = req.downloadHandler.text;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, LeaderboardScoreData>>(json);
            List<LeaderboardScoreData> top10 = new();
            
            if (dict == null) yield break;

            foreach (var entry in dict)
            {
                top10.Add(new(){player = entry.Value.player, time = entry.Value.time, id = entry.Key});
            }
            
            top10.Sort((a, b) => b.time.CompareTo(a.time));

            _topTen = top10;
            TopTenUpdated.Invoke(_topTen);

            Debug.Log(_topTen.First().player);
        } else if (req.error != null)
        {
            Debug.Log(req.error);
        }
    }
}
