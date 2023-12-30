using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData",menuName ="Q_Data")]
public class QuestionData : ScriptableObject
{
    public Language[] languages;
}
[System.Serializable]
public class Language
{
    public  string name;
    public string[] Question;
    public string[] Op1;
    public string[] Op2;
    public string[] Op3;
    public int[] Answer;
    public int[] Categrey;
}