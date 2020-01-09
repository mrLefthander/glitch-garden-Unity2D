using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLivesManager : MonoBehaviour
{
    [SerializeField] float baseLives = 1f;
    float lives = 1f;

    Text livesText;
    void Start()
    {
        ApplyDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void ApplyDifficulty()
    {
        lives = baseLives - Mathf.Round(baseLives * PlayerPrefsController.GetDifficulty());
        lives = lives < 1 ? 1 : lives;
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void SpendLives(float amount)
    {
        if (amount <= lives)
        {
            lives -= amount;
            UpdateDisplay();
        }
        if(lives <= 0f)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
