using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoomHandler : MonoBehaviour
{
    public static RoomHandler Instance;
    [Header("Question Data")]
    public QuestionData QU;

    [Header("Game UI")]

    public GameObject PlayerCanvas;
    public GameObject QuestionCanvas;
    public GameObject QuestionCanvas_Camera;
    public GameObject MainCanvas;
    public GameObject ObjectComplete_Panel;
    public GameObject TryAgainPanal;
    public GameObject CongratulationPanel;
    public GameObject RoomCompleteParticle;
    public GameObject PlayerNamePanel;
    public GameObject EndText;
    public GameObject Multiplayer_CongratulationPanel;
    public Text ObjectComplete_ScoreText;
    public TMP_Text Main_ScoreText;
    public TMP_Text PlayerName_Text;
    public Text LevelFail_ScoreText;
    public Text MainQuestionText;
    public int TotalRoomQuestion;
    [Header("GameData")]
    public GameData GData;

    [Header("Player")]
    public GameObject Player;

    [Header("Player Pos")]
    public GameObject[] PlayerPos;

    [Header("Booth Room Model")]
    public zone[] BothRoomModel;

    [Header("Game Room")]
    public GameObject[] Room;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance= this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.TotalQuestion_AnserGiven = 0;
        GameManager.Instance.TotalRightAnswer = 0;
        GameManager.Instance.TotalWrongAnswer = 0;
        GameManager.Instance.Total_Score = 0;
        if(GameManager.Instance.isMultiplayer)
        {
            PlayerNamePanel.SetActive(true);
            PlayerName_Text.text = GData.Multi_Player[GameManager.Instance.SelectedPlayer].PlayerName;
        }
        for (int i=0;i<GData.GameQUestion.Length;i++)
        {
            GData.GameQUestion[i].IsComplete = false;
            PersistentDataManager.instance.SaveData();
        }
        if(GameManager.Instance.SelectedRoom==0)
        {
            TotalRoomQuestion = 13;
            Room[0].SetActive(true);
        }
        else if (GameManager.Instance.SelectedRoom == 1)
        {
            TotalRoomQuestion = 17;
            Room[1].SetActive(true);
        }
        MainQuestionText.text= (GameManager.Instance.TotalQuestion_AnserGiven + "/" + TotalRoomQuestion).ToString();
        Main_ScoreText.text=(GameManager.Instance.TotalRightAnswer*5).ToString();
        GameManager.Instance.Maximum_Score = 5 * TotalRoomQuestion;
        LoadQuestion();
        ActivePlayer();
    }   
    public void LoadQuestion()
    {
        int questionCount = QU.languages[GData.SelectLanguage].Question.Length;
        for (int i = 0; i < questionCount; i++)
        {
            // Copy the options into a list for shuffling
            List<string> options = new List<string>
        {
            QU.languages[GData.SelectLanguage].Op1[i],
            QU.languages[GData.SelectLanguage].Op2[i],
            QU.languages[GData.SelectLanguage].Op3[i]
        };

            // Shuffle the options
            Shuffle(options);

            int correctAnswerIndex = options.IndexOf(QU.languages[GData.SelectLanguage].Op1[i]);
            // Assign shuffled options to BothRoomModel
            BothRoomModel[i].Question = QU.languages[GData.SelectLanguage].Question[i];
            BothRoomModel[i].Op1 = options[0];
            BothRoomModel[i].Op2 = options[1];
            BothRoomModel[i].Op3 = options[2];

            // Set the CorrectAnswer property to the original correct answer
            BothRoomModel[i].CorrectAnswer = correctAnswerIndex;
        }
    }

    // Fisher-Yates shuffle algorithm
    private void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    public void ActivePlayer()
    {
        Player.transform.position = PlayerPos[GameManager.Instance.SelectedRoom].transform.position;
        Player.SetActive(true);
    }
    public void OnNextBtnPress()
    {
        if (GameManager.Instance.SelectedPlayer == 0)
        {
            GameManager.Instance.SelectedPlayer = 1;
        }
    }
}
