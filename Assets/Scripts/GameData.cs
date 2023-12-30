using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="GData",menuName ="GameData")]
public class GameData : ScriptableObject
{
    public bool IsFirstTime;
    public bool IsMultiplayer;
    public int Multi_Level_Unlock;
    public int SelectedAvatar;
    public int SelectLanguage;
    public string PlayerName;
    public Question[] GameQUestion;
    public Player[] Multi_Player;
}
[System.Serializable]
public class Question
{
    public string QuestionNo;
    public bool IsComplete;
}
[System.Serializable]
public class Player
{
    public string PlayerName;
    public int SelectedAvatar;
    public int RightAnswer;
    public int WrongAnswer;
    public float TimeTaken;
}
