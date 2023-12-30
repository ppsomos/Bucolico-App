using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int SelectedPlayer;
    public int SelectedRoom;
    public int TotalRightAnswer;
    public int TotalWrongAnswer;
    public int TotalQuestion_AnserGiven;
    public int Maximum_Score;
    public int Total_Score;
    public bool isMultiplayer;
    public bool isFirstTime;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        TotalRightAnswer = 0;
        TotalWrongAnswer = 0;
        TotalQuestion_AnserGiven = 0;
    }

    
}
