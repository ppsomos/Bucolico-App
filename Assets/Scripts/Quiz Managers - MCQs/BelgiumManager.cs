using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BelgiumManager : MonoBehaviour
{
    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public string[] historyQues;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[14];
    private Option[] histOp2 = new Option[14];
    private Option[] histOp3 = new Option[14];
    //private Option[] histOp4 = new Option[14];

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

    private Option[] geogOp1 = new Option[7];
    private Option[] geogOp2 = new Option[7];
    private Option[] geogOp3 = new Option[7];
    //private Option[] geogOp4 = new Option[7];

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

    private Option[] foodOp1 = new Option[7];
    private Option[] foodOp2 = new Option[7];
    private Option[] foodOp3 = new Option[7];
    //private Option[] foodOp4 = new Option[7];

    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    //public string[] cultureQues;
    //public static string cultureFinalAnswer;
    //public static int cultureQuizIndex;

    //private Option[] culOp1 = new Option[17];
    //private Option[] culOp2 = new Option[17];
    //private Option[] culOp3 = new Option[17];
    //private Option[] culOp4 = new Option[17];

    //public Text cultureQuestonText;
    //public Text[] cultureOptionTexts;
    //public TextMeshProUGUI cultureScoreText;
    //public GameObject cultureCompleteImage;

    /// <summary>
    /// Language Quiz Data
    /// </summary>
    /// 
    //public string[] languageQues;
    //public static string languageFinalAnswer;
    //public static int languageyQuizIndex;

    //private Option[] langOp1 = new Option[5];
    //private Option[] langOp2 = new Option[5];
    //private Option[] langOp3 = new Option[5];
    //private Option[] langOp4 = new Option[5];

    //public Text languageQuestonText;
    //public Text[] languageOptionTexts;
    //public TextMeshProUGUI languageScoreText;
    //public GameObject languageCompleteImage;


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

    public BoxCollider door2Col;



    void Start()
    {
        selectedCategory = 0;
        PlayerPrefs.SetString("SelectedManager", "BL");

    }

    void Update()
    {

        historyScoreText.text = PlayerPrefs.GetInt("BelgiumHist") + "/14";
        geographyScoreText.text = PlayerPrefs.GetInt("BelgiumGeo") + "/7";
        foodScoreText.text = PlayerPrefs.GetInt("BelgiumFood") + "/7";
        //cultureScoreText.text = PlayerPrefs.GetInt("BelgiumCult") + "/3";
        //languageScoreText.text = PlayerPrefs.GetInt("BelgiumLang") + "/3";


        if (PlayerPrefs.GetInt("BelgiumHist") >=14)
        {
            historyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("BelgiumGeo") >= 7)
        {
            geographyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("BelgiumFood") >= 7)
        {
            foodCompleteImage.SetActive(true);
        }
        //if (PlayerPrefs.GetInt("BelgiumCult") >= 3)
        //{
        //    cultureCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("BelgiumLang") >= 3)
        //{
        //    languageCompleteImage.SetActive(true);
        //}

        if (PlayerPrefs.GetInt("Level2") >= 3)
        {
            door2Col.isTrigger = true;
            congratsPanel.SetActive(true);
            playerController.SetActive(false);

            //GameManagers.score = PlayerPrefs.GetInt("Score") + 15;


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


            PlayerPrefs.SetInt("Level2", 0);
            PlayerPrefs.SetInt("LevelM2", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM2") == 1)
        {
            door2Col.isTrigger = true;

        }

    }

    #region History Quiz Data

    public void SetHistoryQuizData(int index)
    {
        selectedCategory = index;
        SetHistoryOptionData();
        int temp = historyQuizIndex;

        historyQuizIndex = Random.Range(0, historyQues.Length);

        if (temp == historyQuizIndex)
        {
            historyQuizIndex = Random.Range(0, historyQues.Length);
        }

        Debug.Log(historyQuizIndex);

        historyQuestonText.text = historyQues[historyQuizIndex];

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        //historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

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
        //else if (histOp4[historyQuizIndex].tag.Equals(tagNeeded) == true)
        //{
        //    return histOp4[historyQuizIndex];
        //}
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
        //for (int i = 0; i < histOp4.Length; i++)
        //{
        //    histOp4[i] = new Option();
        //}


        //Option1 Data
        histOp1[0].answer = "Beer";
        histOp1[1].answer = "Drums";
        histOp1[2].answer = "La Monnaie De Munt";
        histOp1[3].answer = "Battle of Liège";
        histOp1[4].answer = "A government";
        histOp1[5].answer = "Glassware";
        histOp1[6].answer = "Heisenberg's Uncertainty Principle";
        histOp1[7].answer = "Bussiness Expert System";
        histOp1[8].answer = "Plastic";
        histOp1[9].answer = "Soil";
        histOp1[10].answer = "Uganda";
        histOp1[11].answer = "Abortion";
        histOp1[12].answer = "Gay marriage";
        histOp1[13].answer = "Virginie Efira";
     
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
        histOp1[12].tag = answer.correct.ToString();
        histOp1[13].tag = answer.wrong.ToString();

        //Option2 Data
        histOp2[0].answer = "Water";
        histOp2[1].answer = "The saxophone";
        histOp2[2].answer = "Villa Empain";
        histOp2[3].answer = "First Battle of Ypres";
        histOp2[4].answer = "Electricity";
        histOp2[5].answer = "Lace";
        histOp2[6].answer = "Theory of General Relativity";
        histOp2[7].answer = "Transaction Processing System";
        histOp2[8].answer = "Glass";
        histOp2[9].answer = "Asphalt";
        histOp2[10].answer = "Kenya";
        histOp2[11].answer = "Cannabis";
        histOp2[12].answer = "Prostitution";
        histOp2[13].answer = "Déborah François";

        histOp2[0].tag = answer.wrong.ToString();
        histOp2[1].tag = answer.correct.ToString();
        histOp2[2].tag = answer.wrong.ToString();
        histOp2[3].tag = answer.wrong.ToString();
        histOp2[4].tag = answer.wrong.ToString();
        histOp2[5].tag = answer.correct.ToString();
        histOp2[6].tag = answer.wrong.ToString();
        histOp2[7].tag = answer.wrong.ToString();
        histOp2[8].tag = answer.wrong.ToString();
        histOp2[9].tag = answer.correct.ToString();
        histOp2[10].tag = answer.wrong.ToString();
        histOp2[11].tag = answer.wrong.ToString();
        histOp2[12].tag = answer.wrong.ToString();
        histOp2[13].tag = answer.wrong.ToString();

        //Option3 Data
        histOp3[0].answer = "Juice";
        histOp3[1].answer = "Trumpet";
        histOp3[2].answer = "Atomium";
        histOp3[3].answer = "Battle of the Bulge";
        histOp3[4].answer = "War";
        histOp3[5].answer = "Pottery";
        histOp3[6].answer = "The Big Bang theory ";
        histOp3[7].answer = "Office Automation Systems";
        histOp3[8].answer = "Batteries";
        histOp3[9].answer = "Concrete";
        histOp3[10].answer = "Congo";
        histOp3[11].answer = "Gambling";
        histOp3[12].answer = "Owning a lion";
        histOp3[13].answer = "Audrey Hepburn";

        histOp3[0].tag = answer.wrong.ToString();
        histOp3[1].tag = answer.wrong.ToString();
        histOp3[2].tag = answer.correct.ToString();
        histOp3[3].tag = answer.wrong.ToString();
        histOp3[4].tag = answer.wrong.ToString();
        histOp3[5].tag = answer.wrong.ToString();
        histOp3[6].tag = answer.correct.ToString();
        histOp3[7].tag = answer.wrong.ToString();
        histOp3[8].tag = answer.wrong.ToString();
        histOp3[9].tag = answer.wrong.ToString();
        histOp3[10].tag = answer.correct.ToString();
        histOp3[11].tag = answer.wrong.ToString();
        histOp3[12].tag = answer.wrong.ToString();
        histOp3[13].tag = answer.correct.ToString();


        ////Option4 Data
        //histOp4[0].answer = "Wine";
        //histOp4[1].answer = "Clarinet";
        //histOp4[2].answer = "The royal palace";
        //histOp4[3].answer = "Battle of Waterloo";
        //histOp4[4].answer = "Natural disasters";
        //histOp4[5].answer = "Stoneware";
        //histOp4[6].answer = "Evolution and Natural Selection";
        //histOp4[7].answer = "The World Wide Web";
        //histOp4[8].answer = "Metal";
        //histOp4[9].answer = "Composite Pavement";
        //histOp4[10].answer = "Nigeria";
        //histOp4[11].answer = "Euthanasia";
        //histOp4[12].answer = "Plagiarism";
        //histOp4[13].answer = "Annie Cordy";

        //histOp4[0].tag = answer.wrong.ToString();
        //histOp4[1].tag = answer.wrong.ToString();
        //histOp4[2].tag = answer.wrong.ToString();
        //histOp4[3].tag = answer.correct.ToString();
        //histOp4[4].tag = answer.wrong.ToString();
        //histOp4[5].tag = answer.wrong.ToString();
        //histOp4[6].tag = answer.wrong.ToString();
        //histOp4[7].tag = answer.correct.ToString();
        //histOp4[8].tag = answer.wrong.ToString();
        //histOp4[9].tag = answer.wrong.ToString();
        //histOp4[10].tag = answer.wrong.ToString();
        //histOp4[11].tag = answer.correct.ToString();
        //histOp4[12].tag = answer.wrong.ToString();
        //histOp4[13].tag = answer.wrong.ToString();
    }


    #endregion

    #region Geography Quiz Data

    public void SetGeographyQuizData(int index)
    {
        selectedCategory = index;
        SetGeographyOptionData();

        int temp = geographyQuizIndex;

        geographyQuizIndex = Random.Range(0, geographyQues.Length);

        if (temp == geographyQuizIndex)
        {
            geographyQuizIndex = Random.Range(0, geographyQues.Length);
        }

        Debug.Log(geographyQuizIndex);

        geographyQuestonText.text = geographyQues[geographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
        //geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;

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
        //else if (geogOp4[geographyQuizIndex].tag.Equals(tagNeeded) == true)
        //{
        //    return geogOp4[geographyQuizIndex];
        //}
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
        //for (int i = 0; i < geogOp4.Length; i++)
        //{
        //    geogOp4[i] = new Option();
        //}


        //Option1 Data
        geogOp1[0].answer = "Brussels";
        geogOp1[1].answer = "The Americas";
        geogOp1[2].answer = "Germany and Netherlands";
        geogOp1[3].answer = "Arctic";
        geogOp1[4].answer = "Bruge";
        geogOp1[5].answer = "Bruges";
        geogOp1[6].answer = "The coldest city on earth";

        geogOp1[0].tag = answer.correct.ToString();
        geogOp1[1].tag = answer.wrong.ToString();
        geogOp1[2].tag = answer.wrong.ToString();
        geogOp1[3].tag = answer.wrong.ToString();
        geogOp1[4].tag = answer.correct.ToString();
        geogOp1[5].tag = answer.wrong.ToString();
        geogOp1[6].tag = answer.wrong.ToString();

        //Option2 Data
        geogOp2[0].answer = "Antwerp";
        geogOp2[1].answer = "The EU";
        geogOp2[2].answer = "Netherlands and Luxembourgh";
        geogOp2[3].answer = "Indian";
        geogOp2[4].answer = "Ghent";
        geogOp2[5].answer = "Antwerp";
        geogOp2[6].answer = "A popular beer brewery";

        geogOp2[0].tag = answer.wrong.ToString();
        geogOp2[1].tag = answer.correct.ToString();
        geogOp2[2].tag = answer.wrong.ToString();
        geogOp2[3].tag = answer.wrong.ToString();
        geogOp2[4].tag = answer.wrong.ToString();
        geogOp2[5].tag = answer.correct.ToString();
        geogOp2[6].tag = answer.wrong.ToString();

        //Option3 Data
        geogOp3[0].answer = "Liege";
        geogOp3[1].answer = "The North";
        geogOp3[2].answer = "France and Germany ";
        geogOp3[3].answer = "Pacific";
        geogOp3[4].answer = "Namur";
        geogOp3[5].answer = "Liege";
        geogOp3[6].answer = "The largest trade town";


        geogOp3[0].tag = answer.wrong.ToString();
        geogOp3[1].tag = answer.wrong.ToString();
        geogOp3[2].tag = answer.correct.ToString();
        geogOp3[3].tag = answer.wrong.ToString();
        geogOp3[4].tag = answer.wrong.ToString();
        geogOp3[5].tag = answer.wrong.ToString();
        geogOp3[6].tag = answer.wrong.ToString();


        ////Option4 Data
        //geogOp4[0].answer = "Gent";
        //geogOp4[1].answer = "Central Europe";
        //geogOp4[2].answer = "Luxembourgh and France";
        //geogOp4[3].answer = "Atlantic";
        //geogOp4[4].answer = "Ostend";
        //geogOp4[5].answer = "Mechelen";
        //geogOp4[6].answer = "The smallest city in the world";

        //geogOp4[0].tag = answer.wrong.ToString();
        //geogOp4[1].tag = answer.wrong.ToString();
        //geogOp4[2].tag = answer.wrong.ToString();
        //geogOp4[3].tag = answer.correct.ToString();
        //geogOp4[4].tag = answer.wrong.ToString();
        //geogOp4[5].tag = answer.wrong.ToString();
        //geogOp4[6].tag = answer.correct.ToString();

    }

    #endregion

    #region Food Quiz Data

    public void SetFoodQuizData(int index)
    {
        selectedCategory = index;
        SetFoodOptionData();

        int temp = foodQuizIndex;

        foodQuizIndex = Random.Range(0, foodQues.Length);

        if (temp == foodQuizIndex)
        {
            foodQuizIndex = Random.Range(0, foodQues.Length);
        }

        Debug.Log(foodQuizIndex);

        foodQuestonText.text = foodQues[foodQuizIndex];

        foodOptionTexts[0].text = foodOp1[foodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[foodQuizIndex].answer;
        foodOptionTexts[2].text = foodOp3[foodQuizIndex].answer;
        //foodOptionTexts[3].text = foodOp4[foodQuizIndex].answer;

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
        //else if (foodOp4[foodQuizIndex].tag.Equals(tagNeeded) == true)
        //{
        //    return foodOp4[foodQuizIndex];
        //}
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
        //for (int i = 0; i < foodOp4.Length; i++)
        //{
        //    foodOp4[i] = new Option();
        //}


        //Option1 Data
        foodOp1[0].answer = "Moules-frites";
        foodOp1[1].answer = "1985";
        foodOp1[2].answer = "Tart";
        foodOp1[3].answer = "Ostend and Ghent";
        foodOp1[4].answer = "Beer";
        foodOp1[5].answer = "Côte d’Or";
        foodOp1[6].answer = "Stoemp";


        foodOp1[0].tag = answer.correct.ToString();
        foodOp1[1].tag = answer.wrong.ToString();
        foodOp1[2].tag = answer.wrong.ToString();
        foodOp1[3].tag = answer.wrong.ToString();
        foodOp1[4].tag = answer.correct.ToString();
        foodOp1[5].tag = answer.wrong.ToString();
        foodOp1[6].tag = answer.wrong.ToString();


        //Option2 Data
        foodOp2[0].answer = "Boudin";
        foodOp2[1].answer = "1970";
        foodOp2[2].answer = "Caramel";
        foodOp2[3].answer = "Antwerp and Leuven";
        foodOp2[4].answer = "Coca cola";
        foodOp2[5].answer = "Neuhaus";
        foodOp2[6].answer = "Fries";


        foodOp2[0].tag = answer.wrong.ToString();
        foodOp2[1].tag = answer.correct.ToString();
        foodOp2[2].tag = answer.wrong.ToString();
        foodOp2[3].tag = answer.wrong.ToString();
        foodOp2[4].tag = answer.wrong.ToString();
        foodOp2[5].tag = answer.wrong.ToString();
        foodOp2[6].tag = answer.correct.ToString();


        //Option3 Data
        foodOp3[0].answer = "Stoemp";
        foodOp3[1].answer = "1978";
        foodOp3[2].answer = "Pralines";
        foodOp3[3].answer = "Namur and Charleroi";
        foodOp3[4].answer = "Coffee";
        foodOp3[5].answer = "Leonidas";
        foodOp3[6].answer = "Potatoes au Gratin";


        foodOp3[0].tag = answer.wrong.ToString();
        foodOp3[1].tag = answer.wrong.ToString();
        foodOp3[2].tag = answer.correct.ToString();
        foodOp3[3].tag = answer.wrong.ToString();
        foodOp3[4].tag = answer.wrong.ToString();
        foodOp3[5].tag = answer.wrong.ToString();
        foodOp3[6].tag = answer.wrong.ToString();


        //Option4 Data
        //foodOp4[0].answer = "Sirop de Liège";
        //foodOp4[1].answer = "2007";
        //foodOp4[2].answer = "Waffles";
        //foodOp4[3].answer = "Liege and Brussels";
        //foodOp4[4].answer = "Hot chocolate";
        //foodOp4[5].answer = "Godiva";
        //foodOp4[6].answer = "Pommes Anna";


        //foodOp4[0].tag = answer.wrong.ToString();
        //foodOp4[1].tag = answer.wrong.ToString();
        //foodOp4[2].tag = answer.wrong.ToString();
        //foodOp4[3].tag = answer.correct.ToString();
        //foodOp4[4].tag = answer.wrong.ToString();
        //foodOp4[5].tag = answer.correct.ToString();
        //foodOp4[6].tag = answer.wrong.ToString();

    }


    #endregion

    #region Culture Quiz Data

    //public void SetCultureQuizData(int index)
    //{
    //    selectedCategory = index;
    //    SetCultureOptionData();
    //    int temp = cultureQuizIndex;

    //    cultureQuizIndex = Random.Range(0, cultureQues.Length);

    //    if (temp == cultureQuizIndex)
    //    {
    //        cultureQuizIndex = Random.Range(0, cultureQues.Length);
    //    }

    //    Debug.Log(cultureQuizIndex);

    //    cultureQuestonText.text = cultureQues[cultureQuizIndex];

    //    cultureOptionTexts[0].text = culOp1[cultureQuizIndex].answer;
    //    cultureOptionTexts[1].text = culOp2[cultureQuizIndex].answer;
    //    cultureOptionTexts[2].text = culOp3[cultureQuizIndex].answer;
    //    cultureOptionTexts[3].text = culOp4[cultureQuizIndex].answer;

    //    Option temp1 = FindTagCul(answer.correct.ToString());
    //    cultureFinalAnswer = temp1.answer;

    //    Debug.Log(cultureFinalAnswer);
    //}

    //private Option FindTagCul(string tagNeeded)
    //{
    //    if (culOp1[cultureQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return culOp1[cultureQuizIndex];
    //    }
    //    else if (culOp2[cultureQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return culOp2[cultureQuizIndex];
    //    }
    //    else if (culOp3[cultureQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return culOp3[cultureQuizIndex];
    //    }
    //    else if (culOp4[cultureQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return culOp4[cultureQuizIndex];
    //    }
    //    return null;
    //}
    //private void SetCultureOptionData()
    //{
    //    for (int i = 0; i < culOp1.Length; i++)
    //    {
    //        culOp1[i] = new Option();
    //    }
    //    for (int i = 0; i < culOp2.Length; i++)
    //    {
    //        culOp2[i] = new Option();
    //    }
    //    for (int i = 0; i < culOp3.Length; i++)
    //    {
    //        culOp3[i] = new Option();
    //    }
    //    for (int i = 0; i < culOp4.Length; i++)
    //    {
    //        culOp4[i] = new Option();
    //    }


    //    //Option1 Data
    //    culOp1[0].answer = "Manneken Pis";
    //    culOp1[1].answer = "Doraemon";
    //    culOp1[2].answer = "Saint Fabius";
    //    culOp1[3].answer = "Bat Lash";
    //    culOp1[4].answer = "Tomorrowland";
    //    culOp1[5].answer = "Haddock";
    //    culOp1[6].answer = "Posing";
    //    culOp1[7].answer = "Jean Delville";
    //    culOp1[8].answer = "Football";
    //    culOp1[9].answer = "Factories";
    //    culOp1[10].answer = "The Black Bulls";
    //    culOp1[11].answer = "A path of plants";
    //    culOp1[12].answer = "Cycling";
    //    culOp1[13].answer = "Chuck Noris";
    //    culOp1[14].answer = "Subway";
    //    culOp1[15].answer = "A tall tower";
    //    culOp1[16].answer = "Galeria";

    //    culOp1[0].tag = answer.correct.ToString();
    //    culOp1[1].tag = answer.wrong.ToString();
    //    culOp1[2].tag = answer.wrong.ToString();
    //    culOp1[3].tag = answer.wrong.ToString();
    //    culOp1[4].tag = answer.correct.ToString();
    //    culOp1[5].tag = answer.wrong.ToString();
    //    culOp1[6].tag = answer.wrong.ToString();
    //    culOp1[7].tag = answer.wrong.ToString();
    //    culOp1[8].tag = answer.correct.ToString();
    //    culOp1[9].tag = answer.wrong.ToString();
    //    culOp1[10].tag = answer.wrong.ToString();
    //    culOp1[11].tag = answer.wrong.ToString();
    //    culOp1[12].tag = answer.correct.ToString();
    //    culOp1[13].tag = answer.wrong.ToString();
    //    culOp1[14].tag = answer.wrong.ToString();
    //    culOp1[15].tag = answer.wrong.ToString();
    //    culOp1[16].tag = answer.correct.ToString();

    //    //Option2 Data
    //    culOp2[0].answer = "Christ the Redeemer";
    //    culOp2[1].answer = "Smurfs";
    //    culOp2[2].answer = "Saint Adrian of Canterbury";
    //    culOp2[3].answer = "Jonah Hex";
    //    culOp2[4].answer = "Flow Festival";
    //    culOp2[5].answer = "Tintin";
    //    culOp2[6].answer = "Standing";
    //    culOp2[7].answer = "Henry van de Velde";
    //    culOp2[8].answer = "Rugby";
    //    culOp2[9].answer = "Castles";
    //    culOp2[10].answer = "The Yellow Crabs";
    //    culOp2[11].answer = "A river";
    //    culOp2[12].answer = "Running";
    //    culOp2[13].answer = "Jean-Claude Van Damme";
    //    culOp2[14].answer = "Train line";
    //    culOp2[15].answer = "Wind turbines";
    //    culOp2[16].answer = "Pub";

    //    culOp2[0].tag = answer.wrong.ToString();
    //    culOp2[1].tag = answer.correct.ToString();
    //    culOp2[2].tag = answer.wrong.ToString();
    //    culOp2[3].tag = answer.wrong.ToString();
    //    culOp2[4].tag = answer.wrong.ToString();
    //    culOp2[5].tag = answer.correct.ToString();
    //    culOp2[6].tag = answer.wrong.ToString();
    //    culOp2[7].tag = answer.wrong.ToString();
    //    culOp2[8].tag = answer.wrong.ToString();
    //    culOp2[9].tag = answer.correct.ToString();
    //    culOp2[10].tag = answer.wrong.ToString();
    //    culOp2[11].tag = answer.wrong.ToString();
    //    culOp2[12].tag = answer.wrong.ToString();
    //    culOp2[13].tag = answer.correct.ToString();
    //    culOp2[14].tag = answer.wrong.ToString();
    //    culOp2[15].tag = answer.wrong.ToString();
    //    culOp2[16].tag = answer.wrong.ToString();
       

    //    //Option3 Data
    //    culOp3[0].answer = "The Thinker";
    //    culOp3[1].answer = "Stitch";
    //    culOp3[2].answer = "Saint Nicholas";
    //    culOp3[3].answer = "Billy the Kid";
    //    culOp3[4].answer = "Primavera Sound";
    //    culOp3[5].answer = "Nestor";
    //    culOp3[6].answer = "Peeing";
    //    culOp3[7].answer = "Hugo Debaere";
    //    culOp3[8].answer = "Cricket";
    //    culOp3[9].answer = "Shops";
    //    culOp3[10].answer = "The Red Devils";
    //    culOp3[11].answer = "A bed of hay";
    //    culOp3[12].answer = "Swimming";
    //    culOp3[13].answer = "Jackie Chan";
    //    culOp3[14].answer = "Tramway";
    //    culOp3[15].answer = "A wall";
    //    culOp3[16].answer = "Theatre";

    //    culOp3[0].tag = answer.wrong.ToString();
    //    culOp3[1].tag = answer.wrong.ToString();
    //    culOp3[2].tag = answer.correct.ToString();
    //    culOp3[3].tag = answer.wrong.ToString();
    //    culOp3[4].tag = answer.wrong.ToString();
    //    culOp3[5].tag = answer.wrong.ToString();
    //    culOp3[6].tag = answer.correct.ToString();
    //    culOp3[7].tag = answer.wrong.ToString();
    //    culOp3[8].tag = answer.wrong.ToString();
    //    culOp3[9].tag = answer.wrong.ToString();
    //    culOp3[10].tag = answer.correct.ToString();
    //    culOp3[11].tag = answer.wrong.ToString();
    //    culOp3[12].tag = answer.wrong.ToString();
    //    culOp3[13].tag = answer.wrong.ToString();
    //    culOp3[14].tag = answer.correct.ToString();
    //    culOp3[15].tag = answer.wrong.ToString();
    //    culOp3[16].tag = answer.wrong.ToString();

    //    //Option4 Data
    //    culOp4[0].answer = "The Angel of the North";
    //    culOp4[1].answer = "Sonic";
    //    culOp4[2].answer = "Saint Christopher";
    //    culOp4[3].answer = "Lucky Luke";
    //    culOp4[4].answer = "Coachella";
    //    culOp4[5].answer = "Professor Calculus";
    //    culOp4[6].answer = "Sitting";
    //    culOp4[7].answer = "René Magritte";
    //    culOp4[8].answer = "Volleyball";
    //    culOp4[9].answer = "Museums";
    //    culOp4[10].answer = "The Blue Ogres";
    //    culOp4[11].answer = "A flower carpet";
    //    culOp4[12].answer = "Football";
    //    culOp4[13].answer = "Bruce Lee";
    //    culOp4[14].answer = "Bus line ";
    //    culOp4[15].answer = "Lights";
    //    culOp4[16].answer = "Hospital";

    //    culOp4[0].tag = answer.wrong.ToString();
    //    culOp4[1].tag = answer.wrong.ToString();
    //    culOp4[2].tag = answer.wrong.ToString();
    //    culOp4[3].tag = answer.correct.ToString();
    //    culOp4[4].tag = answer.wrong.ToString();
    //    culOp4[5].tag = answer.wrong.ToString();
    //    culOp4[6].tag = answer.wrong.ToString();
    //    culOp4[7].tag = answer.correct.ToString();
    //    culOp4[8].tag = answer.wrong.ToString();
    //    culOp4[9].tag = answer.wrong.ToString();
    //    culOp4[10].tag = answer.wrong.ToString();
    //    culOp4[11].tag = answer.correct.ToString();
    //    culOp4[12].tag = answer.wrong.ToString();
    //    culOp4[13].tag = answer.wrong.ToString();
    //    culOp4[14].tag = answer.wrong.ToString();
    //    culOp4[15].tag = answer.correct.ToString();
    //    culOp4[16].tag = answer.wrong.ToString();
    //}

    #endregion
    
    #region Language Quiz Data

    //public void SetLanguageQuizData(int index)
    //{
    //    selectedCategory = index;
    //    SetLanguageOptionData();
    //    int temp = languageyQuizIndex;

    //    languageyQuizIndex = Random.Range(0, languageQues.Length);

    //    if (temp == languageyQuizIndex)
    //    {
    //        languageyQuizIndex = Random.Range(0, languageQues.Length);
    //    }

    //    Debug.Log(languageyQuizIndex);

    //    languageQuestonText.text = languageQues[languageyQuizIndex];

    //    languageOptionTexts[0].text = langOp1[languageyQuizIndex].answer;
    //    languageOptionTexts[1].text = langOp2[languageyQuizIndex].answer;
    //    languageOptionTexts[2].text = langOp3[languageyQuizIndex].answer;
    //    languageOptionTexts[3].text = langOp4[languageyQuizIndex].answer;

    //    Option temp1 = FindTagLang(answer.correct.ToString());
    //    languageFinalAnswer = temp1.answer;

    //    Debug.Log(languageFinalAnswer);
    //}

    //private Option FindTagLang(string tagNeeded)
    //{
    //    if (langOp1[languageyQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return langOp1[languageyQuizIndex];
    //    }
    //    else if (langOp2[languageyQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return langOp2[languageyQuizIndex];
    //    }
    //    else if (langOp3[languageyQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return langOp3[languageyQuizIndex];
    //    }
    //    else if (langOp4[languageyQuizIndex].tag.Equals(tagNeeded) == true)
    //    {
    //        return langOp4[languageyQuizIndex];
    //    }
    //    return null;
    //}
    //private void SetLanguageOptionData()
    //{
    //    for (int i = 0; i < langOp1.Length; i++)
    //    {
    //        langOp1[i] = new Option();
    //    }
    //    for (int i = 0; i < langOp2.Length; i++)
    //    {
    //        langOp2[i] = new Option();
    //    }
    //    for (int i = 0; i < langOp3.Length; i++)
    //    {
    //        langOp3[i] = new Option();
    //    }
    //    for (int i = 0; i < langOp4.Length; i++)
    //    {
    //        langOp4[i] = new Option();
    //    }


    //    //Option1 Data
    //    langOp1[0].answer = "3";
    //    langOp1[1].answer = "Dutch and German";
    //    langOp1[2].answer = "Limburg";
    //    langOp1[3].answer = "Liege";
    //    langOp1[4].answer = "Spa";


    //    langOp1[0].tag = answer.correct.ToString();
    //    langOp1[1].tag = answer.wrong.ToString();
    //    langOp1[2].tag = answer.wrong.ToString();
    //    langOp1[3].tag = answer.wrong.ToString();
    //    langOp1[4].tag = answer.correct.ToString();


    //    //Option2 Data
    //    langOp2[0].answer = "1";
    //    langOp2[1].answer = "French and Dutch";
    //    langOp2[2].answer = "Hainaut";
    //    langOp2[3].answer = "Luxembourgh";
    //    langOp2[4].answer = "Onsen";


    //    langOp2[0].tag = answer.wrong.ToString();
    //    langOp2[1].tag = answer.correct.ToString();
    //    langOp2[2].tag = answer.wrong.ToString();
    //    langOp2[3].tag = answer.wrong.ToString();
    //    langOp2[4].tag = answer.wrong.ToString();


    //    //Option3 Data
    //    langOp3[0].answer = "2";
    //    langOp3[1].answer = "German and Flemish";
    //    langOp3[2].answer = "Wallonia";
    //    langOp3[3].answer = "Antwerp";
    //    langOp3[4].answer = "Sauna";


    //    langOp3[0].tag = answer.wrong.ToString();
    //    langOp3[1].tag = answer.wrong.ToString();
    //    langOp3[2].tag = answer.correct.ToString();
    //    langOp3[3].tag = answer.wrong.ToString();
    //    langOp3[4].tag = answer.wrong.ToString();
 

    //    //Option4 Data
    //    langOp4[0].answer = "4";
    //    langOp4[1].answer = "Flemish and Dutch";
    //    langOp4[2].answer = "Namur";
    //    langOp4[3].answer = "Flanders";
    //    langOp4[4].answer = "Hamam";


    //    langOp4[0].tag = answer.wrong.ToString();
    //    langOp4[1].tag = answer.wrong.ToString();
    //    langOp4[2].tag = answer.wrong.ToString();
    //    langOp4[3].tag = answer.correct.ToString();
    //    langOp4[4].tag = answer.wrong.ToString();

    //}


    #endregion


    #region Common Functions

   
    public class Option
    {
        public string answer;
        public string tag;
    }

    public void ResetQuestionaPanel()
    {
        print("Current level Reset" + PlayerPrefs.GetInt("CurrentLevel"));
        print("Current catogory" + selectedCategory);
        if (PlayerPrefs.GetInt("CurrentLevel") == 2)
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
            //else if (selectedCategory == 4)
            //{
            //    SetCultureQuizData(4);
            //    levelFailPanel.SetActive(false);
            //    quizPanel.SetActive(true);
            //}
            //else if (selectedCategory == 5)
            //{
            //    SetLanguageQuizData(5);
            //    levelFailPanel.SetActive(false);
            //    quizPanel.SetActive(true);
            //}
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

        Debug.Log("Came 1");
        if (selectedCategory == 1)
        {
            Debug.Log("Came 2");

            if (text.text.Equals(historyFinalAnswer) == true)
            {
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
                Debug.Log("Correct History Answer Selected");
            }
            else
            {
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
                Debug.Log("Wrong History Answer Selected");
            }
        }
        else if (selectedCategory == 2)
        {
            Debug.Log("Came 3");

            if (text.text.Equals(geographyFinalAnswer) == true)
            {
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
                Debug.Log("Correct geography Answer Selected"); 

            }
            else
            {
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
                Debug.Log("Wrong geography Answer Selected");
            }
        }
        else if (selectedCategory == 3)
        {
            Debug.Log("Came 4");

            if (text.text.Equals(foodFinalAnswer) == true)
            {
                Answerdecision.text = "CorrectAnswer";
                StartCoroutine(CorrectAnswerWait());
                Debug.Log("Correct food Answer Selected");
  
            }
            else
            {
                Answerdecision.text = "WrongAnswer";
                StartCoroutine(WrongAnswerwait());
                Debug.Log("Wrong food Answer Selected");
            }
        }
        //else if (selectedCategory == 4)
        //{
        //    Debug.Log("Came 5");

        //    if (text.text.Equals(cultureFinalAnswer) == true)
        //    {
        //        Answerdecision.text = "CorrectAnswer";
        //        StartCoroutine(CorrectAnswerWait());
        //        Debug.Log("Correct culture Answer Selected");             
        //    }
        //    else
        //    {
        //        Answerdecision.text = "WrongAnswer";
        //        StartCoroutine(WrongAnswerwait());
        //        Debug.Log("Wrong culture Answer Selected");
        //    }
        //}
        //else if (selectedCategory == 5)
        //{
        //    Debug.Log("Came 6");

        //    if (text.text.Equals(languageFinalAnswer) == true)
        //    {
        //        Answerdecision.text = "CorrectAnswer";
        //        StartCoroutine(CorrectAnswerWait());
        //        Debug.Log("Correct language Answer Selected");
        //    }
        //    else
        //    {
        //        Answerdecision.text = "WrongAnswer";
        //        StartCoroutine(WrongAnswerwait());
        //        Debug.Log("Wrong language Answer Selected");
        //    }
        //}
    }

    IEnumerator CorrectAnswerWait()
    {
        yield return new WaitForSeconds(1f);
        Answerdecision.text = "";
        if (selectedCategory == 1)
        {
            if (PlayerPrefs.GetInt("BelgiumHist") <= 14)
            {
                PlayerPrefs.SetInt("BelgiumHist", (PlayerPrefs.GetInt("BelgiumHist")) + 1);
                PlayerPrefs.Save();

                SetHistoryQuizData(1);

                if (PlayerPrefs.GetInt("BelgiumHist") == 14)
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
            if (PlayerPrefs.GetInt("BelgiumGeo") <= 7)
            {
                PlayerPrefs.SetInt("BelgiumGeo", (PlayerPrefs.GetInt("BelgiumGeo")) + 1);
                PlayerPrefs.Save();

                SetGeographyQuizData(2);

                if (PlayerPrefs.GetInt("BelgiumGeo") == 7)
                {
                    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    PlayerPrefs.Save();
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);

                }
            }
        }
        else if (selectedCategory == 3)
        {
            if (PlayerPrefs.GetInt("BelgiumFood") <= 7)
            {
                PlayerPrefs.SetInt("BelgiumFood", (PlayerPrefs.GetInt("BelgiumFood")) + 1);
                PlayerPrefs.Save();

                SetFoodQuizData(3);

                if (PlayerPrefs.GetInt("BelgiumFood") == 7)
                {
                    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    PlayerPrefs.Save();
                    
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                }
            }

            //Debug.Log("Belgium history" + PlayerPrefs.GetInt("BelgiumHist"));
            //Debug.Log("Belgium Geography" + PlayerPrefs.GetInt("BelgiumGeo"));
            //Debug.Log("Belgium Food" + PlayerPrefs.GetInt("BelgiumFood"));
            //Debug.Log("level2" + PlayerPrefs.GetInt("Level2"));
        }
        //else if (selectedCategory == 4)
        //{
        //    if (PlayerPrefs.GetInt("BelgiumCult", 0) <= 3)
        //    {
        //        PlayerPrefs.SetInt("BelgiumCult", (PlayerPrefs.GetInt("BelgiumCult")) + 1);
        //        PlayerPrefs.Save();

        //        SetCultureQuizData(4);

        //        if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3)
        //        {
        //            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
        //            PlayerPrefs.Save();

        //            quizPanel.SetActive(false);
        //            levelCompletePanel.SetActive(true);
        //        }
        //    }
        //}
        //else if (selectedCategory == 5)
        //{
        //    if (PlayerPrefs.GetInt("BelgiumLang", 0) <= 3)
        //    {
        //        PlayerPrefs.SetInt("BelgiumLang", (PlayerPrefs.GetInt("BelgiumLang")) + 1);
        //        PlayerPrefs.Save();

        //        SetLanguageQuizData(5);

        //        if (PlayerPrefs.GetInt("BelgiumLang", 0) == 3)
        //        {
        //            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
        //            PlayerPrefs.Save();

        //            quizPanel.SetActive(false);
        //            levelCompletePanel.SetActive(true);
        //        }
        //    }
        //}
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
