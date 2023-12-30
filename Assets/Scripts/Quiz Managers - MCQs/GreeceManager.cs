using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GreeceManager : MonoBehaviour
{
    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public string[] historyQues;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[18];
    private Option[] histOp2 = new Option[18];
    private Option[] histOp3 = new Option[18];
    private Option[] histOp4 = new Option[18];

    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;

    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public string[] geographyQues;
    public static string geographyFinalAnswer;
    public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[8];
    private Option[] geogOp2 = new Option[8];
    private Option[] geogOp3 = new Option[8];
    private Option[] geogOp4 = new Option[8];

    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public string[] foodQues;
    public static string foodFinalAnswer;
    public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[2];
    private Option[] foodOp2 = new Option[2];
    private Option[] foodOp3 = new Option[2];
    private Option[] foodOp4 = new Option[2];

    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public string[] cultureQues;
    public static string cultureFinalAnswer;
    public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[22];
    private Option[] culOp2 = new Option[22];
    private Option[] culOp3 = new Option[22];
    private Option[] culOp4 = new Option[22];

    public Text cultureQuestonText;
    public Text[] cultureOptionTexts;
    public TextMeshProUGUI cultureScoreText;
    public GameObject cultureCompleteImage;

    /// <summary>
    /// Language Quiz Data
    /// </summary>
    /// 
    public string[] languageQues;
    public static string languageFinalAnswer;
    public static int languageyQuizIndex;

    private Option[] langOp1 = new Option[3];
    private Option[] langOp2 = new Option[3];
    private Option[] langOp3 = new Option[3];
    private Option[] langOp4 = new Option[3];

    public Text languageQuestonText;
    public Text[] languageOptionTexts;
    public TextMeshProUGUI languageScoreText;
    public GameObject languageCompleteImage;


    /// <summary>
    /// General Variables
    /// </summary>
    /// 
    enum answer { wrong, correct };

    public static int selectedCategory = 0;
    public GameObject quizPanel;
    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;

    public BoxCollider door3Col;
    public GameObject congratsPanel;
    public GameObject playerController;


    void Start()
    {
        selectedCategory = 0;
        PlayerPrefs.SetString("SelectedManager", "GR");
    }

    void Update()
    {
        historyScoreText.text = PlayerPrefs.GetInt("GreeceHist") + "/3";
        geographyScoreText.text = PlayerPrefs.GetInt("GreeceGeo") + "/3";
        foodScoreText.text = PlayerPrefs.GetInt("GreeceFood") + "/3";
        cultureScoreText.text = PlayerPrefs.GetInt("GreeceCult") + "/3";
        languageScoreText.text = PlayerPrefs.GetInt("GreeceLang") + "/3";


       

        if (PlayerPrefs.GetInt("GreeceHist") >= 3)
        {
            historyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("GreeceGeo") >= 3)
        {
            geographyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("GreeceFood") >= 3)
        {
            foodCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("GreeceCult") >= 3)
        {
            cultureCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("GreeceLang") >= 3)
        {
            languageCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level3") >= 5)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);
            door3Col.isTrigger = true;
            congratsPanel.SetActive(true);
            playerController.SetActive(false);

           // GameManagers.score = PlayerPrefs.GetInt("Score") + 15;


            //PlayerPrefs.SetInt("Score", GameManagers.score);
            PlayerPrefs.Save();


            // Report a score of 100
            // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
            // of a leaderboard named "Sample Leaderboard"
            GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            //CountDown.timeRemaining = 300f;
            //CountDown.timerIsRunning = true;
            //PlayerPrefs.SetFloat("TimeRemaining", CountDown.timeRemaining);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Level3", 0);
            PlayerPrefs.SetInt("LevelM3", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM3") == 1)
        {
            door3Col.isTrigger = true;

        }
    }

    #region History Quiz Data

    public void SetHistoryQuizData(int index)
    {
        selectedCategory = index;
        SetHistoryOptionData();
        int temp = historyQuizIndex;

        historyQuizIndex = Random.Range(0, 18);

        if (temp == historyQuizIndex)
        {
            historyQuizIndex = Random.Range(0, 18);
        }

        Debug.Log(historyQuizIndex);

        historyQuestonText.text = historyQues[historyQuizIndex];

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

        Option temp1 = FindTagHist(answer.correct.ToString());
        historyFinalAnswer = temp1.answer;

        Debug.Log(historyFinalAnswer);
    }

    private Option FindTagHist(string tagNeeded)
    {
        if (histOp1[historyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return histOp1[historyQuizIndex];
        }
        else if (histOp2[historyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return histOp2[historyQuizIndex];
        }
        else if (histOp3[historyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return histOp3[historyQuizIndex];
        }
        else if (histOp4[historyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return histOp4[historyQuizIndex];
        }
        return null;
    }

    private void SetHistoryOptionData()
    {
        for (int i = 0; i < histOp1.Length; i++)
        {
            histOp1[i] = new Option();
        }
        for (int i = 0; i < histOp2.Length; i++)
        {
            histOp2[i] = new Option();
        }
        for (int i = 0; i < histOp3.Length; i++)
        {
            histOp3[i] = new Option();
        }
        for (int i = 0; i < histOp4.Length; i++)
        {
            histOp4[i] = new Option();
        }


        //Option1 Data17
        histOp1[0].answer = "1896 A.D.";
        histOp1[1].answer = "First";
        histOp1[2].answer = "Modern Greek Kingdom";
        histOp1[3].answer = "Communnism";
        histOp1[4].answer = "Pericles";
        histOp1[5].answer = "40.000";
        histOp1[6].answer = "Proteuousa which means capital city";
        histOp1[7].answer = "At least 50.000";
        histOp1[8].answer = "1600 B.C.";
        histOp1[9].answer = "3";
        histOp1[10].answer = "6.000.000.000";
        histOp1[11].answer = "Gazi";
        histOp1[12].answer = "Battle of Issus";
        histOp1[13].answer = "Battle of Thermopylae";
        histOp1[14].answer = "Battle of Marathon";
        histOp1[15].answer = "1";
        histOp1[16].answer = "1940";
        histOp1[17].answer = "Heptathlon";

        histOp1[0].tag = answer.correct.ToString();
        histOp1[1].tag = answer.wrong.ToString();
        histOp1[2].tag = answer.wrong.ToString();
        histOp1[3].tag = answer.wrong.ToString();
        histOp1[4].tag = answer.correct.ToString();
        histOp1[5].tag = answer.wrong.ToString();
        histOp1[6].tag = answer.wrong.ToString();
        histOp1[7].tag = answer.wrong.ToString();
        histOp1[8].tag = answer.correct.ToString();
        histOp1[9].tag = answer.wrong.ToString();
        histOp1[10].tag = answer.wrong.ToString();
        histOp1[11].tag = answer.wrong.ToString();
        histOp1[12].tag = answer.wrong.ToString();
        histOp1[13].tag = answer.wrong.ToString();
        histOp1[14].tag = answer.wrong.ToString();
        histOp1[15].tag = answer.correct.ToString();
        histOp1[16].tag = answer.wrong.ToString();
        histOp1[17].tag = answer.wrong.ToString();

        //Option2 Data
        histOp2[0].answer = "#776 B.C.";
        histOp2[1].answer = "#Second#";
        histOp2[2].answer = "Ottoman Empire";
        histOp2[3].answer = "Oligarchy";
        histOp2[4].answer = "Alexander the Great";
        histOp2[5].answer = "##400.000";
        histOp2[6].answer = "Klinon Asti which means glorious city###";
        histOp2[7].answer = "At least 3.000#";
        histOp2[8].answer = "#160 B.C.";
        histOp2[9].answer = "#1";
        histOp2[10].answer = "4.000.000#";
        histOp2[11].answer = "#Syntagma";
        histOp2[12].answer = " Battle of the Granicus River";
        histOp2[13].answer = "#Battle of Issus#";
        histOp2[14].answer = "Battle of Thermopylae";
        histOp2[15].answer = "2";
        histOp2[16].answer = "#1920";
        histOp2[17].answer = "Marathon";


        histOp2[0].tag = answer.wrong.ToString();
        histOp2[1].tag = answer.wrong.ToString();
        histOp2[2].tag = answer.correct.ToString();
        histOp2[3].tag = answer.wrong.ToString();
        histOp2[4].tag = answer.wrong.ToString();
        histOp2[5].tag = answer.wrong.ToString();
        histOp2[6].tag = answer.correct.ToString();
        histOp2[7].tag = answer.wrong.ToString();
        histOp2[8].tag = answer.wrong.ToString();
        histOp2[9].tag = answer.wrong.ToString();
        histOp2[10].tag = answer.correct.ToString();
        histOp2[11].tag = answer.wrong.ToString();
        histOp2[12].tag = answer.wrong.ToString();
        histOp2[13].tag = answer.wrong.ToString();
        histOp2[14].tag = answer.correct.ToString();
        histOp2[15].tag = answer.wrong.ToString();
        histOp2[16].tag = answer.wrong.ToString();
        histOp2[17].tag = answer.correct.ToString();


        //Option3 Data
        histOp3[0].answer = "#2004 A.D.";
        histOp3[1].answer = "Third";
        histOp3[2].answer = "#Nazi Occupation";
        histOp3[3].answer = "Monarchy";
        histOp3[4].answer = "Odysseus";
        histOp3[5].answer = "4.000";
        histOp3[6].answer = "Polis which means city";
        histOp3[7].answer = "At least 10.000";
        histOp3[8].answer = "#16.000 B.C.";
        histOp3[9].answer = "2";
        histOp3[10].answer = "2.000.000";
        histOp3[11].answer = "#Metaxourgeio";
        histOp3[12].answer = "#Battle of Marathon";
        histOp3[13].answer = "Battle of Marathon# ";
        histOp3[14].answer = "# Battle of the Granicus River";
        histOp3[15].answer = "3";
        histOp3[16].answer = "#1840";
        histOp3[17].answer = "#Pentathlon";

        histOp3[0].tag = answer.wrong.ToString();
        histOp3[1].tag = answer.correct.ToString();
        histOp3[2].tag = answer.wrong.ToString();
        histOp3[3].tag = answer.wrong.ToString();
        histOp3[4].tag = answer.wrong.ToString();
        histOp3[5].tag = answer.correct.ToString();
        histOp3[6].tag = answer.wrong.ToString();
        histOp3[7].tag = answer.wrong.ToString();
        histOp3[8].tag = answer.wrong.ToString();
        histOp3[9].tag = answer.correct.ToString();
        histOp3[10].tag = answer.wrong.ToString();
        histOp3[11].tag = answer.wrong.ToString();
        histOp3[12].tag = answer.wrong.ToString();
        histOp3[13].tag = answer.correct.ToString();
        histOp3[14].tag = answer.wrong.ToString();
        histOp3[15].tag = answer.wrong.ToString();
        histOp3[16].tag = answer.correct.ToString();
        histOp3[17].tag = answer.wrong.ToString();

        //Option4 Data
        histOp4[0].answer = "#344 B.C.";
        histOp4[1].answer = "Fourth";
        histOp4[2].answer = "#Greek dictatorship";
        histOp4[3].answer = "Democracy";
        histOp4[4].answer = "Plato";
        histOp4[5].answer = "#4.000.000";
        histOp4[6].answer = "Hyper Polis which means great city";
        histOp4[7].answer = "At least 5.000#";
        histOp4[8].answer = "#160.000 B.C.";
        histOp4[9].answer = "#never";
        histOp4[10].answer = "#8.000.000";
        histOp4[11].answer = "Omonoia";
        histOp4[12].answer = "Battle of Salamis";
        histOp4[13].answer = "Battle of the Granicus River";
        histOp4[14].answer = "#Battle of Issus";
        histOp4[15].answer = "4";
        histOp4[16].answer = "##1880";
        histOp4[17].answer = "Decathlon";

        histOp4[0].tag = answer.wrong.ToString();
        histOp4[1].tag = answer.wrong.ToString();
        histOp4[2].tag = answer.wrong.ToString();
        histOp4[3].tag = answer.correct.ToString();
        histOp4[4].tag = answer.wrong.ToString();
        histOp4[5].tag = answer.wrong.ToString();
        histOp4[6].tag = answer.wrong.ToString();
        histOp4[7].tag = answer.correct.ToString();
        histOp4[8].tag = answer.wrong.ToString();
        histOp4[9].tag = answer.wrong.ToString();
        histOp4[10].tag = answer.wrong.ToString();
        histOp4[11].tag = answer.correct.ToString();
        histOp4[12].tag = answer.correct.ToString();
        histOp4[13].tag = answer.wrong.ToString();
        histOp4[14].tag = answer.wrong.ToString();
        histOp4[15].tag = answer.wrong.ToString();
        histOp4[16].tag = answer.wrong.ToString();
        histOp4[17].tag = answer.wrong.ToString();
    }

    

    #endregion

    #region Geography Quiz Data

    public void SetGeographyQuizData(int index)
    {
        selectedCategory = index;
        SetGeographyOptionData();

        int temp = geographyQuizIndex;

        geographyQuizIndex = Random.Range(0, 8);

        if (temp == geographyQuizIndex)
        {
            geographyQuizIndex = Random.Range(0, 8);
        }

        Debug.Log(geographyQuizIndex);

        geographyQuestonText.text = geographyQues[geographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
        geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;

        Option temp1 = FindTagGeo(answer.correct.ToString());
        geographyFinalAnswer = temp1.answer;

        Debug.Log(geographyFinalAnswer);
    }

    private Option FindTagGeo(string tagNeeded)
    {
        if (geogOp1[geographyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return geogOp1[geographyQuizIndex];
        }
        else if (geogOp2[geographyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return geogOp2[geographyQuizIndex];
        }
        else if (geogOp3[geographyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return geogOp3[geographyQuizIndex];
        }
        else if (geogOp4[geographyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return geogOp4[geographyQuizIndex];
        }
        return null;
    }
    private void SetGeographyOptionData()
    {
        for (int i = 0; i < geogOp1.Length; i++)
        {
            geogOp1[i] = new Option();
        }
        for (int i = 0; i < geogOp2.Length; i++)
        {
            geogOp2[i] = new Option();
        }
        for (int i = 0; i < geogOp3.Length; i++)
        {
            geogOp3[i] = new Option();
        }
        for (int i = 0; i < geogOp4.Length; i++)
        {
            geogOp4[i] = new Option();
        }


        //Option1 Data
        geogOp1[0].answer = "Greece";
        geogOp1[1].answer = "#Mount Hymmetus";
        geogOp1[2].answer = "#114";
        geogOp1[3].answer = "#9.000";
        geogOp1[4].answer = "#3.312";
        geogOp1[5].answer = "#3.478";
        geogOp1[6].answer = "#Chalkida";
        geogOp1[7].answer = "#Koumoundourou";


        geogOp1[0].tag = answer.correct.ToString();
        geogOp1[1].tag = answer.wrong.ToString();
        geogOp1[2].tag = answer.wrong.ToString();
        geogOp1[3].tag = answer.wrong.ToString();
        geogOp1[4].tag = answer.wrong.ToString();
        geogOp1[5].tag = answer.wrong.ToString();
        geogOp1[6].tag = answer.wrong.ToString();
        geogOp1[7].tag = answer.wrong.ToString();


        //Option2 Data
        geogOp2[0].answer = "#Italy";
        geogOp2[1].answer = "Mount Parnitha";
        geogOp2[2].answer = "#424";
        geogOp2[3].answer = "#13.000";
        geogOp2[4].answer = "2.917";
        geogOp2[5].answer = "#1.993";
        geogOp2[6].answer = "#Lavrio";
        geogOp2[7].answer = "#Mpeletsi";


        geogOp2[0].tag = answer.wrong.ToString();
        geogOp2[1].tag = answer.correct.ToString();
        geogOp2[2].tag = answer.wrong.ToString();
        geogOp2[3].tag = answer.wrong.ToString();
        geogOp2[4].tag = answer.correct.ToString();
        geogOp2[5].tag = answer.wrong.ToString();
        geogOp2[6].tag = answer.wrong.ToString();
        geogOp2[7].tag = answer.wrong.ToString();


        //Option3 Data
        geogOp3[0].answer = "#Cyprus";
        geogOp3[1].answer = "#Mount Aigaleo";
        geogOp3[2].answer = "#38";
        geogOp3[3].answer = "6.000";
        geogOp3[4].answer = "#4.127";
        geogOp3[5].answer = "2.773";
        geogOp3[6].answer = "#Rafina";
        geogOp3[7].answer = "#Vouliagmenis";


        geogOp3[0].tag = answer.wrong.ToString();
        geogOp3[1].tag = answer.wrong.ToString();
        geogOp3[2].tag = answer.wrong.ToString();
        geogOp3[3].tag = answer.correct.ToString();
        geogOp3[4].tag = answer.wrong.ToString();
        geogOp3[5].tag = answer.correct.ToString();
        geogOp3[6].tag = answer.wrong.ToString();
        geogOp3[7].tag = answer.wrong.ToString();


        //Option4 Data
        geogOp4[0].answer = "#Israel";
        geogOp4[1].answer = "#Mount Pentelicus";
        geogOp4[2].answer = "53";
        geogOp4[3].answer = "#2.000";
        geogOp4[4].answer = "#1.998";
        geogOp4[5].answer = "#2.147";
        geogOp4[6].answer = "Pireus";
        geogOp4[7].answer = "Marathona";


        geogOp4[0].tag = answer.wrong.ToString();
        geogOp4[1].tag = answer.wrong.ToString();
        geogOp4[2].tag = answer.correct.ToString();
        geogOp4[3].tag = answer.wrong.ToString();
        geogOp4[4].tag = answer.wrong.ToString();
        geogOp4[5].tag = answer.wrong.ToString();
        geogOp4[6].tag = answer.correct.ToString();
        geogOp4[7].tag = answer.correct.ToString();

    }


    #endregion

    #region Food Quiz Data

    public void SetFoodQuizData(int index)
    {
        selectedCategory = index;

        SetFoodOptionData();

        int temp = foodQuizIndex;

        foodQuizIndex = Random.Range(0, 2);

        if (temp == foodQuizIndex)
        {
            foodQuizIndex = Random.Range(0, 2);
        }

        Debug.Log(foodQuizIndex);

        foodQuestonText.text = foodQues[foodQuizIndex];

        foodOptionTexts[0].text = foodOp1[foodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[foodQuizIndex].answer;
        foodOptionTexts[2].text = foodOp3[foodQuizIndex].answer;
        foodOptionTexts[3].text = foodOp4[foodQuizIndex].answer;

        Option temp1 = FindTagFood(answer.correct.ToString());
        foodFinalAnswer = temp1.answer;

        Debug.Log(foodFinalAnswer);
    }

    private Option FindTagFood(string tagNeeded)
    {
        if (foodOp1[foodQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return foodOp1[foodQuizIndex];
        }
        else if (foodOp2[foodQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return foodOp2[foodQuizIndex];
        }
        else if (foodOp3[foodQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return foodOp3[foodQuizIndex];
        }
        else if (foodOp4[foodQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return foodOp4[foodQuizIndex];
        }
        return null;
    }

    private void SetFoodOptionData()
    {
        for (int i = 0; i < foodOp1.Length; i++)
        {
            foodOp1[i] = new Option();
        }
        for (int i = 0; i < foodOp2.Length; i++)
        {
            foodOp2[i] = new Option();
        }
        for (int i = 0; i < foodOp3.Length; i++)
        {
            foodOp3[i] = new Option();
        }
        for (int i = 0; i < foodOp4.Length; i++)
        {
            foodOp4[i] = new Option();
        }


        //Option1 Data
        foodOp1[0].answer = "#Tzatziki";
        foodOp1[1].answer = "#flour";


        foodOp1[0].tag = answer.wrong.ToString();
        foodOp1[1].tag = answer.wrong.ToString();


        //Option2 Data
        foodOp2[0].answer = "Soulvaki";
        foodOp2[1].answer = "#nuts";


        foodOp2[0].tag = answer.correct.ToString();
        foodOp2[1].tag = answer.wrong.ToString();


        //Option3 Data
        foodOp3[0].answer = "#Kalamaraki";
        foodOp3[1].answer = "fruit";


        foodOp3[0].tag = answer.wrong.ToString();
        foodOp3[1].tag = answer.correct.ToString();


        //Option4 Data
        foodOp4[0].answer = "#Keftedaki";
        foodOp4[1].answer = "#chocolate";


        foodOp4[0].tag = answer.wrong.ToString();
        foodOp4[1].tag = answer.wrong.ToString();

    }

   




    #endregion

    #region Culture Quiz Data

    public void SetCultureQuizData(int index)
    {
        selectedCategory = index;

        SetCultureOptionData();
        int temp = cultureQuizIndex;

        cultureQuizIndex = Random.Range(0, 22);

        if (temp == cultureQuizIndex)
        {
            cultureQuizIndex = Random.Range(0, 22);
        }

        Debug.Log(cultureQuizIndex);

        cultureQuestonText.text = cultureQues[cultureQuizIndex];

        cultureOptionTexts[0].text = culOp1[cultureQuizIndex].answer;
        cultureOptionTexts[1].text = culOp2[cultureQuizIndex].answer;
        cultureOptionTexts[2].text = culOp3[cultureQuizIndex].answer;
        cultureOptionTexts[3].text = culOp4[cultureQuizIndex].answer;

        Option temp1 = FindTagCul(answer.correct.ToString());
        cultureFinalAnswer = temp1.answer;

        Debug.Log(cultureFinalAnswer);
    }

    private Option FindTagCul(string tagNeeded)
    {
        if (culOp1[cultureQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return culOp1[cultureQuizIndex];
        }
        else if (culOp2[cultureQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return culOp2[cultureQuizIndex];
        }
        else if (culOp3[cultureQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return culOp3[cultureQuizIndex];
        }
        else if (culOp4[cultureQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return culOp4[cultureQuizIndex];
        }
        return null;
    }
    private void SetCultureOptionData()
    {
        for (int i = 0; i < culOp1.Length; i++)
        {
            culOp1[i] = new Option();
        }
        for (int i = 0; i < culOp2.Length; i++)
        {
            culOp2[i] = new Option();
        }
        for (int i = 0; i < culOp3.Length; i++)
        {
            culOp3[i] = new Option();
        }
        for (int i = 0; i < culOp4.Length; i++)
        {
            culOp4[i] = new Option();
        }


        //Option1 Data
        culOp1[0].answer = "Tower of Athens";
        culOp1[1].answer = "#Aphrodite";
        culOp1[2].answer = "Stadium of Athena";
        culOp1[3].answer = "#From the words thletics which means sports and nike which means victory";
        culOp1[4].answer = "#King Phillip of Greece";
        culOp1[5].answer = "#Red";
        culOp1[6].answer = "#Olympiakos";
        culOp1[7].answer = "1985";
        culOp1[8].answer = "#5";
        culOp1[9].answer = "#Vaggelis Papathanasiou";
        culOp1[10].answer = "#Cadmus";
        culOp1[11].answer = "1";
        culOp1[12].answer = "Elena Paparizou";
        culOp1[13].answer = "#2003";
        culOp1[14].answer = "#Strength and Prosperity";
        culOp1[15].answer = "#Our Beautiful Homeland";
        culOp1[16].answer = "#Islam Sunni";
        culOp1[17].answer = "#Yellow and white";
        culOp1[18].answer = "#Panathinaikos";
        culOp1[19].answer = "Elytis";
        culOp1[20].answer = "##Palamas";
        culOp1[21].answer = "#1976";
   

        culOp1[0].tag = answer.correct.ToString();
        culOp1[1].tag = answer.wrong.ToString();
        culOp1[2].tag = answer.wrong.ToString();
        culOp1[3].tag = answer.wrong.ToString();
        culOp1[4].tag = answer.wrong.ToString();
        culOp1[5].tag = answer.wrong.ToString();
        culOp1[6].tag = answer.wrong.ToString();
        culOp1[7].tag = answer.correct.ToString();
        culOp1[8].tag = answer.wrong.ToString();
        culOp1[9].tag = answer.wrong.ToString();
        culOp1[10].tag = answer.wrong.ToString();
        culOp1[11].tag = answer.correct.ToString();
        culOp1[12].tag = answer.correct.ToString();
        culOp1[13].tag = answer.wrong.ToString();
        culOp1[14].tag = answer.wrong.ToString();
        culOp1[15].tag = answer.wrong.ToString();
        culOp1[16].tag = answer.wrong.ToString();
        culOp1[17].tag = answer.wrong.ToString();
        culOp1[18].tag = answer.wrong.ToString();
        culOp1[19].tag = answer.correct.ToString();
        culOp1[20].tag = answer.wrong.ToString();
        culOp1[21].tag = answer.wrong.ToString();
        

        //Option2 Data
        culOp2[0].answer = "#Parthenon";
        culOp2[1].answer = "Poseidon";
        culOp2[2].answer = "#Agora#";
        culOp2[3].answer = "#From the name of the leader of Amazons, Athena";
        culOp2[4].answer = "#Hellenico";
        culOp2[5].answer = "#Yellow";
        culOp2[6].answer = "Panathinaikos";
        culOp2[7].answer = "#1990";
        culOp2[8].answer = "3";
        culOp2[9].answer = "#Eleftherios Spanoudakis";
        culOp2[10].answer = "#Perseus";
        culOp2[11].answer = "#2";
        culOp2[12].answer = "#Kalomoira";
        culOp2[13].answer = "#2002";
        culOp2[14].answer = "#In God we trust";
        culOp2[15].answer = "Hymn to Liberty";
        culOp2[16].answer = "#Islam Shia";
        culOp2[17].answer = "#Red and white";
        culOp2[18].answer = "AEK";
        culOp2[19].answer = "#Cavafis";
        culOp2[20].answer = "#Ritsos";
        culOp2[21].answer = "1996";
        

        culOp2[0].tag = answer.wrong.ToString();
        culOp2[1].tag = answer.correct.ToString();
        culOp2[2].tag = answer.wrong.ToString();
        culOp2[3].tag = answer.wrong.ToString();
        culOp2[4].tag = answer.wrong.ToString();
        culOp2[5].tag = answer.wrong.ToString();
        culOp2[6].tag = answer.correct.ToString();
        culOp2[7].tag = answer.wrong.ToString();
        culOp2[8].tag = answer.correct.ToString();
        culOp2[9].tag = answer.wrong.ToString();
        culOp2[10].tag = answer.wrong.ToString();
        culOp2[11].tag = answer.wrong.ToString();
        culOp2[12].tag = answer.wrong.ToString();
        culOp2[13].tag = answer.wrong.ToString();
        culOp2[14].tag = answer.wrong.ToString();
        culOp2[15].tag = answer.correct.ToString();
        culOp2[16].tag = answer.wrong.ToString();
        culOp2[17].tag = answer.wrong.ToString();
        culOp2[18].tag = answer.correct.ToString();
        culOp2[19].tag = answer.wrong.ToString();
        culOp2[20].tag = answer.wrong.ToString();
        culOp2[21].tag = answer.correct.ToString();
        


        //Option3 Data
        culOp3[0].answer = "#Greek Telecommunication Company Tower";
        culOp3[1].answer = "#Zeus";
        culOp3[2].answer = "Parthenon";
        culOp3[3].answer = "#From the Greek words ATHLOS which means achievement and ENA which means one";
        culOp3[4].answer = "#George Papanikolaou";
        culOp3[5].answer = "Green";
        culOp3[6].answer = "#A.E.K.";
        culOp3[7].answer = "#1995";
        culOp3[8].answer = "#4";
        culOp3[9].answer = "#Mikis Theodorakis";
        culOp3[10].answer = "Theseus";
        culOp3[11].answer = "#3";
        culOp3[12].answer = "#Kaiti Garbi";
        culOp3[13].answer = "2000";
        culOp3[14].answer = "#Progress and Prosperityr";
        culOp3[15].answer = "#Song of the Greeks";
        culOp3[16].answer = "#Christian Catholic";
        culOp3[17].answer = "Blue and white";
        culOp3[18].answer = "#Panionios";
        culOp3[19].answer = "#Ritsos";
        culOp3[20].answer = "##Cavafis";
        culOp3[21].answer = "#2006";
        

        culOp3[0].tag = answer.wrong.ToString();
        culOp3[1].tag = answer.wrong.ToString();
        culOp3[2].tag = answer.correct.ToString();
        culOp3[3].tag = answer.wrong.ToString();
        culOp3[4].tag = answer.wrong.ToString();
        culOp3[5].tag = answer.correct.ToString();
        culOp3[6].tag = answer.wrong.ToString();
        culOp3[7].tag = answer.wrong.ToString();
        culOp3[8].tag = answer.wrong.ToString();
        culOp3[9].tag = answer.wrong.ToString();
        culOp3[10].tag = answer.correct.ToString();
        culOp3[11].tag = answer.wrong.ToString();
        culOp3[12].tag = answer.wrong.ToString();
        culOp3[13].tag = answer.correct.ToString();
        culOp3[14].tag = answer.wrong.ToString();
        culOp3[15].tag = answer.wrong.ToString();
        culOp3[16].tag = answer.wrong.ToString();
        culOp3[17].tag = answer.correct.ToString();
        culOp3[18].tag = answer.wrong.ToString();
        culOp3[19].tag = answer.wrong.ToString();
        culOp3[20].tag = answer.wrong.ToString();
        culOp3[21].tag = answer.wrong.ToString();
        

        //Option4 Data
        culOp4[0].answer = "#Tower of Piraeus";
        culOp4[1].answer = "#Ares";
        culOp4[2].answer = "#Arena";
        culOp4[3].answer = "From the godess Athena";
        culOp4[4].answer = "Eleftherios Venizelos";
        culOp4[5].answer = "#Blue";
        culOp4[6].answer = "#P.A.O.K.";
        culOp4[7].answer = "#1980";
        culOp4[8].answer = "#2";
        culOp4[9].answer = "Manos Chatzidakis";
        culOp4[10].answer = "#Hercules";
        culOp4[11].answer = "#4";
        culOp4[12].answer = "#Demy";
        culOp4[13].answer = "#2001";
        culOp4[14].answer = "Freedom or Death";
        culOp4[15].answer = "#God Bless Greece";
        culOp4[16].answer = "Christian Orthodoxy";
        culOp4[17].answer = "#Blue and yellow";
        culOp4[18].answer = "#Olympiakos";
        culOp4[19].answer = "#Palamas";
        culOp4[20].answer = "Elytis";
        culOp4[21].answer = "#1986";
        

        culOp4[0].tag = answer.wrong.ToString();
        culOp4[1].tag = answer.wrong.ToString();
        culOp4[2].tag = answer.wrong.ToString();
        culOp4[3].tag = answer.correct.ToString();
        culOp4[4].tag = answer.correct.ToString();
        culOp4[5].tag = answer.wrong.ToString();
        culOp4[6].tag = answer.wrong.ToString();
        culOp4[7].tag = answer.wrong.ToString();
        culOp4[8].tag = answer.wrong.ToString();
        culOp4[9].tag = answer.correct.ToString();
        culOp4[10].tag = answer.wrong.ToString();
        culOp4[11].tag = answer.wrong.ToString();
        culOp4[12].tag = answer.wrong.ToString();
        culOp4[13].tag = answer.wrong.ToString();
        culOp4[14].tag = answer.correct.ToString();
        culOp4[15].tag = answer.wrong.ToString();
        culOp4[16].tag = answer.correct.ToString();
        culOp4[17].tag = answer.wrong.ToString();
        culOp4[18].tag = answer.wrong.ToString();
        culOp4[19].tag = answer.wrong.ToString();
        culOp4[20].tag = answer.correct.ToString();
        culOp4[21].tag = answer.wrong.ToString();
        
    }

  



    #endregion
    
    #region Language Quiz Data

    public void SetLanguageQuizData(int index)
    {
        selectedCategory = index;

        SetLanguageOptionData();
        int temp = languageyQuizIndex;

        languageyQuizIndex = Random.Range(0, 3);

        if (temp == languageyQuizIndex)
        {
            languageyQuizIndex = Random.Range(0, 3);
        }

        Debug.Log(languageyQuizIndex);

        languageQuestonText.text = languageQues[languageyQuizIndex];

        languageOptionTexts[0].text = langOp1[languageyQuizIndex].answer;
        languageOptionTexts[1].text = langOp2[languageyQuizIndex].answer;
        languageOptionTexts[2].text = langOp3[languageyQuizIndex].answer;
        languageOptionTexts[3].text = langOp4[languageyQuizIndex].answer;

        Option temp1 = FindTagLang(answer.correct.ToString());
        languageFinalAnswer = temp1.answer;

        Debug.Log(languageFinalAnswer);
    }

    private Option FindTagLang(string tagNeeded)
    {
        if (langOp1[languageyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return langOp1[languageyQuizIndex];
        }
        else if (langOp2[languageyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return langOp2[languageyQuizIndex];
        }
        else if (langOp3[languageyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return langOp3[languageyQuizIndex];
        }
        else if (langOp4[languageyQuizIndex].tag.Equals(tagNeeded) == true)
        {
            return langOp4[languageyQuizIndex];
        }
        return null;
    }
    private void SetLanguageOptionData()
    {
        for (int i = 0; i < langOp1.Length; i++)
        {
            langOp1[i] = new Option();
        }
        for (int i = 0; i < langOp2.Length; i++)
        {
            langOp2[i] = new Option();
        }
        for (int i = 0; i < langOp3.Length; i++)
        {
            langOp3[i] = new Option();
        }
        for (int i = 0; i < langOp4.Length; i++)
        {
            langOp4[i] = new Option();
        }


        //Option1 Data
        langOp1[0].answer = "#White";
        langOp1[1].answer = "#Power";
        langOp1[2].answer = "5.000";


        langOp1[0].tag = answer.wrong.ToString();
        langOp1[1].tag = answer.wrong.ToString();
        langOp1[2].tag = answer.correct.ToString();
;

        //Option2 Data
        langOp2[0].answer = "Kallimarmaro ";
        langOp2[1].answer = "#Protection";
        langOp2[2].answer = "#10.000";


        langOp2[0].tag = answer.correct.ToString();
        langOp2[1].tag = answer.wrong.ToString();
        langOp2[2].tag = answer.wrong.ToString();


        //Option3 Data
        langOp3[0].answer = "#Olympic";
        langOp3[1].answer = "#Fair";
        langOp3[2].answer = "#13.000";


        langOp3[0].tag = answer.wrong.ToString();
        langOp3[1].tag = answer.wrong.ToString();
        langOp3[2].tag = answer.wrong.ToString();


        //Option4 Data
        langOp4[0].answer = "#Hellinikon";
        langOp4[1].answer = "Virgin";
        langOp4[2].answer = "#3.000";


        langOp4[0].tag = answer.wrong.ToString();
        langOp4[1].tag = answer.correct.ToString();
        langOp4[2].tag = answer.wrong.ToString();

    }

    




    #endregion


    #region Common Functions

   
    public class Option
    {
        public string answer;
        public string tag;
    }

    public void ResetQuestionaPanel()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") == 3)
        {
            if (selectedCategory == 1)
            {
                SetHistoryQuizData(1);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 2)
            {
                SetGeographyQuizData(2);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 3)
            {
                SetFoodQuizData(3);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 4)
            {
                SetCultureQuizData(4);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 5)
            {
                SetLanguageQuizData(5);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else
            {
                //CountDown.timeRemaining = 300f;
                //CountDown.timerIsRunning = true;
                //PlayerPrefs.SetFloat("TimeRemaining", CountDown.timeRemaining);
                PlayerPrefs.Save();
            }
        }
    }


    public void AnswerBtnClick(Text text)
    {

        if (selectedCategory == 1)
        {
            if (text.text.Equals(historyFinalAnswer) == true)
            {
                Debug.Log("Correct History Answer Selected");
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
            }
            else
            {
                Debug.Log("Wrong History Answer Selected");
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
            }
        }
        else if (selectedCategory == 2)
        {
            if (text.text.Equals(geographyFinalAnswer) == true)
            {
                Debug.Log("Correct geography Answer Selected");
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
            }
            else
            {
                Debug.Log("Wrong geography Answer Selected");
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
            }
        }
        else if (selectedCategory == 3)
        {
            if (text.text.Equals(foodFinalAnswer) == true)
            {
                Debug.Log("Correct food Answer Selected");
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
            }
            else
            {
                Debug.Log("Wrong food Answer Selected");
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
            }
        }
        else if (selectedCategory == 4)
        {
            if (text.text.Equals(cultureFinalAnswer) == true)
            {
                Debug.Log("Correct culture Answer Selected");
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
            }
            else
            {
                Debug.Log("Wrong culture Answer Selected");
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
            }
        }
        else if (selectedCategory == 5)
        {
            if (text.text.Equals(languageFinalAnswer) == true)
            {
                Debug.Log("Correct language Answer Selected");
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
            }
            else
            {
                Debug.Log("Wrong language Answer Selected");
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
            }
        }
    }

    IEnumerator CorrectAnswerWait()
    {
        yield return new WaitForSeconds(1f);
        Answerdecision.text = "";
        if(selectedCategory == 1)
        {
            if (PlayerPrefs.GetInt("GreeceHist", 0) <= 3)
            {
                PlayerPrefs.SetInt("GreeceHist", (PlayerPrefs.GetInt("GreeceHist")) + 1);
                PlayerPrefs.Save();

                SetHistoryQuizData(1);

                if (PlayerPrefs.GetInt("GreeceHist", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if(selectedCategory == 2)
        {
            if (PlayerPrefs.GetInt("GreeceGeo", 0) <= 3)
            {
                PlayerPrefs.SetInt("GreeceGeo", (PlayerPrefs.GetInt("GreeceGeo")) + 1);
                PlayerPrefs.Save();

                SetGeographyQuizData(2);

                if (PlayerPrefs.GetInt("GreeceGeo", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 3)
        {
            if (PlayerPrefs.GetInt("GreeceFood", 0) <= 3)
            {
                PlayerPrefs.SetInt("GreeceFood", (PlayerPrefs.GetInt("GreeceFood")) + 1);
                PlayerPrefs.Save();

                SetFoodQuizData(3);

                if (PlayerPrefs.GetInt("GreeceFood", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 4)
        {
            if (PlayerPrefs.GetInt("GreeceCult", 0) <= 3)
            {
                PlayerPrefs.SetInt("GreeceCult", (PlayerPrefs.GetInt("GreeceCult")) + 1);
                PlayerPrefs.Save();

                SetCultureQuizData(4);

                if (PlayerPrefs.GetInt("GreeceCult", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 5)
        {
            if (PlayerPrefs.GetInt("GreeceLang", 0) <= 3)
            {
                PlayerPrefs.SetInt("GreeceLang", (PlayerPrefs.GetInt("GreeceLang")) + 1);
                PlayerPrefs.Save();

                SetLanguageQuizData(5);

                if (PlayerPrefs.GetInt("GreeceLang", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
    }
    IEnumerator WrongAnswerwait()
    {
        yield return new WaitForSeconds(1f);
        Answerdecision.text = "";
        if (selectedCategory <= 5)
        {
            levelFailPanel.SetActive(true);
            quizPanel.SetActive(false);
        }
    }

    #endregion
}
