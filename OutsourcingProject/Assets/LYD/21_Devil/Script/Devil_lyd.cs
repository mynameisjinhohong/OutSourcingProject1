using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 3초에 하나씩 enemyfactory에서 생성된다. (한번에가 아닌 랜덤으로 enemyFactory)
//3. 곡선을 그리면서 카메라로 날라와서 멈추도록 하게하면됨!! *
//4. 레이를 쏴서 나를 클릭했을 때 죽는다.
//5. 안 죽이면 화면상에서 계속 날라다님

public class Devil_lyd : MonoBehaviour
{
    //데빌 프리팹을 넣어주기
    Camera cam;

    public float speed = 5f;

    //fly 상태랑 화면에서 움직이는 상태 만들어주기
    public enum State
    {
        
        Big,
        Move
    }
    public State state;

    //스케일커지도록
    public float scaleSpeed = 2f;
    private float maxSizeX = 1f;
    private float maxSizeY = 1f;

    Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        state = State.Big;
        //화면안에서 움직일수있는 범위
        float randomX = Random.Range(8f, -8f);
        float randomY = Random.Range(4f, -2f);
        dir = new Vector3(randomX, randomY, 0).normalized;
    }

    
    // Update is called once per frame
    void Update()
    {
       

        if (state == State.Big && transform.localScale.x < maxSizeX  && transform.localScale.y < maxSizeY)
        {
            transform.localScale = new Vector3(transform.localScale.x + 1f * scaleSpeed * Time.deltaTime, transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);

        }
        //DevilMove();
        if(transform.localScale.x >= maxSizeX && transform.localScale.y >= maxSizeY)
        {
            state = State.Move;
            // 이동할 방향 계산
            /*if (Random.value == 1)
            {
                dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
                print("렌덤레인지 실행중");
            }*/
            transform.position += speed * Time.deltaTime * dir; 
            ViewPos();

        }





    }
    private void ViewPos()
    {
        //화면밖으로 못나가게 하기
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.067f)
        {
            pos.x = 0.067f;
            dir.x *= -1;
        }
        if (pos.x > 0.93f)
        { 
            pos.x = 0.93f;
            dir.x *= -1;
        }

        if (pos.y < 0.1f)
        {
            pos.y = 0.1f;
            dir.y *= -1;
        }

        if (pos.y > 0.92f)
        {
            pos.y = 0.92f;
            dir.y *= -1;
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    /*void DevilMove()
    {
        if(transform.localScale.x >= maxSizeX && transform.localScale.y >= maxSizeY)
        {
            state = State.Move;
            ;
            

            *//*float x = Mathf.Clamp(transform.position.x, -5f, 5f);
            float y = Mathf.Clamp(transform.position.y, -5f, 5f);
            transform.position = new Vector3(x, y, 0);*//*

        }
    }*/
}
