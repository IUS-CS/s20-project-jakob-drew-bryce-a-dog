using Samtec.OpticsVRTrainer.Utility;
using TMPro;
using UnityEngine;
using Utility;

public class TimerController : Singleton<TimerController>
    {
        [SerializeField]
        GameObject TimerUIPanel;
        [SerializeField]
        TextMeshProUGUI TimerLabel;
        [SerializeField]
        float WarningTime = 20f;
        [SerializeField]
        float ErrorTime = 30f;

        Vector3 TimerUIPanelStartScale;

        private float time = 0f;

        bool TimerStarted, CountdownStarted;
        bool FractionsOn;
        bool timeoutInvoked;

        new private void Awake()
        {
            TimerStarted = false;
            CountdownStarted = false;
            FractionsOn = false;
            TimerUIPanelStartScale = TimerUIPanel.transform.localScale;
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
            float fraction = (int)((time * 10) % 10);

            if (!FractionsOn)
            {
                TimerLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                TimerLabel.text = string.Format("{0:00}:{1:00}.{2:0}", minutes, seconds, fraction);
            }

            // green up to 20s, yellow up to 30s, red after
            if (time >= ErrorTime)
            {
                TimerLabel.color = Color.red;

                if (!timeoutInvoked)
                {
                    timeoutInvoked = true;
                }
            }
            else if (seconds < WarningTime)
            {
                TimerLabel.color = Color.green;
            }
            else if (seconds >= WarningTime && time < ErrorTime)
            {
                TimerLabel.color = Color.yellow;
            }
        }

        public void StartTimer()
        {
            TimerStarted = true;
            CountdownStarted = false;
            FractionsOn = false;
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
            StartCoroutine(BasicAnimator.AnimateScale(TimerUIPanel.transform, TimerUIPanel.transform.localScale, TimerUIPanelStartScale, .5f));
        }

        public void HideTimer()
        {
            StartCoroutine(BasicAnimator.AnimateScale(TimerUIPanel.transform, TimerUIPanel.transform.localScale, Vector3.zero, .5f));
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
