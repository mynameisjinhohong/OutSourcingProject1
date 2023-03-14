using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetManager_CSH : MonoBehaviour
{
    public Slider timer;
    public TextMeshProUGUI timeText;
    public int currentTime = 100;
    float nowTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerGo();
    }
    void TimerGo()
    {
        timeText.text = "남은 시간 : " + currentTime;
        timer.value = (float)currentTime / 100f;
        nowTime += Time.deltaTime;
        if (nowTime > 1)
        {
            nowTime = 0;
            currentTime -= 1;
        }
        if (currentTime <= 0)
        {
            GameManager.instance.GameOver = true;
        }
    }
}
