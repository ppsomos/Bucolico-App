using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LoadingData : MonoBehaviour
{
    public string[] Paths;
    public QuestionData MCQS_DATA;
    private void Awake()
    {
        for (int i = 0; i < Paths.Length; i++)
        {
            LoadData(Paths[i], i);
           // Debug.Log("Path==" + Paths[i]);
            //Debug.Log("Index==" + i);
        }
    }

    private void Start()
    {
        

    }
    private void LoadData(string paths, int index)
    {

        string[] lines;
        string filePath = Path.Combine(Application.streamingAssetsPath, paths + ".csv");


        // Android requires special handling for accessing files in the StreamingAssets folder
        if (filePath.Contains("://"))
        {
            // Use WWW to load the file from the StreamingAssets folder on Android
            WWW www = new WWW(filePath);
            while (!www.isDone) { }

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError("Failed to load file: " + www.error);
                return;
            }

            // Read the CSV data from the WWW object
            lines = www.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Log(filePath);

        }
        else
        {
            // On other platforms, directly load the file using the StreamingAssets path
            string streamingPath = Path.Combine(Application.streamingAssetsPath, paths + ".csv");

            if (Application.platform == RuntimePlatform.Android)
            {
                // Android specific handling to load files from StreamingAssets
                UnityWebRequest www = UnityWebRequest.Get(streamingPath);
                www.SendWebRequest();

                while (!www.isDone) { }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to load file: " + www.error);
                    return;
                }

                // Read the CSV data from the UnityWebRequest
                lines = www.downloadHandler.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Debug.Log(filePath);

            }
            else
            {
                // For other platforms, load the file using regular file I/O
                if (File.Exists(streamingPath))
                {
                    string csvData = File.ReadAllText(streamingPath);
                    lines = csvData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    Debug.Log(filePath);
                }
                else
                {
                    Debug.LogError("File does not exist: " + streamingPath);
                    return;
                }
            }

            //Starting the Data Parse process!

            //Initialize arrays to store the data
            int rowCount = lines.Length - 1; // Subtracting 1 to exclude the header row
           // Debug.Log("rowCount==" + rowCount + paths);
            InitializeMCQSData(MCQS_DATA, rowCount, lines, index);
            //Debug.Log(data[i].name + "Row Count is : " + rowCount);

        }
        //LoadingImages(data);
    }
    private void InitializeMCQSData(QuestionData mcqsData, int rowCount, string[] lines, int index)
    {   
            InitializeArrayToStoreData(mcqsData.languages[index], rowCount, lines);      
    }
    private void InitializeArrayToStoreData(Language data, int rowCount, string[] Lines)
    {
        //Debug.Log("row" + rowCount);
        data.Question= new string[rowCount];
        data.Op1 = new string[rowCount];
        data.Op2 = new string[rowCount];
        data.Op3 = new string[rowCount];
        data.Answer = new int[rowCount];
        data.Categrey = new int[rowCount];

        for (int i = 1; i < Lines.Length; i++)
        {
           // Debug.Log("i==" + i);
            string[] values = Lines[i].Split(',');
          //  Debug.Log("values==" + values[1]);
            data.Question[i - 1] = values[0];
            data.Op1[i - 1] = values[1];
            data.Op2[i - 1] = values[2];
            data.Op3[i - 1] = values[3];
            data.Answer[i - 1] = int.Parse(values[4]);
            data.Categrey[i - 1] = int.Parse(values[5]);
        }
    }
}
