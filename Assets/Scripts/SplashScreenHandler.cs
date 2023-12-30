using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenHandler : MonoBehaviour
{
    public GameData GData;
    public Slider FillSlider;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CheckForFirstTime", 1.5f);
        Invoke("ChangeScene", 1f);
    }
    public void CheckForFirstTime()
    {
        if(GData.IsFirstTime)
        {
            GameManager.Instance.isFirstTime = true;
            GData.IsFirstTime = false;
            GData.SelectLanguage = 0;
            GData.SelectedAvatar = 0;
            GData.PlayerName = null;
            for (int i = 0; i < GData.GameQUestion.Length; i++)
            {
                GData.GameQUestion[i].IsComplete = false;
            }
            for (int i = 0; i < GData.Multi_Player.Length; i++)
            {
                GData.Multi_Player[i].PlayerName = null;
                GData.Multi_Player[i].SelectedAvatar = 0;
                GData.Multi_Player[i].RightAnswer = 0;
                GData.Multi_Player[i].WrongAnswer = 0;
            }
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            GameManager.Instance.isFirstTime = false;
        }
    }
    public void ChangeScene()
    {
        StartCoroutine(BarFillStart());
    }
    IEnumerator BarFillStart()
    {
        yield return new WaitForSeconds(.01f);
        if(FillSlider.value<1f)
        {
            FillSlider.value += Random.Range(0.005f, 0.0075f);
            StartCoroutine(BarFillStart());
        }
        else
        {
            StopAllCoroutines();
            SceneManager.LoadScene(1);
        }
    }
}
