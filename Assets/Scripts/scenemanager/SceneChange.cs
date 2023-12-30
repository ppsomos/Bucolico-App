using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void changescene()
    {
        SceneManager.LoadSceneAsync("Musem scene");
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync("Mainscene");
    }
}
