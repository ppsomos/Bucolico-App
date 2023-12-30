using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UKManager : MonoBehaviour
{


//    #region Old Code
//    public Text Answerdecision;
//    /// <summary>
//    /// History Quiz Data
//    /// </summary>
//    /// 

//    public string[] historyQues;
//    public static string historyFinalAnswer;
//    public static int historyQuizIndex;

//    private Option[] histOp1 = new Option[10];
//    private Option[] histOp2 = new Option[10];
//    private Option[] histOp3 = new Option[10];
//    //private Option[] histOp4 = new Option[10];

//    public Text historyQuestonText;
//    public Text[] historyOptionTexts;
//    public TextMeshProUGUI historyScoreText;
//    public GameObject historyCompleteImage;


//    /// <summary>
//    /// Geography Quiz Data
//    /// </summary>
//    /// 
//    public string[] geographyQues;
//    public static string geographyFinalAnswer;
//    public static int geographyQuizIndex;

//    private Option[] geogOp1 = new Option[10];
//    private Option[] geogOp2 = new Option[10];
//    private Option[] geogOp3 = new Option[10];
//    //private Option[] geogOp4 = new Option[10];

//    public Text geographyQuestonText;
//    public Text[] geographyOptionTexts;
//    public TextMeshProUGUI geographyScoreText;
//    public GameObject geographyCompleteImage;

//    /// <summary>
//    /// Food Quiz Data
//    /// </summary>
//    /// 
//    public string[] foodQues;
//    public static string foodFinalAnswer;
//    public static int foodQuizIndex;

//    private Option[] foodOp1 = new Option[10];
//    private Option[] foodOp2 = new Option[10];
//    private Option[] foodOp3 = new Option[10];
//    //private Option[] foodOp4 = new Option[10];

//    public Text foodQuestonText;
//    public Text[] foodOptionTexts;
//    public TextMeshProUGUI foodScoreText;
//    public GameObject foodCompleteImage;


//    enum answer { wrong, correct };
//    public static int selectedCategory = 0;
//    public GameObject quizPanel;
//    public GameObject levelCompletePanel;
//    public GameObject levelFailPanel;

//    public BoxCollider door1Col;
//    public GameObject congratsPanel;
//    public GameObject playerController;


//    void Start()
//    {
//        selectedCategory = 0;
//    }

//    void Update()
//    {
//        historyScoreText.text = PlayerPrefs.GetInt("UKHist") + "/4";
//        geographyScoreText.text = PlayerPrefs.GetInt("UKGeo") + "/4";
//        foodScoreText.text = PlayerPrefs.GetInt("UKFood") + "/2";
//        //cultureScoreText.text = PlayerPrefs.GetInt("UKCult") + "/3";
//        //languageScoreText.text = PlayerPrefs.GetInt("UKLang") + "/3";


//        if (PlayerPrefs.GetInt("UKHist") >= 3)
//        {
//            historyCompleteImage.SetActive(true);
//        }
//        if (PlayerPrefs.GetInt("UKGeo") >= 3)
//        {
//            geographyCompleteImage.SetActive(true);
//        }
//        if (PlayerPrefs.GetInt("UKFood") >= 2)
//        {
//            foodCompleteImage.SetActive(true);
//        }
//        //if (PlayerPrefs.GetInt("UKCult") >= 3)
//        //{
//        //    cultureCompleteImage.SetActive(true);
//        //}
//        //if (PlayerPrefs.GetInt("UKLang") >= 3)
//        //{
//        //    languageCompleteImage.SetActive(true);
//        //}

//        if (PlayerPrefs.GetInt("Level1") >= 3)
//        {
//            PlayerPrefs.SetInt("unlocklevel", 1);
//            door1Col.isTrigger = true;
//            congratsPanel.SetActive(true);

//            GameManagers.score = PlayerPrefs.GetInt("Score") + 15;

//            PlayerPrefs.SetInt("Score", GameManagers.score);
//            PlayerPrefs.Save();


//            // Report a score of 100
//            // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
//            // of a leaderboard named "Sample Leaderboard"
//            GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

//            CountDown.timeRemaining = 300f;
//            CountDown.timerIsRunning = true;
//            PlayerPrefs.SetFloat("TimeRemaining", CountDown.timeRemaining);
//            PlayerPrefs.Save();

//            Debug.Log(CountDown.timeRemaining);


//            playerController.SetActive(false);
//            PlayerPrefs.SetInt("Level1", 0);
//            PlayerPrefs.SetInt("LevelM1", 1);
//            PlayerPrefs.Save();

//        }
//        if (PlayerPrefs.GetInt("LevelM1") == 1)
//        {
//            door1Col.isTrigger = true;

//        }



//    }

//    #region History Quiz Data

//    public void SetHistoryQuizData(int index)
//    {
//        selectedCategory = index;
//        SetHistoryOptionData();
//        int temp = historyQuizIndex;

//        historyQuizIndex = Random.Range(0, historyQues.Length);

//        if (temp == historyQuizIndex)
//        {
//            historyQuizIndex = Random.Range(0, historyQues.Length);
//        }

//        Debug.Log(historyQuizIndex);

//        historyQuestonText.text = historyQues[historyQuizIndex];

//        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
//        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
//        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
//        //historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

//        Option temp1 = FindTagHist(answer.correct.ToString());
//        historyFinalAnswer = temp1.answer;

//        Debug.Log(historyFinalAnswer);
//    }
//    private Option FindTagHist(string tagNeeded)
//    {
//        if (histOp1[historyQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return histOp1[historyQuizIndex];
//        }
//        else if (histOp2[historyQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return histOp2[historyQuizIndex];
//        }
//        else if (histOp3[historyQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return histOp3[historyQuizIndex];
//        }
//        //else if (histOp4[historyQuizIndex].tag.Equals(tagNeeded) == true)
//        //{
//        //    return histOp4[historyQuizIndex];
//        //}
//        return null;
//    }
//    private void SetHistoryOptionData()
//    {
//        for (int i = 0; i < histOp1.Length; i++)
//        {
//            histOp1[i] = new Option();
//        }
//        for (int i = 0; i < histOp2.Length; i++)
//        {
//            histOp2[i] = new Option();
//        }
//        for (int i = 0; i < histOp3.Length; i++)
//        {
//            histOp3[i] = new Option();
//        }
//        //for (int i = 0; i < histOp4.Length; i++)
//        //{
//        //    histOp4[i] = new Option();
//        //}


//        //Option1 Data
//        histOp1[0].answer = "I can take advantage of my company's strengths; since the rural houses are located in the countryside, I can promote that the guests will enjoy a wide social distance, offering a small discount to the residents of the nearby towns and offering the possibility of a COVID-19 test.";
//        histOp1[1].answer = "Create information leaflets about our products and distribute them to farmers in the area to make them aware of us, and ask our customers to recommend us to other farmers if they are satisfied with our products and services.";
//        histOp1[2].answer = "Reduced purchase of raw materials, cost savings, increased process productivity.";
//        histOp1[3].answer = "Fewer technological users than in the city, little institutional support  and poor internet connection.";

//        histOp1[0].tag = answer.correct.ToString();
//        histOp1[1].tag = answer.wrong.ToString();
//        histOp1[2].tag = answer.correct.ToString();
//        histOp1[3].tag = answer.correct.ToString();

//        //Option2 Data
//        histOp2[0].answer = "I can offer a 40% discount to all people who stay in my company's rural houses, this way I will get many people to pay to stay. In addition, I can offer more fun activities to attract more guests.";
//        histOp2[1].answer = "Investigate upcoming trade fairs and exhibitions of agricultural technology products at local, national and international level, and participate by hiring a stand to showcase products to interested groups and potential clients, increasing networking of interest to the company's sector.";
//        histOp2[2].answer = "Increased sales, waste and process productivity.";
//        histOp2[3].answer = "Livestock shortage, lack of space for animals and little institutional support.";


//        histOp2[0].tag = answer.wrong.ToString();
//        histOp2[1].tag = answer.correct.ToString();
//        histOp2[2].tag = answer.wrong.ToString();
//        histOp2[3].tag = answer.wrong.ToString();

//        //Option3 Data
//        histOp3[0].answer = "It would be best to close my business for a while so as not to incur maintenance costs, as there will be no way to have many guests under these circumstances. Perhaps I could ensure COVID-19 security measures in a few months by testing guests for COVID-19 so that they feel safe.";
//        histOp3[1].answer = "Record a video spot and a radio spot, and contact a TV and radio station so that the spot appears several times a day in a good time slot, even if it has a high cost.";
//        histOp3[2].answer = "Reduction of energy consumption, and therefore reduction of electricity and water bills.";
//        histOp3[3].answer = "Little knowledge about livestock farming and its processes, lack of tools and poor internet connection.";

//        histOp3[0].tag = answer.wrong.ToString();
//        histOp3[1].tag = answer.wrong.ToString();
//        histOp3[2].tag = answer.wrong.ToString();
//        histOp3[3].tag = answer.wrong.ToString();
//        //histOp3[4].tag = answer.wrong.ToString();
//        //histOp3[5].tag = answer.wrong.ToString();
//        //histOp3[6].tag = answer.wrong.ToString();
//        //histOp3[7].tag = answer.correct.ToString();
//        //histOp3[8].tag = answer.wrong.ToString();
//        //histOp3[9].tag = answer.wrong.ToString();

//        //Option4 Data
//        //histOp4[0].answer = "The Tower of London";
//        //histOp4[1].answer = "Telephones";
//        //histOp4[2].answer = "Ernest Rutherford";
//        //histOp4[3].answer = "The Yorkshire Ripper";
//        //histOp4[4].answer = "Plymouth";
//        //histOp4[5].answer = "Wimbledon";
//        //histOp4[6].answer = "Diane Abbott";
//        //histOp4[7].answer = "Richard III";
//        //histOp4[8].answer = "The Battle of the Boyne (1690)";
//        //histOp4[9].answer = "John Locke";

//        //histOp4[0].tag = answer.wrong.ToString();
//        //histOp4[1].tag = answer.wrong.ToString();
//        //histOp4[2].tag = answer.wrong.ToString();
//        //histOp4[3].tag = answer.wrong.ToString();
//        //histOp4[4].tag = answer.wrong.ToString();
//        //histOp4[5].tag = answer.correct.ToString();
//        //histOp4[6].tag = answer.wrong.ToString();
//        //histOp4[7].tag = answer.wrong.ToString();
//        //histOp4[8].tag = answer.wrong.ToString();
//        //histOp4[9].tag = answer.correct.ToString();
//    }

//    #endregion

//    #region Geography Quiz Data

//    public void SetGeographyQuizData(int index)
//    {
//        selectedCategory = index;
//        SetGeographyOptionData();

//        int temp = geographyQuizIndex;

//        geographyQuizIndex = Random.Range(0, geographyQues.Length);

//        if (temp == geographyQuizIndex)
//        {
//            geographyQuizIndex = Random.Range(0, geographyQues.Length);
//        }

//        Debug.Log(geographyQuizIndex);

//        geographyQuestonText.text = geographyQues[geographyQuizIndex];

//        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
//        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
//        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
//        //geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;

//        Option temp1 = FindTagGeo(answer.correct.ToString());
//        geographyFinalAnswer = temp1.answer;

//        Debug.Log(geographyFinalAnswer);
//    }
//    private Option FindTagGeo(string tagNeeded)
//    {
//        if (geogOp1[geographyQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return geogOp1[geographyQuizIndex];
//        }
//        else if (geogOp2[geographyQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return geogOp2[geographyQuizIndex];
//        }
//        else if (geogOp3[geographyQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return geogOp3[geographyQuizIndex];
//        }
//        //else if (geogOp4[geographyQuizIndex].tag.Equals(tagNeeded) == true)
//        //{
//        //    return geogOp4[geographyQuizIndex];
//        //}
//        return null;
//    }
//    private void SetGeographyOptionData()
//    {
//        for (int i = 0; i < geogOp1.Length; i++)
//        {
//            geogOp1[i] = new Option();
//        }
//        for (int i = 0; i < geogOp2.Length; i++)
//        {
//            geogOp2[i] = new Option();
//        }
//        for (int i = 0; i < geogOp3.Length; i++)
//        {
//            geogOp3[i] = new Option();
//        }
//        //for (int i = 0; i < geogOp4.Length; i++)
//        //{
//        //    geogOp4[i] = new Option();
//        //}


//        //Option1 Data
//        geogOp1[0].answer = "Social entrepreneurship is when the ultimate goal is to obtain the maximum economic benefit while creating value in society.";
//        geogOp1[1].answer = "Check-in and check-out traditionally occur at the hotel reception, as a fundamental part of hotel management. However, many times the standard procedures cause delays and long queue. From the need to simplify the process, you think at online check-in as a common practice in your hotel. ";
//        geogOp1[2].answer = "Initial investments are smaller, as there is no need for physical premises, expensive machinery or raw materials, and you can work with customers from all over the world.";
//        geogOp1[3].answer = "You keep your talent for yourself. Just sharing with your family and closet friends ";
//        //geogOp1[4].answer = "The river Thames";
//        //geogOp1[5].answer = "1";
//        //geogOp1[6].answer = "Highclere Castle";
//        //geogOp1[7].answer = "Andalusia";
//        //geogOp1[8].answer = "Newbury";
//        //geogOp1[9].answer = "St. James' Palace";

//        geogOp1[0].tag = answer.wrong.ToString();
//        geogOp1[1].tag = answer.correct.ToString();
//        geogOp1[2].tag = answer.correct.ToString();
//        geogOp1[3].tag = answer.wrong.ToString();
//        //geogOp1[4].tag = answer.correct.ToString();
//        //geogOp1[5].tag = answer.wrong.ToString();
//        //geogOp1[6].tag = answer.wrong.ToString();
//        //geogOp1[7].tag = answer.wrong.ToString();
//        //geogOp1[8].tag = answer.wrong.ToString();
//        //geogOp1[9].tag = answer.wrong.ToString();

//        //Option2 Data
//        geogOp2[0].answer = "Social entrepreneurship is a type of business that is especially dedicated to increasing the network of contacts in society.";
//        geogOp2[1].answer = "Respecting the new safety measures, you strenght the prevenitng measures but you don't feel to get rid of some time-consuming procedures such as check-in in person.";
//        geogOp2[2].answer = "Mainly, you will be able to have a large number of customers from all over the world, although the start-up costs of the company will be very high.";
//        geogOp2[3].answer = "You think how to merge your passion for photography, the digital and in a great entrepreneurial product.";
//        //geogOp2[4].answer = "The river Severn";
//        //geogOp2[5].answer = "4";
//        //geogOp2[6].answer = "Warwick Castle";
//        //geogOp2[7].answer = "Basque Country";
//        //geogOp2[8].answer = "Winchester";
//        //geogOp2[9].answer = "Kensington Palace";

//        geogOp2[0].tag = answer.wrong.ToString();
//        geogOp2[1].tag = answer.wrong.ToString();
//        geogOp2[2].tag = answer.wrong.ToString();
//        geogOp2[3].tag = answer.correct.ToString();
//        //geogOp2[4].tag = answer.wrong.ToString();
//        //geogOp2[5].tag = answer.correct.ToString();
//        //geogOp2[6].tag = answer.wrong.ToString();
//        //geogOp2[7].tag = answer.wrong.ToString();
//        //geogOp2[8].tag = answer.correct.ToString();
//        //geogOp2[9].tag = answer.wrong.ToString();

//        //Option3 Data
//        geogOp3[0].answer = "Social entrepreneurship is when the ultimate goal is not the maximisation of economic profit, but the creation of value for society.";
//        geogOp3[1].answer = "You keep on with the traditional check-in as you consider it safe for personal data protection.";
//        geogOp3[2].answer = "The main advantage of a technology start-up is that it is risk-free for the entrepreneur.";
//        geogOp3[3].answer = "You stamp all you best photos and stick to the wall of your city as marketing promotion of you talent.";
//        //geogOp3[4].answer = "The river Trent";
//        //geogOp3[5].answer = "3";
//        //geogOp3[6].answer = "Windsor Castle";
//        //geogOp3[7].answer = "Falkland Islands";
//        //geogOp3[8].answer = "Bristol";
//        //geogOp3[9].answer = "Windsor Castle";

//        geogOp3[0].tag = answer.correct.ToString();
//        geogOp3[1].tag = answer.wrong.ToString();
//        geogOp3[2].tag = answer.wrong.ToString();
//        geogOp3[3].tag = answer.wrong.ToString();
//        //geogOp3[4].tag = answer.wrong.ToString();
//        //geogOp3[5].tag = answer.wrong.ToString();
//        //geogOp3[6].tag = answer.correct.ToString();
//        //geogOp3[7].tag = answer.wrong.ToString();
//        //geogOp3[8].tag = answer.wrong.ToString();
//        //geogOp3[9].tag = answer.wrong.ToString();

//        //Option4 Data
//        //geogOp4[0].answer = "Oxford";
//        //geogOp4[1].answer = "Gatwick";
//        //geogOp4[2].answer = "Northern Ireland";
//        //geogOp4[3].answer = "The United States of America";
//        //geogOp4[4].answer = "The river Tyne";
//        //geogOp4[5].answer = "5";
//        //geogOp4[6].answer = "Bamburgh Castle";
//        //geogOp4[7].answer = "Gibraltar";
//        //geogOp4[8].answer = "Reading";
//        //geogOp4[9].answer = "Buckingham Palace";

//        //geogOp4[0].tag = answer.wrong.ToString();
//        //geogOp4[1].tag = answer.wrong.ToString();
//        //geogOp4[2].tag = answer.wrong.ToString();
//        //geogOp4[3].tag = answer.correct.ToString();
//        //geogOp4[4].tag = answer.wrong.ToString();
//        //geogOp4[5].tag = answer.wrong.ToString();
//        //geogOp4[6].tag = answer.wrong.ToString();
//        //geogOp4[7].tag = answer.correct.ToString();
//        //geogOp4[8].tag = answer.wrong.ToString();
//        //geogOp4[9].tag = answer.correct.ToString();
//    }

//    #endregion

//    #region Food Quiz Data

//    public void SetFoodQuizData(int index)
//    {
//        selectedCategory = index;
//        SetFoodOptionData();

//        int temp = foodQuizIndex;

//        foodQuizIndex = Random.Range(0, foodQues.Length);

//        if (temp == foodQuizIndex)
//        {
//            foodQuizIndex = Random.Range(0, foodQues.Length);
//        }

//        Debug.Log(foodQuizIndex);

//        foodQuestonText.text = foodQues[foodQuizIndex];

//        foodOptionTexts[0].text = foodOp1[foodQuizIndex].answer;
//        foodOptionTexts[1].text = foodOp2[foodQuizIndex].answer;
//        foodOptionTexts[2].text = foodOp3[foodQuizIndex].answer;
//        //foodOptionTexts[3].text = foodOp4[foodQuizIndex].answer;

//        Option temp1 = FindTagFood(answer.correct.ToString());
//        foodFinalAnswer = temp1.answer;

//        Debug.Log(foodFinalAnswer);
//    }

//    private Option FindTagFood(string tagNeeded)
//    {
//        if (foodOp1[foodQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return foodOp1[foodQuizIndex];
//        }
//        else if (foodOp2[foodQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return foodOp2[foodQuizIndex];
//        }
//        else if (foodOp3[foodQuizIndex].tag.Equals(tagNeeded) == true)
//        {
//            return foodOp3[foodQuizIndex];
//        }
//        //else if (foodOp4[foodQuizIndex].tag.Equals(tagNeeded) == true)
//        //{
//        //    return foodOp4[foodQuizIndex];
//        //}
//        return null;
//    }

//    private void SetFoodOptionData()
//    {
//        for (int i = 0; i < foodOp1.Length; i++)
//        {
//            foodOp1[i] = new Option();
//        }
//        for (int i = 0; i < foodOp2.Length; i++)
//        {
//            foodOp2[i] = new Option();
//        }
//        for (int i = 0; i < foodOp3.Length; i++)
//        {
//            foodOp3[i] = new Option();
//        }
//        //for (int i = 0; i < foodOp4.Length; i++)
//        //{
//        //    foodOp4[i] = new Option();
//        //}


//        //Option1 Data
//        foodOp1[0].answer = "You create information leaflets about you as a teacher of languages and distribute them to after-school clubs, cultural centres, creative circles for kids.";
//        foodOp1[1].answer = "You show resilience and rethink at a new way to support you patients through online counselling . With live chat you can easily and simply communicate with a patient by text, even while on a video call with a different patient.";
//        //foodOp1[2].answer = "Pizza";
//        //foodOp1[3].answer = "Bhuna";
//        //foodOp1[4].answer = "Coronation chicken";
//        //foodOp1[5].answer = "Cheese";
//        //foodOp1[6].answer = "Moreish margaret";
//        //foodOp1[7].answer = "Scotch egg";
//        //foodOp1[8].answer = "Full English";
//        //foodOp1[9].answer = "Poland";

//        foodOp1[0].tag = answer.wrong.ToString();
//        foodOp1[1].tag = answer.correct.ToString();
//        //foodOp1[2].tag = answer.wrong.ToString();
//        //foodOp1[3].tag = answer.wrong.ToString();
//        //foodOp1[4].tag = answer.correct.ToString();
//        //foodOp1[5].tag = answer.wrong.ToString();
//        //foodOp1[6].tag = answer.wrong.ToString();
//        //foodOp1[7].tag = answer.wrong.ToString();
//        //foodOp1[8].tag = answer.correct.ToString();
//        //foodOp1[9].tag = answer.wrong.ToString();

//        //Option2 Data
//        foodOp2[0].answer = "You think in a toy -focused on the interests of the child- with which childrens could learn vocabulary at home while they are playing. ";
//        foodOp2[1].answer = "You send e-mails to all patients reassuring them that everything will be fine and that you will soon be able to continue the face-to-face counselling. ";
//        //foodOp2[2].answer = "Curry";
//        //foodOp2[3].answer = "Biryani";
//        //foodOp2[4].answer = "Fish and chips";
//        //foodOp2[5].answer = "Fish";
//        //foodOp2[6].answer = "Sunburnt sally";
//        //foodOp2[7].answer = "Neeps and tatties";
//        //foodOp2[8].answer = "Continental breakfast";
//        //foodOp2[9].answer = "France";

//        foodOp2[0].tag = answer.correct.ToString();
//        foodOp2[1].tag = answer.wrong.ToString();
//        //foodOp2[2].tag = answer.wrong.ToString();
//        //foodOp2[3].tag = answer.wrong.ToString();
//        //foodOp2[4].tag = answer.wrong.ToString();
//        //foodOp2[5].tag = answer.correct.ToString();
//        //foodOp2[6].tag = answer.wrong.ToString();
//        //foodOp2[7].tag = answer.wrong.ToString();
//        //foodOp2[8].tag = answer.wrong.ToString();
//        //foodOp2[9].tag = answer.correct.ToString();

//        //Option3 Data
//        foodOp3[0].answer = "You keep on playing games and learning languages in a traditional way.";
//        foodOp3[1].answer = "Just sit and wait that the pandemic ends in order to open again your clinic.";
//        //foodOp3[2].answer = "Roast dinner";
//        //foodOp3[3].answer = "Rogan josh";
//        //foodOp3[4].answer = "Full English";
//        //foodOp3[5].answer = "Soup";
//        //foodOp3[6].answer = "Spotted dick";
//        //foodOp3[7].answer = "Scran";
//        //foodOp3[8].answer = "Scottish standard";
//        //foodOp3[9].answer = "Italy";

//        foodOp3[0].tag = answer.wrong.ToString();
//        foodOp3[1].tag = answer.wrong.ToString();
//        //foodOp3[2].tag = answer.correct.ToString();
//        //foodOp3[3].tag = answer.wrong.ToString();
//        //foodOp3[4].tag = answer.wrong.ToString();
//        //foodOp3[5].tag = answer.wrong.ToString();
//        //foodOp3[6].tag = answer.correct.ToString();
//        //foodOp3[7].tag = answer.wrong.ToString();
//        //foodOp3[8].tag = answer.wrong.ToString();
//        //foodOp3[9].tag = answer.wrong.ToString();

//        //Option4 Data
//        //foodOp4[0].answer = "Chicken noodle soup";
//        //foodOp4[1].answer = "Juice";
//        //foodOp4[2].answer = "Spaghetti Bolognese";
//        //foodOp4[3].answer = "Chicken tikka masala";
//        //foodOp4[4].answer = "Roast dinner";
//        //foodOp4[5].answer = "Bread";
//        //foodOp4[6].answer = "Pale harry";
//        //foodOp4[7].answer = "Haggis";
//        //foodOp4[8].answer = "Welsh surprise";
//        //foodOp4[9].answer = "The Netherlands";

//        //foodOp4[0].tag = answer.wrong.ToString();
//        //foodOp4[1].tag = answer.wrong.ToString();
//        //foodOp4[2].tag = answer.wrong.ToString();
//        //foodOp4[3].tag = answer.correct.ToString();
//        //foodOp4[4].tag = answer.wrong.ToString();
//        //foodOp4[5].tag = answer.wrong.ToString();
//        //foodOp4[6].tag = answer.wrong.ToString();
//        //foodOp4[7].tag = answer.correct.ToString();
//        //foodOp4[8].tag = answer.wrong.ToString();
//        //foodOp4[9].tag = answer.wrong.ToString();
//    }




//    #endregion

//    #region Culture Quiz Data

//    //public void SetCultureQuizData(int index)
//    //{
//    //    selectedCategory = index;
//    //    SetCultureOptionData();
//    //    int temp = cultureQuizIndex;

//    //    cultureQuizIndex = Random.Range(0, cultureQues.Length);

//    //    if (temp == cultureQuizIndex)
//    //    {
//    //        cultureQuizIndex = Random.Range(0, cultureQues.Length);
//    //    }

//    //    Debug.Log(cultureQuizIndex);

//    //    cultureQuestonText.text = cultureQues[cultureQuizIndex];

//    //    cultureOptionTexts[0].text = culOp1[cultureQuizIndex].answer;
//    //    cultureOptionTexts[1].text = culOp2[cultureQuizIndex].answer;
//    //    cultureOptionTexts[2].text = culOp3[cultureQuizIndex].answer;
//    //    cultureOptionTexts[3].text = culOp4[cultureQuizIndex].answer;

//    //    Option temp1 = FindTagCul(answer.correct.ToString());
//    //    cultureFinalAnswer = temp1.answer;

//    //    Debug.Log(cultureFinalAnswer);
//    //}

//    //private Option FindTagCul(string tagNeeded)
//    //{
//    //    if (culOp1[cultureQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return culOp1[cultureQuizIndex];
//    //    }
//    //    else if (culOp2[cultureQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return culOp2[cultureQuizIndex];
//    //    }
//    //    else if (culOp3[cultureQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return culOp3[cultureQuizIndex];
//    //    }
//    //    else if (culOp4[cultureQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return culOp4[cultureQuizIndex];
//    //    }
//    //    return null;
//    //}
//    //private void SetCultureOptionData()
//    //{
//    //    for (int i = 0; i < culOp1.Length; i++)
//    //    {
//    //        culOp1[i] = new Option();
//    //    }
//    //    for (int i = 0; i < culOp2.Length; i++)
//    //    {
//    //        culOp2[i] = new Option();
//    //    }
//    //    for (int i = 0; i < culOp3.Length; i++)
//    //    {
//    //        culOp3[i] = new Option();
//    //    }
//    //    for (int i = 0; i < culOp4.Length; i++)
//    //    {
//    //        culOp4[i] = new Option();
//    //    }


//    //    //Option1 Data
//    //    culOp1[0].answer = "God Save the Queen";
//    //    culOp1[1].answer = "Elephant";
//    //    culOp1[2].answer = "Blu";
//    //    culOp1[3].answer = "Cricket";
//    //    culOp1[4].answer = "Liverpool";
//    //    culOp1[5].answer = "Lily";
//    //    culOp1[6].answer = "Tuppence";
//    //    culOp1[7].answer = "Highlander";
//    //    culOp1[8].answer = "2012";
//    //    culOp1[9].answer = "Princess Beatrice";

//    //    culOp1[0].tag = answer.correct.ToString();
//    //    culOp1[1].tag = answer.wrong.ToString();
//    //    culOp1[2].tag = answer.wrong.ToString();
//    //    culOp1[3].tag = answer.wrong.ToString();
//    //    culOp1[4].tag = answer.correct.ToString();
//    //    culOp1[5].tag = answer.wrong.ToString();
//    //    culOp1[6].tag = answer.wrong.ToString();
//    //    culOp1[7].tag = answer.wrong.ToString();
//    //    culOp1[8].tag = answer.correct.ToString();
//    //    culOp1[9].tag = answer.wrong.ToString();

//    //    //Option2 Data
//    //    culOp2[0].answer = "Rule Brittania";
//    //    culOp2[1].answer = "Lion";
//    //    culOp2[2].answer = "Union Master";
//    //    culOp2[3].answer = "Rugby";
//    //    culOp2[4].answer = "Leeds";
//    //    culOp2[5].answer = "Rose";
//    //    culOp2[6].answer = "British Dollar";
//    //    culOp2[7].answer = "Scots Skirt";
//    //    culOp2[8].answer = "2008";
//    //    culOp2[9].answer = "Diana, Princess of Wales";

//    //    culOp2[0].tag = answer.wrong.ToString();
//    //    culOp2[1].tag = answer.correct.ToString();
//    //    culOp2[2].tag = answer.wrong.ToString();
//    //    culOp2[3].tag = answer.wrong.ToString();
//    //    culOp2[4].tag = answer.wrong.ToString();
//    //    culOp2[5].tag = answer.correct.ToString();
//    //    culOp2[6].tag = answer.wrong.ToString();
//    //    culOp2[7].tag = answer.wrong.ToString();
//    //    culOp2[8].tag = answer.wrong.ToString();
//    //    culOp2[9].tag = answer.correct.ToString();

//    //    //Option3 Data
//    //    culOp3[0].answer = "Land of Hope and Glory";
//    //    culOp3[1].answer = "Scottish Terrier";
//    //    culOp3[2].answer = "Banksy";
//    //    culOp3[3].answer = "Football";
//    //    culOp3[4].answer = "Manchester";
//    //    culOp3[5].answer = "Tulip";
//    //    culOp3[6].answer = "British Pound";
//    //    culOp3[7].answer = "Lederhosen";
//    //    culOp3[8].answer = "2004";
//    //    culOp3[9].answer = "Princess Charlotte";

//    //    culOp3[0].tag = answer.wrong.ToString();
//    //    culOp3[1].tag = answer.wrong.ToString();
//    //    culOp3[2].tag = answer.correct.ToString();
//    //    culOp3[3].tag = answer.wrong.ToString();
//    //    culOp3[4].tag = answer.wrong.ToString();
//    //    culOp3[5].tag = answer.wrong.ToString();
//    //    culOp3[6].tag = answer.correct.ToString();
//    //    culOp3[7].tag = answer.wrong.ToString();
//    //    culOp3[8].tag = answer.wrong.ToString();
//    //    culOp3[9].tag = answer.wrong.ToString();

//    //    //Option4 Data
//    //    culOp4[0].answer = "White Cliffs of Dover";
//    //    culOp4[1].answer = "Horse";
//    //    culOp4[2].answer = "Anonymous";
//    //    culOp4[3].answer = "Basketball";
//    //    culOp4[4].answer = "London";
//    //    culOp4[5].answer = "Daffodil";
//    //    culOp4[6].answer = "Euro";
//    //    culOp4[7].answer = "Kilt";
//    //    culOp4[8].answer = "2000";
//    //    culOp4[9].answer = "Sarah Ferguson, Duchess of York";

//    //    culOp4[0].tag = answer.wrong.ToString();
//    //    culOp4[1].tag = answer.wrong.ToString();
//    //    culOp4[2].tag = answer.wrong.ToString();
//    //    culOp4[3].tag = answer.correct.ToString();
//    //    culOp4[4].tag = answer.wrong.ToString();
//    //    culOp4[5].tag = answer.wrong.ToString();
//    //    culOp4[6].tag = answer.wrong.ToString();
//    //    culOp4[7].tag = answer.correct.ToString();
//    //    culOp4[8].tag = answer.wrong.ToString();
//    //    culOp4[9].tag = answer.wrong.ToString();
//    //}




//    #endregion

//    #region Language Quiz Data


//    //public void SetLanguageQuizData(int index)
//    //{
//    //    selectedCategory = index;
//    //    SetLanguageOptionData();
//    //    int temp = languageyQuizIndex;

//    //    languageyQuizIndex = Random.Range(0, languageQues.Length);

//    //    if (temp == languageyQuizIndex)
//    //    {
//    //        languageyQuizIndex = Random.Range(0, languageQues.Length);
//    //    }

//    //    Debug.Log(languageyQuizIndex);

//    //    languageQuestonText.text = languageQues[languageyQuizIndex];

//    //    languageOptionTexts[0].text = langOp1[languageyQuizIndex].answer;
//    //    languageOptionTexts[1].text = langOp2[languageyQuizIndex].answer;
//    //    languageOptionTexts[2].text = langOp3[languageyQuizIndex].answer;
//    //    languageOptionTexts[3].text = langOp4[languageyQuizIndex].answer;

//    //    Option temp1 = FindTagLang(answer.correct.ToString());
//    //    languageFinalAnswer = temp1.answer;

//    //    Debug.Log(languageFinalAnswer);
//    //}

//    //private Option FindTagLang(string tagNeeded)
//    //{
//    //    if (langOp1[languageyQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return langOp1[languageyQuizIndex];
//    //    }
//    //    else if (langOp2[languageyQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return langOp2[languageyQuizIndex];
//    //    }
//    //    else if (langOp3[languageyQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return langOp3[languageyQuizIndex];
//    //    }
//    //    else if (langOp4[languageyQuizIndex].tag.Equals(tagNeeded) == true)
//    //    {
//    //        return langOp4[languageyQuizIndex];
//    //    }
//    //    return null;
//    //}
//    //private void SetLanguageOptionData()
//    //{
//    //    for (int i = 0; i < langOp1.Length; i++)
//    //    {
//    //        langOp1[i] = new Option();
//    //    }
//    //    for (int i = 0; i < langOp2.Length; i++)
//    //    {
//    //        langOp2[i] = new Option();
//    //    }
//    //    for (int i = 0; i < langOp3.Length; i++)
//    //    {
//    //        langOp3[i] = new Option();
//    //    }
//    //    for (int i = 0; i < langOp4.Length; i++)
//    //    {
//    //        langOp4[i] = new Option();
//    //    }


//    //    //Option1 Data
//    //    langOp1[0].answer = "Polish";
//    //    langOp1[1].answer = "Scots";
//    //    langOp1[2].answer = "Oscar Wilde";
//    //    langOp1[3].answer = "English Standard Version";
//    //    langOp1[4].answer = "Jane Austen";
//    //    langOp1[5].answer = "I prefer coffee";
//    //    langOp1[6].answer = "Sounding 'fancy'";
//    //    langOp1[7].answer = "Guy";
//    //    langOp1[8].answer = "The UK leaving the European Union";
//    //    langOp1[9].answer = "Jane Austen";

//    //    langOp1[0].tag = answer.correct.ToString();
//    //    langOp1[1].tag = answer.wrong.ToString();
//    //    langOp1[2].tag = answer.wrong.ToString();
//    //    langOp1[3].tag = answer.wrong.ToString();
//    //    langOp1[4].tag = answer.correct.ToString();
//    //    langOp1[5].tag = answer.wrong.ToString();
//    //    langOp1[6].tag = answer.wrong.ToString();
//    //    langOp1[7].tag = answer.wrong.ToString();
//    //    langOp1[8].tag = answer.correct.ToString();
//    //    langOp1[9].tag = answer.wrong.ToString();

//    //    //Option2 Data
//    //    langOp2[0].answer = "Arabic";
//    //    langOp2[1].answer = "Anglo-Saxon";
//    //    langOp2[2].answer = "T. S. Elliot";
//    //    langOp2[3].answer = "New Living Translation";
//    //    langOp2[4].answer = "Mary Shelley";
//    //    langOp2[5].answer = "I'm not interested at all in it";
//    //    langOp2[6].answer = "Being similar across all regions";
//    //    langOp2[7].answer = "Lad";
//    //    langOp2[8].answer = "The UK joining the European Union";
//    //    langOp2[9].answer = "Jeanette Winterson";

//    //    langOp2[0].tag = answer.wrong.ToString();
//    //    langOp2[1].tag = answer.correct.ToString();
//    //    langOp2[2].tag = answer.wrong.ToString();
//    //    langOp2[3].tag = answer.wrong.ToString();
//    //    langOp2[4].tag = answer.wrong.ToString();
//    //    langOp2[5].tag = answer.correct.ToString();
//    //    langOp2[6].tag = answer.wrong.ToString();
//    //    langOp2[7].tag = answer.wrong.ToString();
//    //    langOp2[8].tag = answer.wrong.ToString();
//    //    langOp2[9].tag = answer.wrong.ToString();

//    //    //Option3 Data
//    //    langOp3[0].answer = "Mandarin";
//    //    langOp3[1].answer = "Gaelic";
//    //    langOp3[2].answer = "William Shakespeare ";
//    //    langOp3[3].answer = "New International Version";
//    //    langOp3[4].answer = "Virginia Woolf";
//    //    langOp3[5].answer = "I feel neutral about it";
//    //    langOp3[6].answer = "Being extremely diverse in such a small geographic area";
//    //    langOp3[7].answer = "Bloke";
//    //    langOp3[8].answer = "The UK changing its prime minister";
//    //    langOp3[9].answer = "Virginia Woolf";

//    //    langOp3[0].tag = answer.wrong.ToString();
//    //    langOp3[1].tag = answer.wrong.ToString();
//    //    langOp3[2].tag = answer.correct.ToString();
//    //    langOp3[3].tag = answer.wrong.ToString();
//    //    langOp3[4].tag = answer.wrong.ToString();
//    //    langOp3[5].tag = answer.wrong.ToString();
//    //    langOp3[6].tag = answer.correct.ToString();
//    //    langOp3[7].tag = answer.wrong.ToString();
//    //    langOp3[8].tag = answer.wrong.ToString();
//    //    langOp3[9].tag = answer.wrong.ToString();

//    //    //Option4 Data
//    //    langOp4[0].answer = "Spanish";
//    //    langOp4[1].answer = "Welsh";
//    //    langOp4[2].answer = "J. B. Priestley";
//    //    langOp4[3].answer = "King James Version";
//    //    langOp4[4].answer = "Charlotte Bronte";
//    //    langOp4[5].answer = "It's not mine, it's yours";
//    //    langOp4[6].answer = "Being very easy to understand";
//    //    langOp4[7].answer = "Bird";
//    //    langOp4[8].answer = "The UK changing its governing body";
//    //    langOp4[9].answer = "J. R. R. Tolkien";

//    //    langOp4[0].tag = answer.wrong.ToString();
//    //    langOp4[1].tag = answer.wrong.ToString();
//    //    langOp4[2].tag = answer.wrong.ToString();
//    //    langOp4[3].tag = answer.correct.ToString();
//    //    langOp4[4].tag = answer.wrong.ToString();
//    //    langOp4[5].tag = answer.wrong.ToString();
//    //    langOp4[6].tag = answer.wrong.ToString();
//    //    langOp4[7].tag = answer.correct.ToString();
//    //    langOp4[8].tag = answer.wrong.ToString();
//    //    langOp4[9].tag = answer.correct.ToString();
//    //}


//    #endregion


//    #region Common Functions


//    public class Option
//    {
//        public string answer;
//        public string tag;
//    }

//    public void ResetQuestionaPanel()
//    {
//        Debug.Log("Came here1");

//        if (PlayerPrefs.GetInt("CurrentLevel") == 1)
//        {
//            Debug.Log("Came here2");

//            if (selectedCategory == 1)
//            {
//                SetHistoryQuizData(1);
//                levelFailPanel.SetActive(false);
//                quizPanel.SetActive(true);
//            }
//            else if (selectedCategory == 2)
//            {
//                SetGeographyQuizData(2);
//                levelFailPanel.SetActive(false);
//                quizPanel.SetActive(true);
//            }
//            else if (selectedCategory == 3)
//            {
//                SetFoodQuizData(3);
//                levelFailPanel.SetActive(false);
//                quizPanel.SetActive(true);
//            }
//            //else if (selectedCategory == 4)
//            //{
//            //    SetCultureQuizData(4);
//            //    levelFailPanel.SetActive(false);
//            //    quizPanel.SetActive(true);
//            //}
//            //else if (selectedCategory == 5)
//            //{
//            //    SetLanguageQuizData(5);
//            //    levelFailPanel.SetActive(false);
//            //    quizPanel.SetActive(true);
//            //}
//            else
//            {
//                CountDown.timeRemaining = 300f;
//                CountDown.timerIsRunning = true;
//                PlayerPrefs.SetFloat("TimeRemaining", CountDown.timeRemaining);
//                PlayerPrefs.Save();
//            }
//        }
//    }

//    public void AnswerBtnClick(Text text)
//    {

//        if (selectedCategory == 1)
//        {
//            if (text.text.Equals(historyFinalAnswer) == true)
//            {

//                Answerdecision.text = "CorrectAnswer";
//                Debug.Log("Correct History Answer Selected");
//                StartCoroutine(CorrectAnswerWait());
//            }
//            else
//            {
//                Answerdecision.text = "WrongAnswer";
//                StartCoroutine(WrongAnswerwait());
//                Debug.Log("Wrong History Answer Selected");
//            }
//        }
//        else if (selectedCategory == 2)
//        {
//            if (text.text.Equals(geographyFinalAnswer) == true)
//            {
//                Answerdecision.text = "CorrectAnswer";
//                Debug.Log("Correct geography Answer Selected");
//                StartCoroutine(CorrectAnswerWait());
//            }
//            else
//            {
//                Answerdecision.text = "WrongAnswer";
//                StartCoroutine(WrongAnswerwait());
//                Debug.Log("Wrong geography Answer Selected");
//            }
//        }
//        else if (selectedCategory == 3)
//        {
//            if (text.text.Equals(foodFinalAnswer) == true)
//            {
//                Answerdecision.text = "CorrectAnswer";
//                Debug.Log("Correct food Answer Selected");
//                StartCoroutine(CorrectAnswerWait());
//            }
//            else
//            {
//                Answerdecision.text = "WrongAnswer";
//                StartCoroutine(WrongAnswerwait());
//                Debug.Log("Wrong food Answer Selected");
//            }
//        }
//        //else if (selectedCategory == 4)
//        //{
//        //    if (text.text.Equals(cultureFinalAnswer) == true)
//        //    {
//        //        Answerdecision.text = "CorrectAnswer";
//        //        Debug.Log("Correct culture Answer Selected");
//        //        StartCoroutine(CorrectAnswerWait());
//        //    }
//        //    else
//        //    {
//        //        Answerdecision.text = "WrongAnswer";
//        //        StartCoroutine(WrongAnswerwait());
//        //        Debug.Log("Wrong culture Answer Selected");
//        //    }
//        //}
//        //else if (selectedCategory == 5)
//        //{
//        //    if (text.text.Equals(languageFinalAnswer) == true)
//        //    {
//        //        Answerdecision.text = "CorrectAnswer";
//        //        Debug.Log("Correct language Answer Selected");
//        //        StartCoroutine(CorrectAnswerWait());
//        //    }
//        //    else
//        //    {
//        //        Answerdecision.text = "WrongAnswer";
//        //        StartCoroutine(WrongAnswerwait());
//        //        Debug.Log("Wrong language Answer Selected");
//        //    }
//        //}
//    }
//    IEnumerator CorrectAnswerWait()
//    {
//        yield return new WaitForSeconds(1f);
//        Answerdecision.text = "";
//        if (selectedCategory == 1)
//        {
//            if (PlayerPrefs.GetInt("UKHist", 0) <= 4)
//            {
//                PlayerPrefs.SetInt("UKHist", (PlayerPrefs.GetInt("UKHist")) + 1);
//                PlayerPrefs.Save();

//                SetHistoryQuizData(1);

//                if (PlayerPrefs.GetInt("UKHist", 0) == 4)
//                {
//                    PlayerPrefs.SetInt("Level1", (PlayerPrefs.GetInt("Level1")) + 1);
//                    PlayerPrefs.Save();

//                    quizPanel.SetActive(false);
//                    levelCompletePanel.SetActive(true);
//                }
//            }
//        }
//        else if (selectedCategory == 2)
//        {
//            if (PlayerPrefs.GetInt("UKGeo", 0) <= 4)
//            {
//                PlayerPrefs.SetInt("UKGeo", (PlayerPrefs.GetInt("UKGeo")) + 1);
//                PlayerPrefs.Save();

//                SetGeographyQuizData(2);

//                if (PlayerPrefs.GetInt("UKGeo", 0) == 4)
//                {
//                    PlayerPrefs.SetInt("Level1", (PlayerPrefs.GetInt("Level1")) + 1);
//                    PlayerPrefs.Save();

//                    quizPanel.SetActive(false);
//                    levelCompletePanel.SetActive(true);
//                }
//            }
//        }
//        else if (selectedCategory == 3)
//        {
//            if (PlayerPrefs.GetInt("UKFood", 0) <= 2)
//            {
//                PlayerPrefs.SetInt("UKFood", (PlayerPrefs.GetInt("UKFood")) + 1);
//                PlayerPrefs.Save();

//                SetFoodQuizData(3);

//                if (PlayerPrefs.GetInt("UKFood", 0) == 2)
//                {
//                    PlayerPrefs.SetInt("Level1", (PlayerPrefs.GetInt("Level1")) + 1);
//                    PlayerPrefs.Save();

//                    quizPanel.SetActive(false);
//                    levelCompletePanel.SetActive(true);
//                }
//            }
//        }
//        //else if (selectedCategory == 4)
//        //{
//        //    if (PlayerPrefs.GetInt("UKCult", 0) <= 3)
//        //    {
//        //        PlayerPrefs.SetInt("UKCult", (PlayerPrefs.GetInt("UKCult")) + 1);
//        //        PlayerPrefs.Save();

//        //        SetCultureQuizData(4);

//        //        if (PlayerPrefs.GetInt("UKCult", 0) == 3)
//        //        {
//        //            PlayerPrefs.SetInt("Level1", (PlayerPrefs.GetInt("Level1")) + 1);
//        //            PlayerPrefs.Save();

//        //            quizPanel.SetActive(false);
//        //            levelCompletePanel.SetActive(true);
//        //        }
//        //    }
//        //}
//        //else if (selectedCategory == 5)
//        //{
//        //    if (PlayerPrefs.GetInt("UKLang", 0) <= 3)
//        //    {
//        //        PlayerPrefs.SetInt("UKLang", (PlayerPrefs.GetInt("UKLang")) + 1);
//        //        PlayerPrefs.Save();

//        //        SetLanguageQuizData(5);

//        //        if (PlayerPrefs.GetInt("UKLang", 0) == 3)
//        //        {
//        //            PlayerPrefs.SetInt("Level1", (PlayerPrefs.GetInt("Level1")) + 1);
//        //            PlayerPrefs.Save();

//        //            quizPanel.SetActive(false);
//        //            levelCompletePanel.SetActive(true);
//        //        }
//        //    }
//        //}


//    }

//    IEnumerator WrongAnswerwait()
//    {
//        yield return new WaitForSeconds(1f);
//        Answerdecision.text = "";
//        if (selectedCategory <= 5)
//        {
//            levelFailPanel.SetActive(true);
//            quizPanel.SetActive(false);
//        }
//    }


//    public void BackToMenu()
//    {
//        //fader.SetActive(true);
//        //FadeAnimation obj = fader.GetComponent<FadeAnimation>();
//        //obj.FadeInAnim();
//        //StartCoroutine(LoadScene(1));


//        ////        SceneManager.LoadSceneAsync(0);
//        //MainMenuManager.backFromGame = true;
//    }
//    #endregion
//#endregion
}
