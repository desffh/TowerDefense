using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TimeController : MonoBehaviour
{
    // 제한 시간 (분:초) 배열
    public Text[] timeText;

    public Text gameOverText;

    float time = 600; // 제한시간 10분 
    int min, sec;

    private void Start()
    {
        timeText[0].text = "10";
        timeText[1].text = "00";
    }

    private void Update()
    {
        time -= Time.deltaTime;

        min = (int)time / 60;

        sec = ((int)time - min * 60) % 60;


        if (min <= 0 && sec <= 0)
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
        }
        else
        {
            if(sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }
    }
}
