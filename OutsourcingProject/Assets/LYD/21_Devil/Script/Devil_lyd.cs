using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 3�ʿ� �ϳ��� enemyfactory���� �����ȴ�. (�ѹ����� �ƴ� �������� enemyFactory)
//3. ��� �׸��鼭 ī�޶�� ����ͼ� ���ߵ��� �ϰ��ϸ��!! *
//4. ���̸� ���� ���� Ŭ������ �� �״´�.
//5. �� ���̸� ȭ��󿡼� ��� ����ٴ�

public class Devil_lyd : MonoBehaviour
{
    //���� �������� �־��ֱ�
    Camera cam;

    public float speed = 5f;

    //fly ���¶� ȭ�鿡�� �����̴� ���� ������ֱ�
    public enum State
    {
        
        Big,
        Move
    }
    public State state;

    //������Ŀ������
    public float scaleSpeed = 2f;
    private float maxSizeX = 1f;
    private float maxSizeY = 1f;

    Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        state = State.Big;
        //ȭ��ȿ��� �����ϼ��ִ� ����
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
            // �̵��� ���� ���
            /*if (Random.value == 1)
            {
                dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
                print("���������� ������");
            }*/
            transform.position += speed * Time.deltaTime * dir; 
            ViewPos();

        }





    }
    private void ViewPos()
    {
        //ȭ������� �������� �ϱ�
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
