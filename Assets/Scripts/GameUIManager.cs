using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public GameData GData;
    //public GameObject TimeHandler;
    public GameObject ScorePanal;
    public GameObject End_MatchBtn;
    public GameObject RestartBtn;
    public GameObject HomeBtn;
    public TMP_Text Player1NameText;
    public TMP_Text Player1RightAnserText;
    public TMP_Text Player1WrongAnserText;
    public TMP_Text Player1ScoreText;
    public TMP_Text Player1TimeText;
    public TMP_Text Player2NameText;
    public TMP_Text Player2RightAnserText;
    public TMP_Text Player2WrongAnserText;
    public TMP_Text Player2ScoreText;
    public TMP_Text Player2TimeText;
    public GameObject MatchDraw;
    public GameObject Player1WinBadg;
    public GameObject Player2WinBadg;
    public GameObject[] Player1Avatars;
    public GameObject[] Player2Avatars;
    //public LoadManager loadingManager;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
       // Invoke("ActiveTimeHandler", .25f);
    }
    //public void ActiveTimeHandler()
    //{
    //    TimeHandler.SetActive(true);
    //}
    public void PanalOpen(GameObject Panal)
    {
        Panal.SetActive(true);
    }
    public void Panalclose(GameObject Panal)
    {
        Panal.SetActive(false);
    }
    public void OnCompetitionComplete()
    {
        Debug.Log(GData.Multi_Player[0].PlayerName);
        Debug.Log(GData.Multi_Player[1].PlayerName);
        Player1Avatars[GData.Multi_Player[0].SelectedAvatar - 1].SetActive(true);
        Player2Avatars[GData.Multi_Player[1].SelectedAvatar - 1].SetActive(true);
        Player1NameText.text = GData.Multi_Player[0].PlayerName;
        Player1RightAnserText.text = ": " + GData.Multi_Player[0].RightAnswer.ToString();
        Player1WrongAnserText.text = ": " + GData.Multi_Player[0].WrongAnswer.ToString();
        Player1ScoreText.text = ": " + (GData.Multi_Player[0].RightAnswer * 5).ToString();
        DisplayPlayer1Time(GData.Multi_Player[0].TimeTaken);
        Player2NameText.text = GData.Multi_Player[1].PlayerName;
        Player2RightAnserText.text = ": " + GData.Multi_Player[1].RightAnswer.ToString();
        Player2WrongAnserText.text = ": " + GData.Multi_Player[1].WrongAnswer.ToString();
        Player2ScoreText.text = ": " + (GData.Multi_Player[1].RightAnswer * 5).ToString();
        DisplayPlayer2Time(GData.Multi_Player[1].TimeTaken);
        if (GData.Multi_Player[0].RightAnswer > GData.Multi_Player[1].RightAnswer)
        {
            Player1WinBadg.SetActive(true);
        }
        else if (GData.Multi_Player[0].RightAnswer < GData.Multi_Player[1].RightAnswer)
        {
            Player2WinBadg.SetActive(true);
        }
        else if (GData.Multi_Player[0].RightAnswer == GData.Multi_Player[1].RightAnswer)
        {
            MatchDraw.SetActive(true);
        }
        ScorePanal.SetActive(true);
    }
    public void DisplayPlayer1Time(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Player1TimeText.text = ": " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void DisplayPlayer2Time(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Player2TimeText.text = ": " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void OnHomeBtnClick()
    {
        GameManager.Instance.SelectedPlayer = 0;
        //loadingManager.levelLoad(0);
    }
    public void OnPauseBtnClcik()
    {
        Time.timeScale = 0;
        if (GameManager.Instance.isMultiplayer)
        {
            End_MatchBtn.SetActive(true);
            RestartBtn.SetActive(false);
            HomeBtn.SetActive(false);
        }
        else
        {
            End_MatchBtn.SetActive(false);
            RestartBtn.SetActive(true);
            HomeBtn.SetActive(true);
        }
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
    }
}
