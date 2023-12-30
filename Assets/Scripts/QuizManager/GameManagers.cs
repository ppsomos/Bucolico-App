using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    //public GameObject[] levelPos;
    //public GameObject player;

    //public static int score;

    //bool istrue = false;
    //public Text totalanswer;
    //public Text showrelatedquiztext;

    ////public Text Countrytext;
    //private void Start()
    //{
    //    istrue = false;
    //}
    //void Update()
    //{

    //    if (PlayerPrefs.GetInt("LevelM1") == 0)
    //    {
    //        PlayerPrefs.SetInt("CurrentLevel", 1);
    //        //Uk
    //    }
    //    else if (PlayerPrefs.GetInt("LevelM2") == 0)
    //    {
    //        PlayerPrefs.SetInt("CurrentLevel", 2);
    //        //Belgium
    //    }
    //    //else if (PlayerPrefs.GetInt("LevelM3") == 0)
    //    //{
    //    //    PlayerPrefs.SetInt("CurrentLevel", 3);
    //    //    //greece
    //    //}
    //    //else if (PlayerPrefs.GetInt("LevelM4") == 0)
    //    //{
    //    //    PlayerPrefs.SetInt("CurrentLevel", 4);
    //    //    //polanad
    //    //}
    //    //else if (PlayerPrefs.GetInt("LevelM5") == 0)
    //    //{
    //    //    PlayerPrefs.SetInt("CurrentLevel", 5);
    //    //    //portagual
    //    //}
    //    else
    //    {
    //        PlayerPrefs.SetInt("CurrentLevel", 1);
    //    }


    //    //Debug.Log("currentlevel" + PlayerPrefs.GetInt("CurrentLevel"));
    //    if (PlayerPrefs.GetInt("levelcurrent") == 1)
    //    {
    //        if (istrue == false)
    //        {
    //            //Debug.Log("1call");
    //            //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
    //            //Countrytext.text = "Welcome to United kingdom";
    //            istrue = true;
    //            Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
    //            StartCoroutine(Waitcountrytext());
                

    //        }

    //    }
    //    else if (PlayerPrefs.GetInt("levelcurrent") == 2)
    //    {
    //        if (istrue == false)
    //        {
    //            //Debug.Log("2call");
    //            //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
    //            //Countrytext.text = "Welcome to Belgium";
    //            istrue = true;
    //            Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
    //            StartCoroutine(Waitcountrytext());
                

    //        }

    //    }
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 3)
    //    //{
    //    //    if (istrue == false)
    //    //    {
    //    //        Debug.Log("3call");
    //    //        Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
    //    //        Countrytext.text = "Welcome to Greece";
    //    //        istrue = true;
    //    //        Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
    //    //        StartCoroutine(Waitcountrytext());
                
    //    //    }

    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 4)
    //    //{
    //    //    if (istrue == false)
    //    //    {
    //    //        Debug.Log("4call");
    //    //        Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
    //    //        Countrytext.text = "Welcome to Poland";
    //    //        istrue = true;
    //    //        Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
    //    //        StartCoroutine(Waitcountrytext());
                
    //    //    }

    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 5)
    //    //{
    //    //    if (istrue == false)
    //    //    {
    //    //        Debug.Log("5call");
    //    //        Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
    //    //        Countrytext.text = "Welcome to Portugal";
    //    //        istrue = true;
    //    //        Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
    //    //        StartCoroutine(Waitcountrytext());
                
    //    //    }

    //    //}

    //    //------Wait for Country Text-----------

    //    IEnumerator Waitcountrytext()
    //    {
    //        yield return new WaitForSeconds(1f);
    //        //Countrytext.text = "";
    //    }




    //    // For Total Score text

    //    if (PlayerPrefs.GetInt("levelcurrent") == 1)
    //    {
    //        totalanswer.text = PlayerPrefs.GetInt("UKHist") + PlayerPrefs.GetInt("UKGeo") + PlayerPrefs.GetInt("UKFood") + PlayerPrefs.GetInt("UKCult") + PlayerPrefs.GetInt("UKLang") + "/10";
    //    }
    //    else if (PlayerPrefs.GetInt("levelcurrent") == 2)
    //    {
    //        totalanswer.text = PlayerPrefs.GetInt("BelgiumHist") + PlayerPrefs.GetInt("BelgiumGeo") + PlayerPrefs.GetInt("BelgiumFood") + PlayerPrefs.GetInt("BelgiumCult") + PlayerPrefs.GetInt("BelgiumLang") + "/28";
    //    }
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 3)
    //    //{
    //    //    totalanswer.text = PlayerPrefs.GetInt("GreeceHist") + PlayerPrefs.GetInt("GreeceGeo") + PlayerPrefs.GetInt("GreeceFood") + PlayerPrefs.GetInt("GreeceCult") + PlayerPrefs.GetInt("GreeceLang") + "/15";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 4)
    //    //{
    //    //    totalanswer.text = PlayerPrefs.GetInt("PolandHist") + PlayerPrefs.GetInt("PolandGeo") + PlayerPrefs.GetInt("PolandFood") + PlayerPrefs.GetInt("PolandCult") + PlayerPrefs.GetInt("PolandLang") + "/15";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 5)
    //    //{
    //    //    totalanswer.text = PlayerPrefs.GetInt("PortugalHist") + PlayerPrefs.GetInt("PortugalGeo") + PlayerPrefs.GetInt("PortugalFood") + PlayerPrefs.GetInt("PortugalCult") + PlayerPrefs.GetInt("PortugalLang") + "/15";
    //    //}

    //    //----------------Uk Manager//--------

    //    if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 1)
    //    {
    //        showrelatedquiztext.text = PlayerPrefs.GetInt("UKHist") + "/4";
    //    }
    //    else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 2)
    //    {
    //        showrelatedquiztext.text = PlayerPrefs.GetInt("UKGeo") + "/4";
    //    }
    //    else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 3)
    //    {
    //        showrelatedquiztext.text = PlayerPrefs.GetInt("UKFood") + "/2";
    //    }
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 4)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("UKCult") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 5)
    //    //{

    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("UKLang") + "/3";
    //    //}

    //    //----------------Belgium//--------


    //    if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 1)
    //    {
    //        showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumHist") + "/14";
    //    }
    //    else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 2)
    //    {
    //        showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumGeo") + "/7";
    //    }
    //    else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 3)
    //    {
    //        showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumFood") + "/7";
    //    }
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 4)
    //    //{

    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumCult") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 5)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumLang") + "/3";
    //    //}


    //    //----------------Greece//--------


    //    //if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 1)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceHist") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 2)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceGeo") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 3)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceFood") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 4)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceCult") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 5)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceLang") + "/3";
    //    //}

    //    //----------------Poland//--------

    //    //if (PlayerPrefs.GetInt("levelcurrent") == 4 && PolandManager.selectedCategory == 1)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PolandHist") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 4 && PolandManager.selectedCategory == 2)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PolandGeo") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 4 && PolandManager.selectedCategory == 3)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PolandFood") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 4 && PolandManager.selectedCategory == 4)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PolandCult") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 4 && PolandManager.selectedCategory == 5)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PolandLang") + "/3";
    //    //}
    //    //----------------Portagual//--------


    //    //if (PlayerPrefs.GetInt("levelcurrent") == 5 && PortugalManager.selectedCategory == 1)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalHist") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PortugalManager.selectedCategory == 2)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalGeo") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PortugalManager.selectedCategory == 3)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalFood") + "/3";
    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PortugalManager.selectedCategory == 4)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalCult") + "/3";

    //    //}
    //    //else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PortugalManager.selectedCategory == 5)
    //    //{
    //    //    showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalLang") + "/3";
    //    //}
    //}
    public void setvalue()
    {
        PlayerPrefs.SetInt("Flag", 1);
    }

}
