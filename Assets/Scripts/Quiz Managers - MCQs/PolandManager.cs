using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PolandManager : MonoBehaviour
{
    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public string[] historyQues;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[9];
    private Option[] histOp2 = new Option[9];
    private Option[] histOp3 = new Option[9];
    private Option[] histOp4 = new Option[9];

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

    public BoxCollider door4Col;
    public GameObject congratsPanel;
    public GameObject playerController;


    void Start()
    {
        selectedCategory = 0;
        PlayerPrefs.SetString("SelectedManager", "PL");
    }

    void Update()
    {
        historyScoreText.text = PlayerPrefs.GetInt("PolandHist") + "/3";
        geographyScoreText.text = PlayerPrefs.GetInt("PolandGeo") + "/3";
        foodScoreText.text = PlayerPrefs.GetInt("PolandFood") + "/3";
        cultureScoreText.text = PlayerPrefs.GetInt("PolandCult") + "/3";
        languageScoreText.text = PlayerPrefs.GetInt("PolandLang") + "/3";


        

        if (PlayerPrefs.GetInt("PolandHist") >= 3)
        {
            historyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PolandGeo") >= 3)
        {
            geographyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PolandFood") >= 3)
        {
            foodCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PolandCult") >= 3)
        {
            cultureCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PolandLang") >= 3)
        {
            languageCompleteImage.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level4") >= 5)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);
            door4Col.isTrigger = true;
            congratsPanel.SetActive(true);
            playerController.SetActive(false);

           // GameManagers.score = PlayerPrefs.GetInt("Score") + 15;


           // PlayerPrefs.SetInt("Score", GameManagers.score);
            PlayerPrefs.Save();

            // Report a score of 100
            // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
            // of a leaderboard named "Sample Leaderboard"
            GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            //CountDown.timeRemaining = 300f;
            //CountDown.timerIsRunning = true;
            //PlayerPrefs.SetFloat("TimeRemaining", CountDown.timeRemaining);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Level4", 0);
            PlayerPrefs.SetInt("LevelM4", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM4") == 1)
        {
            door4Col.isTrigger = true;

        }
    }

    #region History Quiz Data

    public void SetHistoryQuizData(int index)
    {
        selectedCategory = index;
        SetHistoryOptionData();
        int temp = historyQuizIndex;

        historyQuizIndex = Random.Range(0, 9);

        if (temp == historyQuizIndex)
        {
            historyQuizIndex = Random.Range(0, 9);
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
        histOp1[0].answer = "Warszawa";
        histOp1[1].answer = "Kraków";
        histOp1[2].answer = "Yes";
        histOp1[3].answer = "Kampinos Forest";
        histOp1[4].answer = "Zakopanego";
        histOp1[5].answer = "Rus";
        histOp1[6].answer = "1st of May";
        histOp1[7].answer = "Mieszko I";
        histOp1[8].answer = "1997";
        

        histOp1[0].tag = answer.wrong.ToString();
        histOp1[1].tag = answer.wrong.ToString();
        histOp1[2].tag = answer.correct.ToString();
        histOp1[3].tag = answer.wrong.ToString();
        histOp1[4].tag = answer.wrong.ToString();
        histOp1[5].tag = answer.wrong.ToString();
        histOp1[6].tag = answer.wrong.ToString();
        histOp1[7].tag = answer.correct.ToString();
        histOp1[8].tag = answer.wrong.ToString();
        

        //Option2 Data
        histOp2[0].answer = "Gdańsk";
        histOp2[1].answer = "Gdańsk";
        histOp2[2].answer = "No";
        histOp2[3].answer = "Tatra National Park ";
        histOp2[4].answer = "Gdyni";
        histOp2[5].answer = "Lech";
        histOp2[6].answer = "2nd of May";
        histOp2[7].answer = "Lech";
        histOp2[8].answer = "1981";
       

        histOp2[0].tag = answer.correct.ToString();
        histOp2[1].tag = answer.wrong.ToString();
        histOp2[2].tag = answer.wrong.ToString();
        histOp2[3].tag = answer.wrong.ToString();
        histOp2[4].tag = answer.wrong.ToString();
        histOp2[5].tag = answer.wrong.ToString();
        histOp2[6].tag = answer.correct.ToString();
        histOp2[7].tag = answer.wrong.ToString();
        histOp2[8].tag = answer.wrong.ToString();
        

        //Option3 Data
        histOp3[0].answer = "Poznań";
        histOp3[1].answer = "Sczecin";
        histOp3[2].answer = "None of the above";
        histOp3[3].answer = "Białowieża Forest";
        histOp3[4].answer = "Wrocławia";
        histOp3[5].answer = "Czech";
        histOp3[6].answer = "3rd of May";
        histOp3[7].answer = "Bolesław Chrobry ";
        histOp3[8].answer = "1989";
        

        histOp3[0].tag = answer.wrong.ToString();
        histOp3[1].tag = answer.wrong.ToString();
        histOp3[2].tag = answer.wrong.ToString();
        histOp3[3].tag = answer.correct.ToString();
        histOp3[4].tag = answer.wrong.ToString();
        histOp3[5].tag = answer.correct.ToString();
        histOp3[6].tag = answer.wrong.ToString();
        histOp3[7].tag = answer.wrong.ToString();
        histOp3[8].tag = answer.correct.ToString();
        

        //Option4 Data
        histOp4[0].answer = "Szczecin";
        histOp4[1].answer = "Warszawa";
        histOp4[2].answer = "Both";
        histOp4[3].answer = "Ojców National Park";
        histOp4[4].answer = "Warszwy";
        histOp4[5].answer = "Popiel";
        histOp4[6].answer = "4th of May";
        histOp4[7].answer = "Kazimierz Wielki ";
        histOp4[8].answer = "1990";
        

        histOp4[0].tag = answer.wrong.ToString();
        histOp4[1].tag = answer.correct.ToString();
        histOp4[2].tag = answer.wrong.ToString();
        histOp4[3].tag = answer.wrong.ToString();
        histOp4[4].tag = answer.correct.ToString();
        histOp4[5].tag = answer.wrong.ToString();
        histOp4[6].tag = answer.wrong.ToString();
        histOp4[7].tag = answer.wrong.ToString();
        histOp4[8].tag = answer.wrong.ToString();
        
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
        geogOp1[0].answer = "Hańcza";
        geogOp1[1].answer = "Slovakia";
        geogOp1[2].answer = "San";
        geogOp1[3].answer = "Łysica";
        geogOp1[4].answer = "Gniezno";
        geogOp1[5].answer = "7 ";
        geogOp1[6].answer = "41";
        geogOp1[7].answer = "Karpacz";
        geogOp1[8].answer = "Olsztyn";
        geogOp1[9].answer = "Kraków";

        geogOp1[0].tag = answer.correct.ToString();
        geogOp1[1].tag = answer.wrong.ToString();
        geogOp1[2].tag = answer.wrong.ToString();
        geogOp1[3].tag = answer.wrong.ToString();
        geogOp1[4].tag = answer.wrong.ToString();
        geogOp1[5].tag = answer.correct.ToString();
        geogOp1[6].tag = answer.wrong.ToString();
        geogOp1[7].tag = answer.wrong.ToString();
        geogOp1[8].tag = answer.wrong.ToString();
        geogOp1[9].tag = answer.correct.ToString();

        //Option2 Data
        geogOp2[0].answer = "Morskie Oko ";
        geogOp2[1].answer = "Ukraine";
        geogOp2[2].answer = "Wisła";
        geogOp2[3].answer = "Giewont";
        geogOp2[4].answer = "Poznań ";
        geogOp2[5].answer = "6";
        geogOp2[6].answer = "16";
        geogOp2[7].answer = "Zakopane";
        geogOp2[8].answer = "Malbork";
        geogOp2[9].answer = "Toruń";

        geogOp2[0].tag = answer.wrong.ToString();
        geogOp2[1].tag = answer.wrong.ToString();
        geogOp2[2].tag = answer.correct.ToString();
        geogOp2[3].tag = answer.wrong.ToString();
        geogOp2[4].tag = answer.wrong.ToString();
        geogOp2[5].tag = answer.wrong.ToString();
        geogOp2[6].tag = answer.correct.ToString();
        geogOp2[7].tag = answer.wrong.ToString();
        geogOp2[8].tag = answer.correct.ToString();
        geogOp2[9].tag = answer.wrong.ToString();

        //Option3 Data
        geogOp3[0].answer = "Śniardwy";
        geogOp3[1].answer = "Germany";
        geogOp3[2].answer = "Odra";
        geogOp3[3].answer = "Kasprowy Wierch";
        geogOp3[4].answer = "Krakow";
        geogOp3[5].answer = "5";
        geogOp3[6].answer = "12";
        geogOp3[7].answer = "Wieliczka";
        geogOp3[8].answer = "Reszel";
        geogOp3[9].answer = "Gdynia";

        geogOp3[0].tag = answer.wrong.ToString();
        geogOp3[1].tag = answer.correct.ToString();
        geogOp3[2].tag = answer.wrong.ToString();
        geogOp3[3].tag = answer.wrong.ToString();
        geogOp3[4].tag = answer.wrong.ToString();
        geogOp3[5].tag = answer.wrong.ToString();
        geogOp3[6].tag = answer.wrong.ToString();
        geogOp3[7].tag = answer.correct.ToString();
        geogOp3[8].tag = answer.wrong.ToString();
        geogOp3[9].tag = answer.wrong.ToString();

        //Option4 Data
        geogOp4[0].answer = "Mamry";
        geogOp4[1].answer = "Russia";
        geogOp4[2].answer = "Bug";
        geogOp4[3].answer = "Rysy";
        geogOp4[4].answer = "Warsaw";
        geogOp4[5].answer = "10";
        geogOp4[6].answer = "18";
        geogOp4[7].answer = "Kraków";
        geogOp4[8].answer = "Lizbark Warmiński";
        geogOp4[9].answer = "Szczecin";

        geogOp4[0].tag = answer.wrong.ToString();
        geogOp4[1].tag = answer.wrong.ToString();
        geogOp4[2].tag = answer.wrong.ToString();
        geogOp4[3].tag = answer.correct.ToString();
        geogOp4[4].tag = answer.correct.ToString();
        geogOp4[5].tag = answer.wrong.ToString();
        geogOp4[6].tag = answer.wrong.ToString();
        geogOp4[7].tag = answer.wrong.ToString();
        geogOp4[8].tag = answer.wrong.ToString();
        geogOp4[9].tag = answer.wrong.ToString();
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
        foodOp1[0].answer = "Białystok";
        foodOp1[1].answer = "Yellow cheese";
        foodOp1[2].answer = "12";
        foodOp1[3].answer = "Pasta";
        foodOp1[4].answer = "Donut day ";
        foodOp1[5].answer = "Yes";
        foodOp1[6].answer = "Caramel cake";
        foodOp1[7].answer = "Broccoli soup";
        foodOp1[8].answer = "Chicken soup";
        foodOp1[9].answer = "Cabbage and celery";

        foodOp1[0].tag = answer.wrong.ToString();
        foodOp1[1].tag = answer.wrong.ToString();
        foodOp1[2].tag = answer.correct.ToString();
        foodOp1[3].tag = answer.wrong.ToString();
        foodOp1[4].tag = answer.wrong.ToString();
        foodOp1[5].tag = answer.correct.ToString();
        foodOp1[6].tag = answer.wrong.ToString();
        foodOp1[7].tag = answer.wrong.ToString();
        foodOp1[8].tag = answer.wrong.ToString();
        foodOp1[9].tag = answer.wrong.ToString();

        //Option2 Data
        foodOp2[0].answer = "Toruń";
        foodOp2[1].answer = "Blue cheese";
        foodOp2[2].answer = "13";
        foodOp2[3].answer = "Raviolli";
        foodOp2[4].answer = "Thursday's donut ";
        foodOp2[5].answer = "No";
        foodOp2[6].answer = "Brownie ";
        foodOp2[7].answer = "Żurek ";
        foodOp2[8].answer = "Fish soup";
        foodOp2[9].answer = "Cabbage and cucumbers";

        foodOp2[0].tag = answer.correct.ToString();
        foodOp2[1].tag = answer.wrong.ToString();
        foodOp2[2].tag = answer.wrong.ToString();
        foodOp2[3].tag = answer.wrong.ToString();
        foodOp2[4].tag = answer.wrong.ToString();
        foodOp2[5].tag = answer.wrong.ToString();
        foodOp2[6].tag = answer.wrong.ToString();
        foodOp2[7].tag = answer.correct.ToString();
        foodOp2[8].tag = answer.wrong.ToString();
        foodOp2[9].tag = answer.correct.ToString();

        //Option3 Data
        foodOp3[0].answer = "Warszawa ";
        foodOp3[1].answer = "Goat cheese";
        foodOp3[2].answer = "15";
        foodOp3[3].answer = "Dumplings";
        foodOp3[4].answer = "Fat Thursday ";
        foodOp3[5].answer = "None of the above";
        foodOp3[6].answer = "Cheesecake";
        foodOp3[7].answer = "Cabbage soup ";
        foodOp3[8].answer = "Borscht";
        foodOp3[9].answer = "Beets and potatoes";

        foodOp3[0].tag = answer.wrong.ToString();
        foodOp3[1].tag = answer.wrong.ToString();
        foodOp3[2].tag = answer.wrong.ToString();
        foodOp3[3].tag = answer.correct.ToString();
        foodOp3[4].tag = answer.correct.ToString();
        foodOp3[5].tag = answer.wrong.ToString();
        foodOp3[6].tag = answer.correct.ToString();
        foodOp3[7].tag = answer.wrong.ToString();
        foodOp3[8].tag = answer.wrong.ToString();
        foodOp3[9].tag = answer.wrong.ToString();

        //Option4 Data
        foodOp4[0].answer = "Poznań";
        foodOp4[1].answer = "Oscypek";
        foodOp4[2].answer = "5";
        foodOp4[3].answer = "Pancakes";
        foodOp4[4].answer = "Sweet holidays";
        foodOp4[5].answer = "Both";
        foodOp4[6].answer = "Meringue cake";
        foodOp4[7].answer = "Carrot soup ";
        foodOp4[8].answer = "Cold soup";
        foodOp4[9].answer = "Cucumbers and carrots";

        foodOp4[0].tag = answer.wrong.ToString();
        foodOp4[1].tag = answer.correct.ToString();
        foodOp4[2].tag = answer.wrong.ToString();
        foodOp4[3].tag = answer.wrong.ToString();
        foodOp4[4].tag = answer.wrong.ToString();
        foodOp4[5].tag = answer.wrong.ToString();
        foodOp4[6].tag = answer.wrong.ToString();
        foodOp4[7].tag = answer.wrong.ToString();
        foodOp4[8].tag = answer.correct.ToString();
        foodOp4[9].tag = answer.wrong.ToString();
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
        culOp1[0].answer = "We live";
        culOp1[1].answer = "Golden Duck";
        culOp1[2].answer = "capital city and white eagle";
        culOp1[3].answer = "White hawk on a red background";
        culOp1[4].answer = "Red and Green";
        culOp1[5].answer = "Protestants";
        culOp1[6].answer = "God Honor Homeland";
        culOp1[7].answer = "Bogurodzica";
        culOp1[8].answer = "White eagle on a red background";
        culOp1[9].answer = "Maria Konopnicka";

        culOp1[0].tag = answer.correct.ToString();
        culOp1[1].tag = answer.wrong.ToString();
        culOp1[2].tag = answer.wrong.ToString();
        culOp1[3].tag = answer.wrong.ToString();
        culOp1[4].tag = answer.wrong.ToString();
        culOp1[5].tag = answer.wrong.ToString();
        culOp1[6].tag = answer.correct.ToString();
        culOp1[7].tag = answer.wrong.ToString();
        culOp1[8].tag = answer.correct.ToString();
        culOp1[9].tag = answer.wrong.ToString();

        //Option2 Data
        culOp2[0].answer = "We will";
        culOp2[1].answer = "Billy Goats ";
        culOp2[2].answer = "national flag, coat of arms, national anthem";
        culOp2[3].answer = "golden eagle on a red background";
        culOp2[4].answer = "White and Orange";
        culOp2[5].answer = "Światek Jechowi";
        culOp2[6].answer = "God and Church";
        culOp2[7].answer = "Mazurek Dąbrowskiego";
        culOp2[8].answer = "White eagle on a golden background";
        culOp2[9].answer = "Hendryk Dąbrowski ";

        culOp2[0].tag = answer.wrong.ToString();
        culOp2[1].tag = answer.wrong.ToString();
        culOp2[2].tag = answer.correct.ToString();
        culOp2[3].tag = answer.wrong.ToString();
        culOp2[4].tag = answer.wrong.ToString();
        culOp2[5].tag = answer.wrong.ToString();
        culOp2[6].tag = answer.wrong.ToString();
        culOp2[7].tag = answer.correct.ToString();
        culOp2[8].tag = answer.wrong.ToString();
        culOp2[9].tag = answer.wrong.ToString();

        //Option3 Data
        culOp3[0].answer = "We are";
        culOp3[1].answer = "Wawel Dragon";
        culOp3[2].answer = "Ceremonial trunk and Polish language ";
        culOp3[3].answer = "white eagle on a red background";
        culOp3[4].answer = "White and Red";
        culOp3[5].answer = "Orthodox";
        culOp3[6].answer = "God and Homeland";
        culOp3[7].answer = "Rota ";
        culOp3[8].answer = "Golden eagle on a white background";
        culOp3[9].answer = "Adam Mickiewicz";

        culOp3[0].tag = answer.wrong.ToString();
        culOp3[1].tag = answer.wrong.ToString();
        culOp3[2].tag = answer.wrong.ToString();
        culOp3[3].tag = answer.correct.ToString();
        culOp3[4].tag = answer.correct.ToString();
        culOp3[5].tag = answer.wrong.ToString();
        culOp3[6].tag = answer.wrong.ToString();
        culOp3[7].tag = answer.wrong.ToString();
        culOp3[8].tag = answer.wrong.ToString();
        culOp3[9].tag = answer.wrong.ToString();

        //Option4 Data
        culOp4[0].answer = "We rule";
        culOp4[1].answer = "Mermaid";
        culOp4[2].answer = "national legends, constitution white and red";
        culOp4[3].answer = "red eagle on a white background";
        culOp4[4].answer = "Blue and Yellow";
        culOp4[5].answer = "Catholic";
        culOp4[6].answer = "Family and God";
        culOp4[7].answer = "Polonia March";
        culOp4[8].answer = "Eagle";
        culOp4[9].answer = "Józef Wibicki";

        culOp4[0].tag = answer.wrong.ToString();
        culOp4[1].tag = answer.correct.ToString();
        culOp4[2].tag = answer.wrong.ToString();
        culOp4[3].tag = answer.wrong.ToString();
        culOp4[4].tag = answer.wrong.ToString();
        culOp4[5].tag = answer.correct.ToString();
        culOp4[6].tag = answer.wrong.ToString();
        culOp4[7].tag = answer.wrong.ToString();
        culOp4[8].tag = answer.wrong.ToString();
        culOp4[9].tag = answer.correct.ToString();
    }



    #endregion
    
    #region Language Quiz Data

    public void SetLanguageQuizData(int index)
    {
        selectedCategory = index;
        SetLanguageOptionData();
        int temp = languageyQuizIndex;

        languageyQuizIndex = Random.Range(0, 5);

        if (temp == languageyQuizIndex)
        {
            languageyQuizIndex = Random.Range(0, 5);
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
        langOp1[0].answer = "1";
        langOp1[1].answer = "70mln";
        langOp1[2].answer = "Veterinarian";
        langOp1[3].answer = "polski i rosyjski";
        langOp1[4].answer = "mazowiecki";


        langOp1[0].tag = answer.correct.ToString();
        langOp1[1].tag = answer.wrong.ToString();
        langOp1[2].tag = answer.wrong.ToString();
        langOp1[3].tag = answer.wrong.ToString();
        langOp1[4].tag = answer.correct.ToString();
       
        //Option2 Data
        langOp2[0].answer = "2";
        langOp2[1].answer = "60mln";
        langOp2[2].answer = "Pielegniarka";
        langOp2[3].answer = "polski i kaszubski ";
        langOp2[4].answer = "wielkopolski";


        langOp2[0].tag = answer.wrong.ToString();
        langOp2[1].tag = answer.wrong.ToString();
        langOp2[2].tag = answer.wrong.ToString();
        langOp2[3].tag = answer.correct.ToString();
        langOp2[4].tag = answer.wrong.ToString();
        
        //Option3 Data
        langOp3[0].answer = "3";
        langOp3[1].answer = "44 mln  ";
        langOp3[2].answer = "Police";
        langOp3[3].answer = "Polski i niemiecki  ";
        langOp3[4].answer = "śląski";

        langOp3[0].tag = answer.wrong.ToString();
        langOp3[1].tag = answer.correct.ToString();
        langOp3[2].tag = answer.wrong.ToString();
        langOp3[3].tag = answer.wrong.ToString();
        langOp3[4].tag = answer.wrong.ToString();
       
        //Option4 Data
        langOp4[0].answer = "4";
        langOp4[1].answer = "32mln ";
        langOp4[2].answer = "Hospital";
        langOp4[3].answer = "Polski i niemiecki ";
        langOp4[4].answer = "All mentioned above";

        langOp4[0].tag = answer.wrong.ToString();
        langOp4[1].tag = answer.wrong.ToString();
        langOp4[2].tag = answer.correct.ToString();
        langOp4[3].tag = answer.wrong.ToString();
        langOp4[4].tag = answer.wrong.ToString();
        

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
        if (PlayerPrefs.GetInt("CurrentLevel") == 4)
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
            if (PlayerPrefs.GetInt("PolandHist", 0) <= 3)
            {
                PlayerPrefs.SetInt("PolandHist", (PlayerPrefs.GetInt("PolandHist")) + 1);
                PlayerPrefs.Save();

                SetHistoryQuizData(1);

                if (PlayerPrefs.GetInt("PolandHist", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if(selectedCategory == 2)
        {
            if (PlayerPrefs.GetInt("PolandGeo", 0) <= 3)
            {
                PlayerPrefs.SetInt("PolandGeo", (PlayerPrefs.GetInt("PolandGeo")) + 1);
                PlayerPrefs.Save();

                SetGeographyQuizData(2);

                if (PlayerPrefs.GetInt("PolandGeo", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 3)
        {
            if (PlayerPrefs.GetInt("PolandFood", 0) <= 3)
            {
                PlayerPrefs.SetInt("PolandFood", (PlayerPrefs.GetInt("PolandFood")) + 1);
                PlayerPrefs.Save();

                SetFoodQuizData(3);

                if (PlayerPrefs.GetInt("PolandFood", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 4)
        {
            if (PlayerPrefs.GetInt("PolandCult", 0) <= 3)
            {
                PlayerPrefs.SetInt("PolandCult", (PlayerPrefs.GetInt("PolandCult")) + 1);
                PlayerPrefs.Save();

                SetCultureQuizData(4);

                if (PlayerPrefs.GetInt("PolandCult", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }
        }
        else if (selectedCategory == 5)
        {
            if (PlayerPrefs.GetInt("PolandLang", 0) <= 3)
            {
                PlayerPrefs.SetInt("PolandLang", (PlayerPrefs.GetInt("PolandLang")) + 1);
                PlayerPrefs.Save();

                SetLanguageQuizData(5);

                if (PlayerPrefs.GetInt("PolandLang", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
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
