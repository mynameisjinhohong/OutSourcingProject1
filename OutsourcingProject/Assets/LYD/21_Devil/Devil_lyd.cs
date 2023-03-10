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

    public float speed = 10f;

    //fly ���¶� ȭ�鿡�� �����̴� ���� ������ֱ�
    public enum State
    {
        
        Big,
        Move
    }
    public State state;
    Vector3 pos;

    private int Count = 0;
    public int devilCount;
    //������Ŀ������
    public float scaleSpeed = 2f;
    private float maxSizeX = 40f;
    private float maxSizeY = 40f;

    private float moveSpeed = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        state = State.Big;
        if(state == State.Move)
        {
            Vector3 viewPos = transform.position;
            viewPos.x += Random.Range(-1f, 1f) * speed * Time.deltaTime;
            viewPos.y += Random.Range(-1f, 1f) * speed * Time.deltaTime;
            transform.position = viewPos;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //1.������ ���콺�� ������ �� ���� �̸��� Devil�̸� �״´�. o
       

        if (state == State.Big && transform.localScale.x < maxSizeX  && transform.localScale.y < maxSizeY)
        {
            transform.localScale = new Vector3(transform.localScale.x + 1f * scaleSpeed * Time.deltaTime, transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);

        }
        //DevilMove();
        if(transform.localScale.x >= maxSizeX && transform.localScale.y >= maxSizeY)
        {
            state = State.Move;
            // �̵��� ���� ���
            float moveX = Input.GetAxisRaw("Horizontal"); // �¿� �̵� �Է�
            float moveY = Input.GetAxisRaw("Vertical"); // ���� �̵� �Է�
            Vector3 moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            //Vector3 moveDirection = new Vector3(moveX, moveY, 0f).normalized;

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        ViewPos();
       /* currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {

        }*/
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            //�� -3.5���� ���ϼ��ֵ���
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.name == "Devil")
                {

                    Debug.Log("Ŭ��");
                    //���� �ѱ�
                    //Ŭ������Ʈ ���ֱ�
                    //+100�� �̹��� ����
                    //���� 100��
                    GameManager.instance.score += 100; //������
                    devilCount++;
                    Count = devilCount;
                    Destroy(gameObject);
                }

                print(hitinfo.transform.name);
            }
        }

        

    }
    private void ViewPos()
    {
        //ȭ������� �������� �ϱ�
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

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
