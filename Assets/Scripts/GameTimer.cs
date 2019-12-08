﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time is seconds")]
    [SerializeField] float levelTime = 10f;

    Slider slider;
    bool triggeredLevelFinished = false;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        if(triggeredLevelFinished) { return; }
        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().SetLevelTimerEnded(timerFinished);
            triggeredLevelFinished = true;
        }
    }
}
