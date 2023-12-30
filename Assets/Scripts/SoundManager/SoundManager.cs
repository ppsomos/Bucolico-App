using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource musicsource, effectsource;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void playsound(AudioClip clip)
    {
        effectsource.PlayOneShot(clip);
        
    }
    //public void ChangeMastervolume(float value)
    //{
    //    AudioListener.volume = value;
    //}
    public void toggleeffect()
    {
        effectsource.mute = !effectsource.mute;
    }
    public void togglemusic()
    {
        
        musicsource.mute = !musicsource.mute;
    }
}
