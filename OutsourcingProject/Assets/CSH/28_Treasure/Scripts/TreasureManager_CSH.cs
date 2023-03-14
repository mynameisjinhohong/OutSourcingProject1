using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureManager_CSH : MonoBehaviour
{
    public Slider timer;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI remainText;
    public int currentTime = 100;
    public int remains = 100;
    // Start is called before the first frame update
    void Start()
    {

    }
    float nowTime = 0;
    // Update is called once per frame
    void Update()
    {
        remainText.text = "���� ����: " + remains;
        if (remains <=0)
        {
            remains = 0;
            //���ӿ���
            GameManager.instance.GameOver = true;
        }


        TimerGo();
    }

    void TimerGo()
    {
        timeText.text = "���� �ð� : " + currentTime;
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
