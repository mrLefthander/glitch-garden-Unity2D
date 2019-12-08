using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    int attackersCount = 0;
    bool levelTimerEnded = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        CountExistingAttackers();
    }

    public void SetLevelTimerEnded(bool isEnded)
    {
        levelTimerEnded = isEnded;
    }
    
    public bool GetLevelTimerEnded()
    {
        return levelTimerEnded;
    }

    public void AttackerKilled()
    {
        attackersCount--;
        if (levelTimerEnded && attackersCount <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        AudioSource winAudio = GetComponent<AudioSource>();
        winAudio.Play();
        winLabel.SetActive(true);
        yield return new WaitForSeconds(winAudio.clip.length);
        FindObjectOfType<LevelLoader>().LoadNextScene();

    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0;
        loseLabel.SetActive(true);
    }

    public void AttackerSpawned()
    {
        attackersCount++;
    }

    private void CountExistingAttackers()
    {
        var alreadyExisringAttackers = FindObjectsOfType<Attacker>();
        if (alreadyExisringAttackers.Length > 0)
        {
            attackersCount = alreadyExisringAttackers.Length;
        }
        else
        {
            attackersCount = 0;
        }
    }
}
