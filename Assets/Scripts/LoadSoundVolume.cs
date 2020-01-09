using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoundVolume : MonoBehaviour
{
    AudioSource audioSource;
   
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }
}
