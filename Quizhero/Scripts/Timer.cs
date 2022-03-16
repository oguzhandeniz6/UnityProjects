using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer = 15f;
    [SerializeField] float timeToShow = 5f;

    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnswering;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnswering)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToAnswer;
            }

            else
            {
                isAnswering = false;
                timerValue = timeToShow;
            }
        }

        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShow;
            }

            else
            {
                isAnswering = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }
    }
}
