using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectionHandler : MonoBehaviour
{
    [SerializeField] GameData GData;
    [SerializeField] GameObject AvatarPanel;
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] TMP_InputField PlayerName;
    [SerializeField] TMP_Text MainPlayerName;
    [SerializeField] GameObject[] Avatar;
    [SerializeField] GameObject[] MainMenuAvatar;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void AvatarSelection(int Sel)
    {
        for (int i = 0; i < Avatar.Length; i++)
        {
            Avatar[i].transform.GetChild(0).gameObject.SetActive(true);
            Avatar[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        Avatar[Sel].transform.GetChild(0).gameObject.SetActive(false);
        Avatar[Sel].transform.GetChild(1).gameObject.SetActive(true);
        GData.SelectedAvatar = Sel+1;
        PersistentDataManager.instance.SaveData();
    }
    public void OKBtnPress()
    {
        if (string.IsNullOrEmpty(PlayerName.text))
        {
            switch (GData.SelectLanguage)
            {
                case 0:
                    PlayerName.text = "Please Input Name";
                    break;
                case 1:
                    PlayerName.text = "Παρακαλώ εισάγετε Όνομα";
                    break;
                case 2:
                    PlayerName.text = "Proszę wpisać nazwę";
                    break;
                case 3:
                    PlayerName.text = "Per favore inserisci il nome";
                    break;
                case 4:
                    PlayerName.text = "Por favor ingrese el nombre";
                    break;
                case 5:
                    PlayerName.text = "Voer een naam in";
                    break;
            }
            PlayerName.textComponent.color = Color.red;
            StartCoroutine(NormalizedText());
            return;
        }
        else if (GData.SelectedAvatar == 0)
        {
            for (int i = 0; i < Avatar.Length; i++)
            {
                Avatar[i].transform.GetChild(0).GetComponent<Image>().color = Color.red;
            }
                StartCoroutine(NormalizedAvatar());
        }
        else
        {
            GData.PlayerName = PlayerName.text;
            PersistentDataManager.instance.SaveData();
            MainPlayerName.text = GData.PlayerName;
            for (int i = 0; i < MainMenuAvatar.Length; i++)
            {
                MainMenuAvatar[i].SetActive(false);
            }
            MainMenuAvatar[GData.SelectedAvatar-1].SetActive(true);
            AvatarPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
        }
    }
    private IEnumerator NormalizedText()
    {
        yield return new WaitForSeconds(1f);
        PlayerName.text = string.Empty;
        PlayerName.textComponent.color = Color.white;
    }
    private IEnumerator NormalizedAvatar()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < Avatar.Length; i++)
        {
            Avatar[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }
}
