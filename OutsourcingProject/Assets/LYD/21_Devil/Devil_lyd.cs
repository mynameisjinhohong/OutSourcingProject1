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
    //public GameObject devilPre;
    private float createTime = 3;
    float currentTime = 0;
    Camera cam;

    public float speed = 10f;
    public float curveStrength = 1f;
    public float curveFrequency = 1f;

    //fly ���¶� ȭ�鿡�� �����̴� ���� ������ֱ�
    public enum State
    {
        Idle,
        Fly,
        Move
    }
    State state = State.Idle; 
    Vector3 pos;
    //���� devilCount�� 15������ �Ǹ� 2�ʿ� �ѹ��� �����ϵ���

    private int devilCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    /*
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        Vector3 pos = transform.position;
        pos.x += speed * Time.fixedDeltaTime;
        pos.y += Mathf.Sin(timer * curveFrequency);

        transform.position = pos;
    }
    */
    // Update is called once per frame
    void Update()
    {
        //1.������ ���콺�� ������ �� ���� �̸��� Devil�̸� �״´�.
        //2.���� timer�� ������ 3�ʿ� �ѹ��� �����ȴ�.

        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {

        }
        
        

        if(Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //���⼭ ������ ������� �ҵ�. 
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.transform.name == "Devil" && state == State.Move)
                {
                    Debug.Log("Ŭ��");
                    //���� �ѱ�
                    //Ŭ������Ʈ ���ֱ�
                    //+100�� �̹��� ����
                    //���� 100��
                    GameManager.instance.score += 100;
                    devilCount++;
                    Destroy(gameObject);
                }
            }
        }
        pos = Vector3.back;
        transform.position += speed * Time.deltaTime * pos;

        //ī�޶��� transform.position

    }
}
