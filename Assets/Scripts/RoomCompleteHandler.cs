using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCompleteHandler : MonoBehaviour
{
    public GameData GData;
    public CountDown TimeHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnPlayerEnter();
        }
    }
   
    public void OnPlayerEnter()
    {
        if (!GameManager.Instance.isMultiplayer)
        {
            RoomHandler.Instance.CongratulationPanel.SetActive(true);
            RoomHandler.Instance.Player.SetActive(false);
            RoomHandler.Instance.PlayerCanvas.SetActive(false);
            PlayerPrefs.SetInt("unlocklevel", 1);
            PlayerPrefs.Save();
        }
        else
        {
            GData.Multi_Player[GameManager.Instance.SelectedPlayer].TimeTaken = 300 - TimeHandler.timeRemaining;
            PersistentDataManager.instance.SaveData();
            if (GameManager.Instance.SelectedPlayer == 0)
            {
                RoomHandler.Instance.Multiplayer_CongratulationPanel.SetActive(true);
                RoomHandler.Instance.Player.SetActive(false);
                RoomHandler.Instance.PlayerCanvas.SetActive(false);
            }
            else
            {
                GameUIManager.Instance.OnCompetitionComplete();
            }
        }
        RoomHandler.Instance.EndText.SetActive(false);
    }
}
