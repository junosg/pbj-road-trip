using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class LeaderboardScoreData
{
    public string player;
    public string time;
}

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;

    private LeaderboardScoreData[] _topTen;
    private string databaseUrl = "https://pbj-road-trip-default-rtdb.firebaseio.com/leaderboard.json";

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

    public IEnumerator SubmitScore(string playerName, string time)
    {
        LeaderboardScoreData data = new LeaderboardScoreData { player = playerName, time = time };
        string json = JsonUtility.ToJson(data);

        UnityWebRequest req = new UnityWebRequest(databaseUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
            Debug.Log("Score submitted!");
        else
            Debug.LogError("Submit failed: " + req.error);
    }

    public IEnumerator GetTop10(System.Action<string> callback)
    {
        string url = databaseUrl + "?orderBy=\"score\"&limitToLast=10";

        UnityWebRequest req = UnityWebRequest.Get(url);

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            string json = req.downloadHandler.text;
            callback(json);
        }
    }
}
