using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameData GData;
    public static LevelLoader instance = null;

    public GameObject Mainmenupanal;
    public GameObject AvatarSelectionPanel;
    public GameObject flagpanal;
    public GameObject _button;
    public GameObject Discleimer_Panel;
    public GameObject StartSetting_Panel;
    public GameObject[] MainMenuAvatar;
    public TMP_Text MainPlayerName;
    public TMP_Dropdown StartSettingDropDown;
    public TMP_Dropdown SettingDropDown;
    public MultiplayerManager MP;
    public int Unlockedlevel;
    public static int currentindex;

    private void Awake()
    {
        instance = this;
        CheckForFirstTime();
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("Flag"))
        {
            int val = PlayerPrefs.GetInt("Flag");
            if (val == 1)
            {
                Mainmenupanal.SetActive(false);
                flagpanal.SetActive(true);
                PlayerPrefs.SetInt("Flag", 0);
            }
        }
        Invoke("ResetData", 2f);
        MainPlayerName.text = GData.PlayerName;
        GameManager.Instance.isMultiplayer = false;
        UnLockLevel();
    }
    public void CheckForFirstTime()
    {
        if (GameManager.Instance.isFirstTime)
        {
            GameManager.Instance.isFirstTime = false;
            Mainmenupanal.SetActive(false);
            Discleimer_Panel.SetActive(true);
            MP.playerNo = 0;
            MP.Player1Text.SetActive(true);
            MP.Player2Text.SetActive(false);
        }
        else
        {
            for (int i = 0; i < MainMenuAvatar.Length; i++)
            {
                MainMenuAvatar[i].SetActive(false);
            }
            MainMenuAvatar[GData.SelectedAvatar-1].SetActive(true);
            Mainmenupanal.SetActive(true);
            SettingDropDown.value = GData.SelectLanguage;
        }
    }
    public void OnMultiplayerSelect()
    {
        GameManager.Instance.isMultiplayer = true;
        UnLockLevel();
    }
    public void UnLockLevel()
    {
        if (!GameManager.Instance.isMultiplayer)
        {
            Unlockedlevel = PlayerPrefs.GetInt("unlocklevel");
        }
        else
        {
            Unlockedlevel = 1;
        }      
            if (Unlockedlevel >= 1)
            {
                _button.GetComponent<Button>().interactable = true;
                _button.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                _button.GetComponent<Button>().interactable = false;
                _button.transform.GetChild(0).gameObject.SetActive(true);
            }
        
    }
    public void Disclaimer_Ok_BtnClick()
    {
        Discleimer_Panel.SetActive(false);
        StartSetting_Panel.SetActive(true);
    }
    public void StartSetting_LanguageChange()
    {
        GData.SelectLanguage = StartSettingDropDown.value;

        switch (StartSettingDropDown.value)
        {
            case 0:
                StartSettingDropDown.captionText.text = "English";
                StartSettingDropDown.options[0].text = "English";
                StartSettingDropDown.options[1].text = "Greek";
                StartSettingDropDown.options[2].text = "Polish";
                StartSettingDropDown.options[3].text = "Italian";
                StartSettingDropDown.options[4].text = "Spanish";
                StartSettingDropDown.options[5].text = "Dutch";
                break;
            case 1:
                StartSettingDropDown.captionText.text = "Ελληνικά";
                StartSettingDropDown.options[0].text = "Αγγλικά";
                StartSettingDropDown.options[1].text = "Ελληνικά";
                StartSettingDropDown.options[2].text = "Πολωνικά";
                StartSettingDropDown.options[3].text = "Ιταλικά";
                StartSettingDropDown.options[4].text = "Ισπανικά";
                StartSettingDropDown.options[5].text = "Ολλανδικά";
                break;
            case 2:
                StartSettingDropDown.captionText.text = "Polski";
                StartSettingDropDown.options[0].text = "język angielski";
                StartSettingDropDown.options[1].text = "grecki";
                StartSettingDropDown.options[2].text = "Polski";
                StartSettingDropDown.options[3].text = "Włoski";
                StartSettingDropDown.options[4].text = "hiszpański";
                StartSettingDropDown.options[5].text = "Holenderski";
                break;
            case 3:
                StartSettingDropDown.captionText.text = "Italiano";
                StartSettingDropDown.options[0].text = "Inglese";
                StartSettingDropDown.options[1].text = "Greco";
                StartSettingDropDown.options[2].text = "Polacco";
                StartSettingDropDown.options[3].text = "Italiano";
                StartSettingDropDown.options[4].text = "Spagnolo";
                StartSettingDropDown.options[5].text = "Olandese";
                break;
            case 4:
                StartSettingDropDown.captionText.text = "Español";
                StartSettingDropDown.options[0].text = "Inglés";
                StartSettingDropDown.options[1].text = "Griego";
                StartSettingDropDown.options[2].text = "Polaco";
                StartSettingDropDown.options[3].text = "Italiano";
                StartSettingDropDown.options[4].text = "Español";
                StartSettingDropDown.options[5].text = "Holandés";
                break;
            case 5:
                StartSettingDropDown.captionText.text = "Nederlands";
                StartSettingDropDown.options[0].text = "Inglés";
                StartSettingDropDown.options[1].text = "Griego";
                StartSettingDropDown.options[2].text = "Polaco";
                StartSettingDropDown.options[3].text = "Italiano";
                StartSettingDropDown.options[4].text = "Español";
                StartSettingDropDown.options[5].text = "Nederlands";
                break;
        }
        PersistentDataManager.instance.SaveData();
        LocaleSelector.instance.ChangeLocale();
    }
    public void StartSetting_Ok_BtnClick()
    {
        StartSetting_Panel.SetActive(false);
        AvatarSelectionPanel.SetActive(true);
        SettingDropDown.value = GData.SelectLanguage;
    }
    public void Setting_LanguageChange()
    {
        GData.SelectLanguage = SettingDropDown.value;
        switch (SettingDropDown.value)
        {
            case 0:
                SettingDropDown.captionText.text = "English";
                SettingDropDown.options[0].text = "English";
                SettingDropDown.options[1].text = "Greek";
                SettingDropDown.options[2].text = "Polish";
                SettingDropDown.options[3].text = "Italian";
                SettingDropDown.options[4].text = "Spanish";
                SettingDropDown.options[5].text = "Dutch";
                break;
            case 1:
                SettingDropDown.captionText.text = "Ελληνικά";
                SettingDropDown.options[0].text = "Αγγλικά";
                SettingDropDown.options[1].text = "Ελληνικά";
                SettingDropDown.options[2].text = "Πολωνικά";
                SettingDropDown.options[3].text = "Ιταλικά";
                SettingDropDown.options[4].text = "Ισπανικά";
                SettingDropDown.options[5].text = "Ολλανδικά";
                break;
            case 2:
                SettingDropDown.captionText.text = "Polski";
                SettingDropDown.options[0].text = "język angielski";
                SettingDropDown.options[1].text = "grecki";
                SettingDropDown.options[2].text = "Polski";
                SettingDropDown.options[3].text = "Włoski";
                SettingDropDown.options[4].text = "hiszpański";
                SettingDropDown.options[5].text = "Holenderski";
                break;
            case 3:
                SettingDropDown.captionText.text = "Italiano";
                SettingDropDown.options[0].text = "Inglese";
                SettingDropDown.options[1].text = "Greco";
                SettingDropDown.options[2].text = "Polacco";
                SettingDropDown.options[3].text = "Italiano";
                SettingDropDown.options[4].text = "Spagnolo";
                SettingDropDown.options[5].text = "Olandese";
                break;
            case 4:
                SettingDropDown.captionText.text = "Español";
                SettingDropDown.options[0].text = "Inglés";
                SettingDropDown.options[1].text = "Griego";
                SettingDropDown.options[2].text = "Polaco";
                SettingDropDown.options[3].text = "Italiano";
                SettingDropDown.options[4].text = "Español";
                SettingDropDown.options[5].text = "Holandés";
                break;
            case 5:
                SettingDropDown.captionText.text = "Nederlands";
                SettingDropDown.options[0].text = "Inglés";
                SettingDropDown.options[1].text = "Griego";
                SettingDropDown.options[2].text = "Polaco";
                SettingDropDown.options[3].text = "Italiano";
                SettingDropDown.options[4].text = "Español";
                SettingDropDown.options[5].text = "Nederlands";
                break;
        }
        PersistentDataManager.instance.SaveData();
        LocaleSelector.instance.ChangeLocale();
    }
    public void ChangeLevelPos(int index)
    {
        GameManager.Instance.SelectedRoom = index;
        // PlayerPrefs.SetInt("levelcurrent", currentindex);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void ResetData()
    {
        MP.playerNo = 0;
        MP.PlayerName_InputField.GetComponent<TMP_InputField>().text = null;
        MP.Player1Avatar.transform.GetChild(1).gameObject.SetActive(false);
        MP.Player2Avatar.transform.GetChild(1).gameObject.SetActive(false);
        MP.Player1Text.SetActive(true);
        MP.Player2Text.SetActive(false);
        GameManager.Instance.isMultiplayer = false;
        for (int i = 0; i < GData.Multi_Player.Length; i++)
        {
            GData.Multi_Player[i].PlayerName = null;
            GData.Multi_Player[i].SelectedAvatar = 0;
            GData.Multi_Player[i].RightAnswer = 0;
            GData.Multi_Player[i].WrongAnswer = 0;
            GData.Multi_Player[i].TimeTaken = 0;
            PersistentDataManager.instance.SaveData();
        }
        UnLockLevel();
    }
}
