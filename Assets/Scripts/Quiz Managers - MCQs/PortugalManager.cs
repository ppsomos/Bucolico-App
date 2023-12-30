using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortugalManager : MonoBehaviour
{
    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public string[] historyQues;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[10];
    private Option[] histOp2 = new Option[10];
    private Option[] histOp3 = new Option[10];
    private Option[] histOp4 = new Option[10];

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

    private Option[] geogOp1 = new Option[10];
    private Option[] geogOp2 = new Option[10];
    private Option[] geogOp3 = new Option[10];
    private Option[] geogOp4 = new Option[10];

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

    private Option[] foodOp1 = new Option[10];
    private Option[] foodOp2 = new Option[10];
    private Option[] foodOp3 = new Option[10];
    private Option[] foodOp4 = new Option[10];

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

    private Option[] culOp1 = new Option[10];
    private Option[] culOp2 = new Option[10];
    private Option[] culOp3 = new Option[10];
    private Option[] culOp4 = new Option[10];

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

    private Option[] langOp1 = new Option[10];
    private Option[] langOp2 = new Option[10];
    private Option[] langOp3 = new Option[10];
    private Option[] langOp4 = new Option[10];

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

    public GameObject congratsPanel;
    public GameObject playerController;


    void Start()
    {
        selectedCategory = 0;
        playerController.SetActive(true);
    }

    void Update()
    {
        historyScoreText.text = PlayerPrefs.GetInt("PortugalHist") + "/3";
        geographyScoreText.text = PlayerPrefs.GetInt("PortugalGeo") + "/3";
        foodScoreText.text = PlayerPrefs.GetInt("PortugalFood") + "/3";
        cultureScoreText.text = PlayerPrefs.GetInt("PortugalCult") + "/3";
        languageScoreText.text = PlayerPrefs.GetInt("PortugalLang") + "/3";

         

        if (PlayerPrefs.GetInt("PortugalHist") >= 3)
        {
            historyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalGeo") >= 3)
        {
            geographyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalFood") >= 3)
        {
            foodCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalCult") >= 3)
        {
            cultureCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalLang") >= 3)
        {
            languageCompleteImage.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level5") >= 5)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);
            congratsPanel.SetActive(true);
            playerController.SetActive(false);

            //GameManagers.score = PlayerPrefs.GetInt("Score") + 15;

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

            PlayerPrefs.SetInt("Level5", 0);
            PlayerPrefs.SetInt("LevelM5", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM5") == 1)
        {
//            door4Col.isTrigger = true;

        }
    }

    #region History Quiz Data

    public void SetHistoryQuizData(int index)
    {
        selectedCategory = index;

        SetHistoryOptionData();
        int temp = historyQuizIndex;

        historyQuizIndex = Random.Range(0, 10);

        if (temp == historyQuizIndex)
        {
            historyQuizIndex = Random.Range(0, 10);
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


        //Option1 Data
        histOp1[0].answer = "Carnation Revolution";
        histOp1[1].answer = "Cape Verde";
        histOp1[2].answer = "#1901";
        histOp1[3].answer = "#Antique market";
        histOp1[4].answer = "#Christopher Columbus";
        histOp1[5].answer = "#2010";
        histOp1[6].answer = "University of Coimbra";
        histOp1[7].answer = "A hurricane";
        histOp1[8].answer = "Fish bones";
        histOp1[9].answer = "1249";
        histOp1[10].answer = "Municipal Elections";
        histOp1[11].answer = "Democratic Republic";
        histOp1[12].answer = "#Obidos Castel";
        histOp1[13].answer = "#Iron gates#";
        histOp1[14].answer = "Silves";
        histOp1[15].answer = "Macau";
        histOp1[16].answer = "Coimbra";


        histOp1[0].tag = answer.correct.ToString();
        histOp1[1].tag = answer.wrong.ToString();
        histOp1[2].tag = answer.wrong.ToString();
        histOp1[3].tag = answer.wrong.ToString();
        histOp1[4].tag = answer.wrong.ToString();
        histOp1[5].tag = answer.wrong.ToString();
        histOp1[6].tag = answer.correct.ToString();
        histOp1[7].tag = answer.wrong.ToString();
        histOp1[8].tag = answer.wrong.ToString();
        histOp1[9].tag = answer.wrong.ToString();
        histOp1[10].tag = answer.correct.ToString();
        histOp1[11].tag = answer.correct.ToString();
        histOp1[12].tag = answer.wrong.ToString();
        histOp1[13].tag = answer.wrong.ToString();
        histOp1[14].tag = answer.wrong.ToString();
        histOp1[15].tag = answer.wrong.ToString();
        histOp1[16].tag = answer.wrong.ToString();

        //Option2 Data
        histOp2[0].answer = "Orange Revolution";
        histOp2[1].answer = "#Angola";
        histOp2[2].answer = "1910";
        histOp2[3].answer = "#Fish market";
        histOp2[4].answer = "Vasco Da Gama";
        histOp2[5].answer = "#2008";
        histOp2[6].answer = "#University of Porto";
        histOp2[7].answer = "#A flood";
        histOp2[8].answer = "#Cattle bones";
        histOp2[9].answer = "#1212";
        histOp2[10].answer = "#Presidential Elections";
        histOp2[11].answer = "#Presidential Republic";
        histOp2[12].answer = "S.Jorge castle";
        histOp2[13].answer = "A line of towers";
        histOp2[14].answer = "Sagres#";
        histOp2[15].answer = "East Timor";
        histOp2[16].answer = "#Aveiro#";

        histOp2[0].tag = answer.wrong.ToString();
        histOp2[1].tag = answer.wrong.ToString();
        histOp2[2].tag = answer.correct.ToString();
        histOp2[3].tag = answer.wrong.ToString();
        histOp2[4].tag = answer.correct.ToString();
        histOp2[5].tag = answer.wrong.ToString();
        histOp2[6].tag = answer.wrong.ToString();
        histOp2[7].tag = answer.wrong.ToString();
        histOp2[8].tag = answer.wrong.ToString();
        histOp2[9].tag = answer.wrong.ToString();
        histOp2[10].tag = answer.wrong.ToString();
        histOp2[11].tag = answer.wrong.ToString();
        histOp2[12].tag = answer.correct.ToString();
        histOp2[13].tag = answer.correct.ToString();
        histOp2[14].tag = answer.wrong.ToString();
        histOp2[15].tag = answer.wrong.ToString();
        histOp2[16].tag = answer.wrong.ToString();
        //Option3 Data
        histOp3[0].answer = "Rose Revolution";
        histOp3[1].answer = "Brazil";
        histOp3[2].answer = "#1892";
        histOp3[3].answer = "#Gypsy market";
        histOp3[4].answer = "#Marco Polo";
        histOp3[5].answer = "#2005";
        histOp3[6].answer = "#University of Lisbon";
        histOp3[7].answer = "An Earthquake";
        histOp3[8].answer = "#Whale bones";
        histOp3[9].answer = "1139";
        histOp3[10].answer = "#Legislative Elections";
        histOp3[11].answer = "#Absolute Monarchy";
        histOp3[12].answer = "#Pena Castle";
        histOp3[13].answer = "A long wall#";
        histOp3[14].answer = "Guimarães";
        histOp3[15].answer = "#Mozambique#";
        histOp3[16].answer = "#Lisbon";

        histOp3[0].tag = answer.wrong.ToString();
        histOp3[1].tag = answer.correct.ToString();
        histOp3[2].tag = answer.wrong.ToString();
        histOp3[3].tag = answer.wrong.ToString();
        histOp3[4].tag = answer.wrong.ToString();
        histOp3[5].tag = answer.wrong.ToString();
        histOp3[6].tag = answer.wrong.ToString();
        histOp3[7].tag = answer.correct.ToString();
        histOp3[8].tag = answer.wrong.ToString();
        histOp3[9].tag = answer.correct.ToString();
        histOp3[10].tag = answer.wrong.ToString();
        histOp3[11].tag = answer.wrong.ToString();
        histOp3[12].tag = answer.wrong.ToString();
        histOp3[13].tag = answer.wrong.ToString();
        histOp3[14].tag = answer.correct.ToString();
        histOp3[15].tag = answer.wrong.ToString();
        histOp3[16].tag = answer.wrong.ToString();

        //Option4 Data
        histOp4[0].answer = "Velvet Revolution";
        histOp4[1].answer = "#Mosambique";
        histOp4[2].answer = "#1943";
        histOp4[3].answer = "Slave market";
        histOp4[4].answer = "#Amerigo Vespucci";
        histOp4[5].answer = "1999";
        histOp4[6].answer = "University of Evora";
        histOp4[7].answer = "#A volcano eruption";
        histOp4[8].answer = "Human bones";
        histOp4[9].answer = "#1184";
        histOp4[10].answer = "#European Elections";
        histOp4[11].answer = "#Constitutional Monarchy";
        histOp4[12].answer = "#Silves Castle";
        histOp4[13].answer = "Snow drifts";
        histOp4[14].answer = "#Évora#";
        histOp4[15].answer = "Hong Kong";
        histOp4[16].answer = "Sagres";

        histOp4[0].tag = answer.wrong.ToString();
        histOp4[1].tag = answer.wrong.ToString();
        histOp4[2].tag = answer.wrong.ToString();
        histOp4[3].tag = answer.correct.ToString();
        histOp4[4].tag = answer.wrong.ToString();
        histOp4[5].tag = answer.correct.ToString();
        histOp4[6].tag = answer.wrong.ToString();
        histOp4[7].tag = answer.wrong.ToString();
        histOp4[8].tag = answer.correct.ToString();
        histOp4[9].tag = answer.wrong.ToString();
        histOp4[10].tag = answer.wrong.ToString();
        histOp4[11].tag = answer.wrong.ToString();
        histOp4[12].tag = answer.wrong.ToString();
        histOp4[13].tag = answer.wrong.ToString();
        histOp4[14].tag = answer.wrong.ToString();
        histOp4[15].tag = answer.correct.ToString();
        histOp4[16].tag = answer.correct.ToString();
    }

    #endregion

    #region Geography Quiz Data

    public void SetGeographyQuizData(int index)
    {

        selectedCategory = index;
        SetGeographyOptionData();

        int temp = geographyQuizIndex;

        geographyQuizIndex = Random.Range(0, 10);

        if (temp == geographyQuizIndex)
        {
            geographyQuizIndex = Random.Range(0, 10);
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
        geogOp1[0].answer = "Coimbra";
        geogOp1[1].answer = "Beja airport";
        geogOp1[2].answer = "4";
        geogOp1[3].answer = "9";
        geogOp1[4].answer = "Funchal";
        geogOp1[5].answer = "#Guadiana";
        geogOp1[6].answer = "#5";
        geogOp1[7].answer = "#15km";
        geogOp1[8].answer = "Nazaré";
        geogOp1[9].answer = "#Star saw";
        geogOp1[10].answer = "39 30 N, 8 00 W";
        geogOp1[11].answer = "#22";
        geogOp1[12].answer = "#Triangle";
        geogOp1[13].answer = "Trás-os-Montes";

        geogOp1[0].tag = answer.wrong.ToString();
        geogOp1[1].tag = answer.wrong.ToString();
        geogOp1[2].tag = answer.wrong.ToString();
        geogOp1[3].tag = answer.correct.ToString();
        geogOp1[4].tag = answer.correct.ToString();
        geogOp1[5].tag = answer.wrong.ToString();
        geogOp1[6].tag = answer.wrong.ToString();
        geogOp1[7].tag = answer.wrong.ToString();
        geogOp1[8].tag = answer.correct.ToString();
        geogOp1[9].tag = answer.wrong.ToString();
        geogOp1[10].tag = answer.correct.ToString();
        geogOp1[11].tag = answer.wrong.ToString();
        geogOp1[12].tag = answer.wrong.ToString();
        geogOp1[13].tag = answer.wrong.ToString();


        //Option2 Data
        geogOp2[0].answer = "Oporto";
        geogOp2[1].answer = "Francisco Sá Carneiro";
        geogOp2[2].answer = "5";
        geogOp2[3].answer = "8";
        geogOp2[4].answer = "#Ponta Delgada";
        geogOp2[5].answer = "#Lima";
        geogOp2[6].answer = "7";
        geogOp2[7].answer = "#11km";
        geogOp2[8].answer = "#Sines";
        geogOp2[9].answer = "Peak Island";
        geogOp2[10].answer = "#38 24 S,7 00E";
        geogOp2[11].answer = "18";
        geogOp2[12].answer = "Ellipse";
        geogOp2[13].answer = "#Baixo Alentejo#";

        geogOp2[0].tag = answer.wrong.ToString();
        geogOp2[1].tag = answer.wrong.ToString();
        geogOp2[2].tag = answer.correct.ToString();
        geogOp2[3].tag = answer.wrong.ToString();
        geogOp2[4].tag = answer.wrong.ToString();
        geogOp2[5].tag = answer.wrong.ToString();
        geogOp2[6].tag = answer.correct.ToString();
        geogOp2[7].tag = answer.wrong.ToString();
        geogOp2[8].tag = answer.wrong.ToString();
        geogOp2[9].tag = answer.correct.ToString();
        geogOp2[10].tag = answer.wrong.ToString();
        geogOp2[11].tag = answer.correct.ToString();
        geogOp2[12].tag = answer.wrong.ToString();
        geogOp2[13].tag = answer.wrong.ToString();

        //Option3 Data
        geogOp3[0].answer = "Braga";
        geogOp3[1].answer = "Humberto Delgado";
        geogOp3[2].answer = "6";
        geogOp3[3].answer = "10";
        geogOp3[4].answer = "#Praia";
        geogOp3[5].answer = "Tagus";
        geogOp3[6].answer = "#9";
        geogOp3[7].answer = "#21km";
        geogOp3[8].answer = "#Sagres";
        geogOp3[9].answer = "#Cauldron Saw";
        geogOp3[10].answer = "#25 21 N, 8 00W";
        geogOp3[11].answer = "#15";
        geogOp3[12].answer = "Rectangle";
        geogOp3[13].answer = "#Beira Litoral";

        geogOp3[0].tag = answer.wrong.ToString();
        geogOp3[1].tag = answer.correct.ToString();
        geogOp3[2].tag = answer.wrong.ToString();
        geogOp3[3].tag = answer.wrong.ToString();
        geogOp3[4].tag = answer.wrong.ToString();
        geogOp3[5].tag = answer.correct.ToString();
        geogOp3[6].tag = answer.wrong.ToString();
        geogOp3[7].tag = answer.wrong.ToString();
        geogOp3[8].tag = answer.wrong.ToString();
        geogOp3[9].tag = answer.wrong.ToString();
        geogOp3[10].tag = answer.wrong.ToString();
        geogOp3[11].tag = answer.wrong.ToString();
        geogOp3[12].tag = answer.correct.ToString();
        geogOp3[13].tag = answer.wrong.ToString();

        //Option4 Data
        geogOp4[0].answer = "Lisbon";
        geogOp4[1].answer = "Faro airport";
        geogOp4[2].answer = "7";
        geogOp4[3].answer = "6";
        geogOp4[4].answer = "#Braga";
        geogOp4[5].answer = "#Douro";
        geogOp4[6].answer = "#111";
        geogOp4[7].answer = "17km";
        geogOp4[8].answer = "Viana do Castelo";
        geogOp4[9].answer = "Monchique Saw";
        geogOp4[10].answer = "32 29 N, 7 00W";
        geogOp4[11].answer = "26";
        geogOp4[12].answer = "#Square#";
        geogOp4[13].answer = "Algarve";

        geogOp4[0].tag = answer.correct.ToString();
        geogOp4[1].tag = answer.wrong.ToString();
        geogOp4[2].tag = answer.wrong.ToString();
        geogOp4[3].tag = answer.wrong.ToString();
        geogOp4[4].tag = answer.wrong.ToString();
        geogOp4[5].tag = answer.wrong.ToString();
        geogOp4[6].tag = answer.wrong.ToString();
        geogOp4[7].tag = answer.correct.ToString();
        geogOp4[8].tag = answer.wrong.ToString();
        geogOp4[9].tag = answer.wrong.ToString();
        geogOp4[10].tag = answer.wrong.ToString();
        geogOp4[11].tag = answer.wrong.ToString();
        geogOp4[12].tag = answer.wrong.ToString();
        geogOp4[13].tag = answer.correct.ToString();
    }


    #endregion

    #region Food Quiz Data

    public void SetFoodQuizData(int index)
    {
        selectedCategory = index;
        SetFoodOptionData();

        int temp = foodQuizIndex;

        foodQuizIndex = Random.Range(0, 10);

        if (temp == foodQuizIndex)
        {
            foodQuizIndex = Random.Range(0, 10);
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
        foodOp1[0].answer = "Sardine";
        foodOp1[1].answer = "Sagres";
        foodOp1[2].answer = "Chocolate cake";
        foodOp1[3].answer = "Stone's soup";
        foodOp1[4].answer = "Kimchi";
        foodOp1[5].answer = "Pizza";
        foodOp1[6].answer = "#Tobacco leaves";
        foodOp1[7].answer = "Fish";
        foodOp1[8].answer = "#Braga";
        foodOp1[9].answer = "#Minho region";
        foodOp1[10].answer = "Aveiro";
        foodOp1[11].answer = "Whiskey";
        foodOp1[12].answer = "It's green in color";
        foodOp1[13].answer = "Braga";
        foodOp1[14].answer = "Nikita";

        foodOp1[0].tag = answer.wrong.ToString();
        foodOp1[1].tag = answer.correct.ToString();
        foodOp1[2].tag = answer.wrong.ToString();
        foodOp1[3].tag = answer.wrong.ToString();
        foodOp1[4].tag = answer.wrong.ToString();
        foodOp1[5].tag = answer.wrong.ToString();
        foodOp1[6].tag = answer.wrong.ToString();
        foodOp1[7].tag = answer.correct.ToString();
        foodOp1[8].tag = answer.wrong.ToString();
        foodOp1[9].tag = answer.wrong.ToString();
        foodOp1[10].tag = answer.correct.ToString();
        foodOp1[11].tag = answer.wrong.ToString();
        foodOp1[12].tag = answer.wrong.ToString();
        foodOp1[13].tag = answer.wrong.ToString();
        foodOp1[14].tag = answer.correct.ToString();

        //Option2 Data
        foodOp2[0].answer = "#Hake";
        foodOp2[1].answer = "#Évora";
        foodOp2[2].answer = "Custard tart";
        foodOp2[3].answer = "#Chicken soup";
        foodOp2[4].answer = "#Noodles";
        foodOp2[5].answer = "#Hot dog";
        foodOp2[6].answer = "Tea leaves";
        foodOp2[7].answer = "#Rabbit";
        foodOp2[8].answer = "#Lisbon";
        foodOp2[9].answer = "#Algarve region";
        foodOp2[10].answer = "Braga";
        foodOp2[11].answer = "Poncha";
        foodOp2[12].answer = "It's a mature wine";
        foodOp2[13].answer = "Coimbra#";
        foodOp2[14].answer = "#Madeira wine";

        foodOp2[0].tag = answer.wrong.ToString();
        foodOp2[1].tag = answer.wrong.ToString();
        foodOp2[2].tag = answer.correct.ToString();
        foodOp2[3].tag = answer.wrong.ToString();
        foodOp2[4].tag = answer.wrong.ToString();
        foodOp2[5].tag = answer.wrong.ToString();
        foodOp2[6].tag = answer.correct.ToString();
        foodOp2[7].tag = answer.wrong.ToString();
        foodOp2[8].tag = answer.wrong.ToString();
        foodOp2[9].tag = answer.wrong.ToString();
        foodOp2[10].tag = answer.wrong.ToString();
        foodOp2[11].tag = answer.correct.ToString();
        foodOp2[12].tag = answer.wrong.ToString();
        foodOp2[13].tag = answer.wrong.ToString();
        foodOp2[14].tag = answer.wrong.ToString();

        //Option3 Data
        foodOp3[0].answer = "Cod";
        foodOp3[1].answer = "#Faro";
        foodOp3[2].answer = "#Orange pie";
        foodOp3[3].answer = "#Onion soup";
        foodOp3[4].answer = "Tempura";
        foodOp3[5].answer = "#Hamburger";
        foodOp3[6].answer = "#Orchids#";
        foodOp3[7].answer = "#Deer";
        foodOp3[8].answer = "Obidos";
        foodOp3[9].answer = "#Central region";
        foodOp3[10].answer = "#Lisbon";
        foodOp3[11].answer = "#Wine";
        foodOp3[12].answer = "It is a new wine";
        foodOp3[13].answer = "#Viseu#";
        foodOp3[14].answer = "#Camaresque#";

        foodOp3[0].tag = answer.correct.ToString();
        foodOp3[1].tag = answer.wrong.ToString();
        foodOp3[2].tag = answer.wrong.ToString();
        foodOp3[3].tag = answer.wrong.ToString();
        foodOp3[4].tag = answer.correct.ToString();
        foodOp3[5].tag = answer.wrong.ToString();
        foodOp3[6].tag = answer.wrong.ToString();
        foodOp3[7].tag = answer.wrong.ToString();
        foodOp3[8].tag = answer.correct.ToString();
        foodOp3[9].tag = answer.wrong.ToString();
        foodOp3[10].tag = answer.wrong.ToString();
        foodOp3[11].tag = answer.wrong.ToString();
        foodOp3[12].tag = answer.correct.ToString();
        foodOp3[13].tag = answer.wrong.ToString();
        foodOp3[14].tag = answer.wrong.ToString();

        //Option4 Data
        foodOp4[0].answer = "#Salmon";
        foodOp4[1].answer = "#Porto";
        foodOp4[2].answer = "#Apple pie";
        foodOp4[3].answer = "Caldo Verde";
        foodOp4[4].answer = "#Ice cream";
        foodOp4[5].answer = "Omelet";
        foodOp4[6].answer = "Hawthorn";
        foodOp4[7].answer = "#Rooster";
        foodOp4[8].answer = "#Porto";
        foodOp4[9].answer = "Norte region";
        foodOp4[10].answer = "Loulé";
        foodOp4[11].answer = "#Beer#";
        foodOp4[12].answer = "#It's fortified##";
        foodOp4[13].answer = "Porto";
        foodOp4[14].answer = "Lobosia";

        foodOp4[0].tag = answer.wrong.ToString();
        foodOp4[1].tag = answer.wrong.ToString();
        foodOp4[2].tag = answer.wrong.ToString();
        foodOp4[3].tag = answer.correct.ToString();
        foodOp4[4].tag = answer.wrong.ToString();
        foodOp4[5].tag = answer.correct.ToString();
        foodOp4[6].tag = answer.wrong.ToString();
        foodOp4[7].tag = answer.wrong.ToString();
        foodOp4[8].tag = answer.wrong.ToString();
        foodOp4[9].tag = answer.correct.ToString();
        foodOp4[10].tag = answer.wrong.ToString();
        foodOp4[11].tag = answer.wrong.ToString();
        foodOp4[12].tag = answer.wrong.ToString();
        foodOp4[13].tag = answer.correct.ToString();
        foodOp4[14].tag = answer.wrong.ToString();
    }

    #endregion

    #region Culture Quiz Data

    public void SetCultureQuizData(int index)
    {
        selectedCategory = index;

        SetCultureOptionData();
        int temp = cultureQuizIndex;

        cultureQuizIndex = Random.Range(0, 10);

        if (temp == cultureQuizIndex)
        {
            cultureQuizIndex = Random.Range(0, 10);
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
        culOp1[0].answer = "#Portugal";
        culOp1[1].answer = "Ceramic tiles";
        culOp1[2].answer = "#Orchid";
        culOp1[3].answer = "#Madeira wine";
        culOp1[4].answer = "#Cotton";
        culOp1[5].answer = "#Lutheran";
        culOp1[6].answer = "#Portimão";
        culOp1[7].answer = "Bear";
        culOp1[8].answer = "Fado";
        culOp1[9].answer = "Ruben Dias";
        culOp1[10].answer = "Food";
        culOp1[11].answer = "3";
        culOp1[12].answer = "A Portuguese Fado singer";
        culOp1[13].answer = "Stork";
        culOp1[14].answer = "Porto";
        culOp1[15].answer = "Titanium#";
        culOp1[16].answer = "Red & yellow";

        culOp1[0].tag = answer.wrong.ToString();
        culOp1[1].tag = answer.correct.ToString();
        culOp1[2].tag = answer.wrong.ToString();
        culOp1[3].tag = answer.wrong.ToString();
        culOp1[4].tag = answer.wrong.ToString();
        culOp1[5].tag = answer.wrong.ToString();
        culOp1[6].tag = answer.wrong.ToString();
        culOp1[7].tag = answer.wrong.ToString();
        culOp1[8].tag = answer.correct.ToString();
        culOp1[9].tag = answer.wrong.ToString();
        culOp1[10].tag = answer.wrong.ToString();
        culOp1[11].tag = answer.wrong.ToString();
        culOp1[12].tag = answer.wrong.ToString();
        culOp1[13].tag = answer.wrong.ToString();
        culOp1[14].tag = answer.correct.ToString();
        culOp1[15].tag = answer.wrong.ToString();
        culOp1[16].tag = answer.wrong.ToString();

        //Option2 Data
        culOp2[0].answer = "The Portuguese";
        culOp2[1].answer = "#Ceramic pots";
        culOp2[2].answer = "#Carnation";
        culOp2[3].answer = "# Muscat";
        culOp2[4].answer = "Cork";
        culOp2[5].answer = "Roman Catholic";
        culOp2[6].answer = "#Coimbra";
        culOp2[7].answer = "#Eagle";
        culOp2[8].answer = "#Folk";
        culOp2[9].answer = "#Bruno Fernandes";
        culOp2[10].answer = "#Science";
        culOp2[11].answer = "#10";
        culOp2[12].answer = "A Portuguese poet";
        culOp2[13].answer = "Raven";
        culOp2[14].answer = "#Viseu#";
        culOp2[15].answer = "#Carbon#";
        culOp2[16].answer = "Yellow & blue# ";

        culOp2[0].tag = answer.correct.ToString();
        culOp2[1].tag = answer.wrong.ToString();
        culOp2[2].tag = answer.wrong.ToString();
        culOp2[3].tag = answer.wrong.ToString();
        culOp2[4].tag = answer.correct.ToString();
        culOp2[5].tag = answer.correct.ToString();
        culOp2[6].tag = answer.wrong.ToString();
        culOp2[7].tag = answer.wrong.ToString();
        culOp2[8].tag = answer.wrong.ToString();
        culOp2[9].tag = answer.wrong.ToString();
        culOp2[10].tag = answer.wrong.ToString();
        culOp2[11].tag = answer.wrong.ToString();
        culOp2[12].tag = answer.correct.ToString();
        culOp2[13].tag = answer.correct.ToString();
        culOp2[14].tag = answer.wrong.ToString();
        culOp2[15].tag = answer.wrong.ToString();
        culOp2[16].tag = answer.wrong.ToString();

        //Option3 Data
        culOp3[0].answer = "#National";
        culOp3[1].answer = "#Ceramic glass";
        culOp3[2].answer = "Lavender";
        culOp3[3].answer = "#Green wine";
        culOp3[4].answer = "#Wool";
        culOp3[5].answer = "#Judaism";
        culOp3[6].answer = "#Porto";
        culOp3[7].answer = "#Lion";
        culOp3[8].answer = "#Jazz";
        culOp3[9].answer = "Cristiano Ronaldo";
        culOp3[10].answer = "#Education";
        culOp3[11].answer = "#7";
        culOp3[12].answer = "#A Portuguese scientist";
        culOp3[13].answer = "Eagle#";
        culOp3[14].answer = "Lisbon#";
        culOp3[15].answer = "Lithium";
        culOp3[16].answer = "Red & green#";

        culOp3[0].tag = answer.wrong.ToString();
        culOp3[1].tag = answer.wrong.ToString();
        culOp3[2].tag = answer.correct.ToString();
        culOp3[3].tag = answer.wrong.ToString();
        culOp3[4].tag = answer.wrong.ToString();
        culOp3[5].tag = answer.wrong.ToString();
        culOp3[6].tag = answer.wrong.ToString();
        culOp3[7].tag = answer.wrong.ToString();
        culOp3[8].tag = answer.wrong.ToString();
        culOp3[9].tag = answer.correct.ToString();
        culOp3[10].tag = answer.wrong.ToString();
        culOp3[11].tag = answer.wrong.ToString();
        culOp3[12].tag = answer.wrong.ToString();
        culOp3[13].tag = answer.wrong.ToString();
        culOp3[14].tag = answer.wrong.ToString();
        culOp3[15].tag = answer.correct.ToString();
        culOp3[16].tag = answer.correct.ToString();

        //Option4 Data
        culOp4[0].answer = "#Weapons";
        culOp4[1].answer = "#Ceramic bricks";
        culOp4[2].answer = "#Tulip";
        culOp4[3].answer = "Port wine";
        culOp4[4].answer = "#Timber";
        culOp4[5].answer = "#Islam";
        culOp4[6].answer = "Lisbon";
        culOp4[7].answer = "Rooster";
        culOp4[8].answer = "#Funk";
        culOp4[9].answer = "#João Félix";
        culOp4[10].answer = "Pilgrimage";
        culOp4[11].answer = "15";
        culOp4[12].answer = "#A Portuguese football player";
        culOp4[13].answer = "Goldfinch";
        culOp4[14].answer = "Albufeira";
        culOp4[15].answer = "Arsenic";
        culOp4[16].answer = "Green & blue #";

        culOp4[0].tag = answer.wrong.ToString();
        culOp4[1].tag = answer.wrong.ToString();
        culOp4[2].tag = answer.wrong.ToString();
        culOp4[3].tag = answer.correct.ToString();
        culOp4[4].tag = answer.wrong.ToString();
        culOp4[5].tag = answer.wrong.ToString();
        culOp4[6].tag = answer.correct.ToString();
        culOp4[7].tag = answer.correct.ToString();
        culOp4[8].tag = answer.wrong.ToString();
        culOp4[9].tag = answer.wrong.ToString();
        culOp4[10].tag = answer.correct.ToString();
        culOp4[11].tag = answer.correct.ToString();
        culOp4[12].tag = answer.wrong.ToString();
        culOp4[13].tag = answer.wrong.ToString();
        culOp4[14].tag = answer.wrong.ToString();
        culOp4[15].tag = answer.wrong.ToString();
        culOp4[16].tag = answer.wrong.ToString();
    }

    #endregion
    
    #region Language Quiz Data

    public void SetLanguageQuizData(int index)
    {
        selectedCategory = index;

        SetLanguageOptionData();
        int temp = languageyQuizIndex;

        languageyQuizIndex = Random.Range(0, 10);

        if (temp == languageyQuizIndex)
        {
            languageyQuizIndex = Random.Range(0, 10);
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
        langOp1[0].answer = "230";
        langOp1[1].answer = "7";
        langOp1[2].answer = "#10th";
        langOp1[3].answer = "#Japanese";
        langOp1[4].answer = "Açoreano";
        langOp1[5].answer = "10";
        langOp1[6].answer = "#Uralic language";
        langOp1[7].answer = "#Lisboeta#";
        langOp1[8].answer = "#China";
        langOp1[9].answer = "Felicidade";

        langOp1[0].tag = answer.correct.ToString();
        langOp1[1].tag = answer.wrong.ToString();
        langOp1[2].tag = answer.wrong.ToString();
        langOp1[3].tag = answer.wrong.ToString();
        langOp1[4].tag = answer.correct.ToString();
        langOp1[5].tag = answer.wrong.ToString();
        langOp1[6].tag = answer.wrong.ToString();
        langOp1[7].tag = answer.wrong.ToString();
        langOp1[8].tag = answer.wrong.ToString();
        langOp1[9].tag = answer.wrong.ToString();

        //Option2 Data
        langOp2[0].answer = "#170";
        langOp2[1].answer = "11";
        langOp2[2].answer = "#4th";
        langOp2[3].answer = "Arabic";
        langOp2[4].answer = "#Minho region dialect";
        langOp2[5].answer = "#8#";
        langOp2[6].answer = "#Slavic language";
        langOp2[7].answer = "Mirandês";
        langOp2[8].answer = "Macau";
        langOp2[9].answer = "#Saúde#";

        langOp2[0].tag = answer.wrong.ToString();
        langOp2[1].tag = answer.wrong.ToString();
        langOp2[2].tag = answer.wrong.ToString();
        langOp2[3].tag = answer.correct.ToString();
        langOp2[4].tag = answer.wrong.ToString();
        langOp2[5].tag = answer.wrong.ToString();
        langOp2[6].tag = answer.wrong.ToString();
        langOp2[7].tag = answer.correct.ToString();
        langOp2[8].tag = answer.correct.ToString();
        langOp2[9].tag = answer.wrong.ToString();

        //Option3 Data
        langOp3[0].answer = "#270";
        langOp3[1].answer = "#5#";
        langOp3[2].answer = "6th";
        langOp3[3].answer = "#Swahili#";
        langOp3[4].answer = "#Beira region dialect";
        langOp3[5].answer = "#4";
        langOp3[6].answer = "Romantic language";
        langOp3[7].answer = "Bracarense#";
        langOp3[8].answer = "#Hong kong#";
        langOp3[9].answer = "#Tristeza";

        langOp3[0].tag = answer.wrong.ToString();
        langOp3[1].tag = answer.wrong.ToString();
        langOp3[2].tag = answer.correct.ToString();
        langOp3[3].tag = answer.wrong.ToString();
        langOp3[4].tag = answer.wrong.ToString();
        langOp3[5].tag = answer.wrong.ToString();
        langOp3[6].tag = answer.correct.ToString();
        langOp3[7].tag = answer.wrong.ToString();
        langOp3[8].tag = answer.wrong.ToString();
        langOp3[9].tag = answer.wrong.ToString();

        //Option4 Data
        langOp4[0].answer = "320";
        langOp4[1].answer = "9";
        langOp4[2].answer = "#9th";
        langOp4[3].answer = "Finnish";
        langOp4[4].answer = "#Algarvian";
        langOp4[5].answer = "11";
        langOp4[6].answer = "#Germanic language";
        langOp4[7].answer = "Alentejano";
        langOp4[8].answer = "Thailand";
        langOp4[9].answer = "Saudade";

        langOp4[0].tag = answer.wrong.ToString();
        langOp4[1].tag = answer.correct.ToString();
        langOp4[2].tag = answer.wrong.ToString();
        langOp4[3].tag = answer.wrong.ToString();
        langOp4[4].tag = answer.wrong.ToString();
        langOp4[5].tag = answer.correct.ToString();
        langOp4[6].tag = answer.wrong.ToString();
        langOp4[7].tag = answer.wrong.ToString();
        langOp4[8].tag = answer.wrong.ToString();
        langOp4[9].tag = answer.correct.ToString();
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
        if (PlayerPrefs.GetInt("CurrentLevel") == 5)
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
            if (PlayerPrefs.GetInt("PPortugalHist", 0) <= 3)
            {
                PlayerPrefs.SetInt("PortugalHist", (PlayerPrefs.GetInt("PortugalHist")) + 1);
                PlayerPrefs.Save();

                SetHistoryQuizData(1);

                if (PlayerPrefs.GetInt("PortugalHist", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if(selectedCategory == 2)
        {
            if (PlayerPrefs.GetInt("PortugalGeo", 0) <= 3)
            {
                PlayerPrefs.SetInt("PortugalGeo", (PlayerPrefs.GetInt("PortugalGeo")) + 1);
                PlayerPrefs.Save();

                SetGeographyQuizData(2);

                if (PlayerPrefs.GetInt("PortugalGeo", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 3)
        {
            if (PlayerPrefs.GetInt("PortugalFood", 0) <= 3)
            {
                PlayerPrefs.SetInt("PortugalFood", (PlayerPrefs.GetInt("PortugalFood")) + 1);
                PlayerPrefs.Save();

                SetFoodQuizData(3);

                if (PlayerPrefs.GetInt("PortugalFood", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 4)
        {
            if (PlayerPrefs.GetInt("PortugalCult", 0) <= 3)
            {
                PlayerPrefs.SetInt("PortugalCult", (PlayerPrefs.GetInt("PortugalCult")) + 1);
                PlayerPrefs.Save();

                SetCultureQuizData(4);

                if (PlayerPrefs.GetInt("PortugalCult", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if(selectedCategory == 5)
        {
            if (PlayerPrefs.GetInt("PortugalLang", 0) <= 3)
            {
                PlayerPrefs.SetInt("PortugalLang", (PlayerPrefs.GetInt("PortugalLang")) + 1);
                PlayerPrefs.Save();

                SetLanguageQuizData(5);

                if (PlayerPrefs.GetInt("PortugalLang", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
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
