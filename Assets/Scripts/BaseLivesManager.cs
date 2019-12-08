using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLivesManager : MonoBehaviour
{
    [SerializeField] int lives = 1;

    Text livesText;
    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void SpendLives(int amount)
    {
        if (amount <= lives)
        {
            lives -= amount;
            UpdateDisplay();
        }
        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
