using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float timeDuration = 3f * 60f;
    
    [SerializeField] private float timer; 
    [SerializeField]
    private TextMeshProUGUI firstMinute; 
    [SerializeField]
    private TextMeshProUGUI secondMinute; 
    [SerializeField] 
    private TextMeshProUGUI separator; 
    [SerializeField]
    private TextMeshProUGUI firstSecond; 
    [SerializeField]
    private TextMeshProUGUI secondSecond;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0) {
            timer -= Time.deltaTime;
            UpdateTimer(timer);
        }
        else {
            SetTextDisplay(false);
        }
        print(timer);
    }
    void resetTimer() {
        timer = timeDuration;
    }
    private void UpdateTimer(float time) {
        float minutes = Mathf.FloorToInt(time / 60); // convert the seconds into minutes 
        float seconds = Mathf.FloorToInt(time % 60); // get the remaining seconds that were not converted into minutes 
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds); 
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString(); 
        firstSecond.text = currentTime[2].ToString(); 
        secondSecond.text = currentTime[3].ToString(); 
    }
    private void SetTextDisplay(bool enabled) {
        if (enabled) {
            firstMinute.enabled = true; 
            secondMinute.enabled = true; 
            separator.enabled = true; 
            firstSecond.enabled = true; 
            secondSecond.enabled = true; 
        }
        else {
            firstMinute.enabled = false; 
            secondMinute.enabled = false;
            separator.enabled = false; 
            firstSecond.enabled = false;
            secondSecond.enabled = false;
        }
    }
}
