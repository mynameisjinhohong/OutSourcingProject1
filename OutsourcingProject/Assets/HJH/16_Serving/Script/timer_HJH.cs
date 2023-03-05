using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer_HJH : MonoBehaviour
{
    public Slider timer;
    public TextMeshProUGUI timeText;
    public int currentTime = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float nowTime = 0;
    // Update is called once per frame
    void Update()
    {
        timeText.text = "남은 시간 : " + currentTime;
        timer.value = (float)currentTime / 100f;
        nowTime += Time.deltaTime;
        if(nowTime > 1)
        {
            nowTime = 0;
            currentTime -= 1;
        }
        if(currentTime <= 0)
        {
            GameManager.instance.GameOver = true;
        }
    }
}
