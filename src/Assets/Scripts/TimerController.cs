using Samtec.OpticsVRTrainer.Utility;
using TMPro;
using UnityEngine;
using Utility;

public class TimerController : Singleton<TimerController>
{
    public TextMeshProUGUI[] TimerLabels;
    //public float veryEasyTime;
    public float easyTime;
    public float normalTime;
    public float hardTime;
    public float veryHardTime;
    public Color orange;

    private float time = 0f;

    bool TimerStarted, CountdownStarted;
    public bool FractionsOn;
    bool timeoutInvoked;

    new private void Awake()
    {
        TimerStarted = false;
        CountdownStarted = false;
        //FractionsOn = false;
    }

    void Update()
    {
        if (TimerStarted || CountdownStarted)
        {
            if (TimerStarted)
            {
                time += Time.deltaTime;
            }
            else if (CountdownStarted)
            {
                if (time >= 0f)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    time = 0f;
                    CountdownStarted = false;
                }
            }

            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        float fraction = (int)((time * 100) % 100);

        for (int i = 0; i < TimerLabels.Length; i++)
        {
            if (!FractionsOn)
            {
                TimerLabels[i].text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                TimerLabels[i].text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, fraction);
            }

            if (time < easyTime)
            {
                TimerLabels[i].color = Color.cyan;
            }
            else if (time >= easyTime && time < normalTime)
            {
                TimerLabels[i].color = Color.green;
            }
            else if (time >= normalTime && time < hardTime)
            {
                TimerLabels[i].color = Color.yellow;
            }
            else if (time >= hardTime && time < veryHardTime)
            {
                TimerLabels[i].color = orange;
            }
            else if (time >= veryHardTime)
            {
                TimerLabels[i].color = Color.red;
            }

        }
    }

    public void StartTimer()
    {
        TimerStarted = true;
        CountdownStarted = false;
        //FractionsOn = false;
    }

    public void StopTimer()
    {
        TimerStarted = false;
    }

    public void ResetTimer(bool restart = false)
    {
        TimerStarted = false;
        CountdownStarted = false;
        FractionsOn = false;
        timeoutInvoked = false;
        time = 0f;

        if (restart)
        {
            StartTimer();
        }
        else
        {
            UpdateDisplay();
        }
    }

    public void Countdown(float seconds, bool fractionsOn)
    {
        time = seconds;
        FractionsOn = fractionsOn;
        TimerStarted = false;
        CountdownStarted = true;
    }

    // showing timer only in freeplay and 1x modes
    public void ShowTimer()
    {
        //StartCoroutine(BasicAnimator.AnimateScale(TimerUIPanel.transform, TimerUIPanel.transform.localScale, TimerUIPanelStartScale, .5f));
    }

    public void HideTimer()
    {
        //StartCoroutine(BasicAnimator.AnimateScale(TimerUIPanel.transform, TimerUIPanel.transform.localScale, Vector3.zero, .5f));
    }

    public bool TimerRunning()
    {
        return TimerStarted;
    }

    public bool CountdownRunning()
    {
        return CountdownStarted;
    }

    public float GetElapsedTime()
    {
        return time;
    }
}
