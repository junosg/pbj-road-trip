using System.Collections;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    private string _playerName = "Player";
    public string PlayerName { get { return _playerName; }}

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

    public void SetPlayerName(string value)
    {
        Debug.Log(value);
        _playerName = value;
    }
}
