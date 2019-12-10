using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.4f;

    MusicPlayer musicPlayer;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    public void UpdateVolume()
    {
        AudioListener.volume = volumeSlider.value;
    /*    if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No Music Player object");
        }*/
    }

    public void SaveOptions()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
