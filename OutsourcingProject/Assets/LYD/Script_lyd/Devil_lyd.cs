using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 3�ʿ� �ϳ��� enemyfactory���� �����ȴ�. (�ѹ����� �ƴ� �������� enemyFactory)
//2. ����� �� �۾����鼭 Ŀ������ �����. (ũ�� Ű���)
//3. ��� �׸��鼭 
//4. ���̸� ���� ���� Ŭ������ �� �״´�.
//5. �� ���̸� ȭ��󿡼� ��� ����ٴ�

public class Devil_lyd : MonoBehaviour
{
    //���� �������� �־��ֱ�
    public GameObject devilPre;
    public float createTime = 3;
    float currentTime = 0;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //1.������ ���콺�� ������ �� ���� �̸��� Devil�̸� �״´�.
        //2.������ 3�ʿ� �ѹ��� �����ȴ�.
        if(currentTime > createTime)
        {

        }
        //3. ũ�Ⱑ ���� Ŀ����.
        

        if(Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.transform.name == "Devil")
                {
                    //���� �ѱ�
                    //Ŭ������Ʈ ���ֱ�
                    //+100�� �̹��� ����
                    //���� 100��
                    GameManager.instance.score += 100;
                    Destroy(gameObject);
                }
            }
        }


    }
}
