﻿using System;
using System.Timers;
using UnityEngine;

public class LevelTimer : Level
{
    public int timeInSeconds;
    public int targetScore;

    private float timer;
    private bool timeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.TIMER;
        HUD.instance.SetLevelType(type);
        HUD.instance.SetScore(currentScore);
        HUD.instance.SetTarget(targetScore);
        HUD.instance.SetRemaining(TimerString());

    }

    // Update is called once per frame
    void Update()
    {
        if (!timeOut)
        {
            timer += Time.deltaTime;
            HUD.instance.SetRemaining(TimerString());

            if (timeInSeconds - timer <= 0)
            {
                if (currentScore >= targetScore)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }

                timeOut = true;
            }
        }
    }
    public string TimerString()
    {
        return string.Format("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer) / 60), (int)Mathf.Max((timeInSeconds - timer) % 60));
    }

}
