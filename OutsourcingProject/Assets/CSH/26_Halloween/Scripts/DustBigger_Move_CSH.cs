using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBigger_Move_CSH : MonoBehaviour
{
    public enum State { 
        Bigger, //커지는중
        Move, //움직임
    }

    Camera cam;
    State nowState;
    public Vector3 dir;
    public int speed;
    float changeDirTime=0;
    float temp = 0;
    //public Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //사이즈 거의 안보일정도로 시작
        transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        float randirX = Random.Range(-1, 1);
        float randirY = Random.Range(-1, 1);
        dir = new Vector3(randirX, randirY, 0.0f);
        nowState = State.Bigger;
    }

    // Update is called once per frame
    void Update()
    {
        checkPos();
        changeDir();
        if(nowState == State.Bigger)
        {
            GetBigger();
        }
        else if(nowState == State.Move)
        {
            Moving();
        }
        
    }
    void checkPos()
    {
        //화면 밖으로 안나가게 제한
        Vector3 worldPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldPos.x < 0.2f) worldPos.x = 0.2f;
        if (worldPos.y < 0.2f) worldPos.y= 0.2f;
        if (worldPos.x > 0.8f) worldPos.x = 0.8f;
        if (worldPos.y > 0.8f) worldPos.y = 0.8f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }


    void changeDir()
    {
        //2초에 한번씩 움직이는 방향 바꾸기
        changeDirTime += Time.deltaTime;
        if (changeDirTime >= 2)
        {
            changeDirTime = 0;
            float randirX = Random.Range(-5, 5);
            float randirY = Random.Range(-5, 5);
            dir = new Vector3(randirX, randirY, 0.0f);
        }
    }

    void GetBigger()
    {
        
        temp += Time.deltaTime*1.5f;
        //사이즈 4까지 천천히 키우기
        transform.localScale = new Vector3(temp,temp,1f);

        if(transform.localScale.x >= 4.0f)
        {
            nowState = State.Move;
        }
    }

    void Moving()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
