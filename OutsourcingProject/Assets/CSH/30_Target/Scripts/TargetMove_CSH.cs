using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove_CSH : MonoBehaviour
{
    //public enum State
    //{
    //    Smaller, //�۾�������
    //    Move, //������
    //}

    Camera cam;
    //State nowState;
    public Vector3 dir;
    public int speed;
    float changeDirTime = 0;
    public float temp = 5;
    //public Vector3 worldPos;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        //������ 4.5~1���� �پ���
        transform.localScale = new Vector3(5f, 5f, 1f);
        float randirX = Random.Range(-1, 1);
        float randirY = Random.Range(-1, 1);
        dir = new Vector3(randirX, randirY, 0.0f);
        //nowState = State.Smaller;
        //Moving();
    }

    // Update is called once per frame
    void Update()
    {
        checkPos();
        changeDir();
        Moving();
        //if (nowState == State.Smaller)
        //{
        //    GetBigger();
        //}
        //else if (nowState == State.Move)
        //{
        //    Moving();
        //}
        GetSmaller();

    }
    void checkPos()
    {
        //ȭ�� ������ �ȳ����� ����
        Vector3 worldPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldPos.x < 0.1f) worldPos.x = 0.1f;
        if (worldPos.y < 0.1f) worldPos.y = 0.1f;
        if (worldPos.x > 0.9f) worldPos.x = 0.9f;
        if (worldPos.y > 0.9f) worldPos.y = 0.9f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }


    void changeDir()
    {
        //1.0�ʿ� �ѹ��� �����̴� ���� �ٲٱ�
        changeDirTime += Time.deltaTime;
        if (changeDirTime >= 1.0)
        {
            changeDirTime = 0;
            float randirX = Random.Range(-5, 5);
            float randirY = Random.Range(-5, 5);
            dir = new Vector3(randirX, randirY, 0.0f);
            //Moving();
        }
    }

    void GetSmaller()
    {
        if (transform.localScale.x <= 1.0f)
        {
            //nowState = State.Move;
        }
        else
        {
            temp -= Time.deltaTime;
            //������ 1���� õõ�� �پ���
            transform.localScale = new Vector3(temp, temp, 1f);
        }
    }

    void Moving()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        float randirX = Random.Range(-1, 1);
        float randirY = Random.Range(-1, 1);
        dir = new Vector3(randirX, randirY, 0.0f);
    }
}
