using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_sound : MonoBehaviour
{
    [SerializeField] private bool togglemusic, toggleeffect;
    
    public void toggle()
    {
        if (toggleeffect) SoundManager.instance.toggleeffect();
        if (togglemusic) SoundManager.instance.togglemusic();
    }
 
   
}
