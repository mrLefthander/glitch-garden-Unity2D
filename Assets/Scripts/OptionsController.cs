using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    [SerializeField] float defaultVolume = 0.4f;
    [SerializeField] float defaultDifficulty = 0f;

    void Start()
    {
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    public void UpdateVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void UpdateDifficulty()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    public void SaveOptions()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
