using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public GameData GData;
    public Image Dot;
    public float Distance;
    public Button ReadQuestionBtn;
    public GameObject HITObj;
    public GameObject RightAnswer;
    public GameObject WrongAnswer;
    public int CorrectAnswer;
    public int objIndex;
    [Header("Question Panel")]
    public GameObject QuestionPanel;

    [Header("Question Text")]
    public Text Question_Text;
    public Button OP1_Btn;
    public Button OP2_Btn;
    public Button OP3_Btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, Distance))
        {
            if (hit.transform.CompareTag("Obj"))
            {
                Dot.color = Color.green;
                HITObj = hit.transform.gameObject;
                ReadQuestionBtn.onClick.AddListener(LoadQuestion);
                if(!GData.GameQUestion[ HITObj.GetComponent<zone>().ObjIndex].IsComplete )
                {
                    ReadQuestionBtn.interactable = true;
                }
                else
                {
                    ReadQuestionBtn.interactable = false;
                }
                objIndex = HITObj.GetComponent<zone>().ObjIndex;
                CorrectAnswer = HITObj.GetComponent<zone>().CorrectAnswer;
               ReadQuestionBtn.gameObject.SetActive(true);
            }
            else
            {
                Dot.color = Color.white;
                HITObj = null;
                ReadQuestionBtn.onClick.RemoveAllListeners();
                ReadQuestionBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            HITObj = null;
            Dot.color = Color.white;
            ReadQuestionBtn.onClick.RemoveAllListeners();
            ReadQuestionBtn.gameObject.SetActive(false);
        }
    }
    public void LoadQuestion()
    {
        OP1_Btn.enabled = true;
        OP2_Btn.enabled = true;
        OP3_Btn.enabled = true;
        Question_Text.text = HITObj.GetComponent<zone>().Question;
        OP1_Btn.transform.GetChild(0).transform.GetComponent<Text>().text = HITObj.GetComponent<zone>().Op1;
        OP2_Btn.transform.GetChild(0).transform.GetComponent<Text>().text = HITObj.GetComponent<zone>().Op2;
        OP3_Btn.transform.GetChild(0).transform.GetComponent<Text>().text = HITObj.GetComponent<zone>().Op3;
        RoomHandler.Instance.QuestionCanvas.SetActive(true);
        RoomHandler.Instance.QuestionCanvas_Camera.SetActive(true);
        RoomHandler.Instance.PlayerCanvas.SetActive(false);
        RoomHandler.Instance.Player.SetActive(false);
        RoomHandler.Instance.MainCanvas.SetActive(false);
        QuestionPanel.SetActive(true);
    }
    public void OptionButtonClick(int NO)
    {
        if(NO== CorrectAnswer)
        {
            RightAnswer.SetActive(true);
            WrongAnswer.SetActive(false);
            GameManager.Instance.TotalRightAnswer++;
            if(GameManager.Instance.isMultiplayer)
            {
                GData.Multi_Player[GameManager.Instance.SelectedPlayer].RightAnswer++;
            }
        }
        else
        {
            if(CorrectAnswer==0)
            {
                OP1_Btn.transform.GetChild(0).transform.GetComponent<Text>().color = Color.green;
            }
            else if (CorrectAnswer == 1)
            {
                OP2_Btn.transform.GetChild(0).transform.GetComponent<Text>().color = Color.green;
            }
            else if (CorrectAnswer == 2)
            {
                OP3_Btn.transform.GetChild(0).transform.GetComponent<Text>().color = Color.green;
            }
            WrongAnswer.SetActive(true);
           RightAnswer.SetActive(false);
           GameManager.Instance.TotalWrongAnswer++;
            if (GameManager.Instance.isMultiplayer)
            {
                GData.Multi_Player[GameManager.Instance.SelectedPlayer].WrongAnswer++;
            }
        }
        OP1_Btn.enabled = false;
        OP2_Btn.enabled = false;
        OP3_Btn.enabled = false;
        GData.GameQUestion[objIndex].IsComplete = true;
        GameManager.Instance.TotalQuestion_AnserGiven++;
        GameManager.Instance.Total_Score = 5 * GameManager.Instance.TotalRightAnswer;
        RoomHandler.Instance.ObjectComplete_ScoreText.text= GameManager.Instance.Total_Score.ToString();
        RoomHandler.Instance.MainQuestionText.text = (GameManager.Instance.TotalQuestion_AnserGiven + "/" + RoomHandler.Instance.TotalRoomQuestion).ToString();
        RoomHandler.Instance.Main_ScoreText.text = GameManager.Instance.Total_Score.ToString();
        RoomHandler.Instance.LevelFail_ScoreText.text= GameManager.Instance.Total_Score.ToString();
        PersistentDataManager.instance.SaveData();
        Invoke("OpenObjectComplete", 1f);
    }
    public void OpenObjectComplete()
    {
        OP1_Btn.transform.GetChild(0).transform.GetComponent<Text>().color = Color.white;
        OP2_Btn.transform.GetChild(0).transform.GetComponent<Text>().color = Color.white;
        OP3_Btn.transform.GetChild(0).transform.GetComponent<Text>().color = Color.white;
        if (GameManager.Instance.TotalQuestion_AnserGiven < RoomHandler.Instance.TotalRoomQuestion)
        {
            RoomHandler.Instance.QuestionCanvas.SetActive(false);
            RoomHandler.Instance.QuestionCanvas_Camera.SetActive(false);
            RoomHandler.Instance.MainCanvas.SetActive(true);
            RoomHandler.Instance.ObjectComplete_Panel.SetActive(true);
        }
        else
        {
            if(GameManager.Instance.SelectedRoom==0)
            {
                if(GameManager.Instance.isMultiplayer)
                {
                    OnRoomComplete();
                }
                else
                {
                    if (GameManager.Instance.Total_Score < 30)
                    {
                        RoomHandler.Instance.QuestionCanvas.SetActive(false);
                        RoomHandler.Instance.QuestionCanvas_Camera.SetActive(false);
                        RoomHandler.Instance.MainCanvas.SetActive(true);
                        RoomHandler.Instance.TryAgainPanal.SetActive(true);
                    }
                    else
                    {
                        OnRoomComplete();
                    }
                }               
            }
            else if(GameManager.Instance.SelectedRoom == 1)
            {
                if (GameManager.Instance.isMultiplayer)
                {
                    OnRoomComplete();
                }
                else
                {
                    if (GameManager.Instance.Total_Score < 40)
                    {
                        RoomHandler.Instance.QuestionCanvas.SetActive(false);
                        RoomHandler.Instance.QuestionCanvas_Camera.SetActive(false);
                        RoomHandler.Instance.MainCanvas.SetActive(true);
                        RoomHandler.Instance.TryAgainPanal.SetActive(true);
                    }
                    else
                    {
                        OnRoomComplete();
                    }
                }    
            }
        }
        WrongAnswer.SetActive(false);
        RightAnswer.SetActive(false);
       
    }
    public void OnRoomComplete()
    {
        RoomHandler.Instance.QuestionCanvas.SetActive(false);
        RoomHandler.Instance.QuestionCanvas_Camera.SetActive(false);
        RoomHandler.Instance.MainCanvas.SetActive(true);
        RoomHandler.Instance.RoomCompleteParticle.SetActive(true);
        RoomHandler.Instance.EndText.SetActive(true);
        RoomHandler.Instance.Player.SetActive(true);
        RoomHandler.Instance.PlayerCanvas.SetActive(true);
    }
}
