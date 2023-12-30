using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private Slider _slider;

    void Start()
    {
     //   SoundManager.instance.playsound(clip);
       

    }
    //public void OnEnable()
    //{
    //    _slider.onValueChanged.AddListener(val => SoundManager.instance.ChangeMastervolume(val));

    //}


}
