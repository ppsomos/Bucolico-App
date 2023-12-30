using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public GameData gameData;

    #region Singleton
    public static PersistentDataManager instance;
    void Awake()
    {
        GetInstance();
    }

    void GetInstance()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    void Start()
    {
        LoadData();
        // PlayerPrefs.DeleteAll();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        string gameDataString = JsonConvert.SerializeObject(gameData);
        PlayerPrefs.SetString("GameData", gameDataString);
        print("GameData Saved In PlayerPrefs: " + PlayerPrefs.GetString("GameData"));
    }

    public void LoadData()
    {
        string gameDataString = PlayerPrefs.GetString("GameData");
        GameData gameDataFromPlayerPrefs = JsonConvert.DeserializeObject<GameData>(gameDataString);
        if (gameDataFromPlayerPrefs == null)
        {
            print("Game is played first time. No GameData found.");
            return;
        }
        print("GameData Loaded From PlayerPrefs");

        // Set Local GameData Variables Here - Start
        //gameData.coins = gameDataFromPlayerPrefs.coins;
        gameData.IsFirstTime = gameDataFromPlayerPrefs.IsFirstTime;
        gameData.IsMultiplayer = gameDataFromPlayerPrefs.IsMultiplayer;
        gameData.SelectedAvatar = gameDataFromPlayerPrefs.SelectedAvatar;
        gameData.SelectLanguage = gameDataFromPlayerPrefs.SelectLanguage;
        gameData.PlayerName = gameDataFromPlayerPrefs.PlayerName;
        //gameData.AllVehicles = gameDataFromPlayerPrefs.AllVehicles;

        //for(int i = 0; i < gameData.AllVehicles.Length; i++)
        //{
        //    gameData.AllVehicles[i] = gameDataFromPlayerPrefs.AllVehicles[i];
        //}
        // Set Local GameData Variables Here - End
    }
}
