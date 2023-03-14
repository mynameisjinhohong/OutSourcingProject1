using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMove_CSH : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;
    public float speed = 5;
    Vector3 toPos;
    // Start is called before the first frame update
    void Start()
    {
        rangeObject = GameObject.Find("ArriveZone");
        //������ ���� ������Ʈ
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
        toPos = Return_RandomPosition();
        //y ��ǥ�� �������� ������, Ŭ���� �հ��̹Ƿ� ������ ������ ���� ���ٰ� ǥ��
        if(toPos.y < 0)
        {
            transform.localScale = new Vector3(-toPos.y, -toPos.y, 1);
        }
        else if (2 < toPos.y)
        {
            transform.localScale = new Vector3(4.5f/toPos.y, 4.5f/toPos.y, 1);
        }
        else
        {
            //0�ϰ��
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TreasureMove();
    }

    //������ ���� ����
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        //range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        //Vector3 RandomPostion = new Vector3(range_X, range_Y, -0.5f);

        Vector3 RandomPostion = new Vector3(transform.position.x, range_Y, -0.5f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    void TreasureMove()
    {
        if (Vector3.Distance(transform.position, toPos) <= 0.3)
        {
            //����
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, toPos, speed * Time.deltaTime);
        }
    }
}
