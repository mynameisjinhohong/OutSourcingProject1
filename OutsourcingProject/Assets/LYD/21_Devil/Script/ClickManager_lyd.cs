using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager_lyd : MonoBehaviour
{
    Camera cam;
    public GameObject devilPre; //���� ������
    public GameObject devilFactory; //�������丮���� ���� �������� �����ǵ���
    public GameObject devilExplosion;

    float currentTime = 0;

    public int devilCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (devilCount < 15 && currentTime > 3)
        {
            GameObject go = Instantiate(devilPre);
            go.transform.position = devilFactory.transform.position;
            Debug.Log("eo");
            currentTime = 0;
        }
        else if (devilCount >= 15 && currentTime > 2)
        {
            GameObject go = Instantiate(devilPre);
            go.transform.position = devilFactory.transform.position;

            currentTime = 0;

        }
        else if (devilCount >= 35 && currentTime > 1)
        {
            GameObject go = Instantiate(devilPre);
            go.transform.position = devilFactory.transform.position;
            currentTime = 0;

        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            // ���ϼ��ֵ���
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.name == "Devil(Clone)")
                {

                    Debug.Log("Ŭ��");
                    //���� �ѱ�
                    //Ŭ������Ʈ ���ֱ�
                    //+100�� �̹��� ����
                    //���� 100��
                    //GameManager.instance.score += 100; //������
                    
                    Instantiate(devilExplosion, hitinfo.transform.position, Quaternion.identity);
                    GameObject.Destroy(hitinfo.transform.gameObject);
                    devilCount++;
                    Debug.Log("�׾���");

                }

                print(hitinfo.transform.name);
                print(devilCount);
            }
        }
    }
}
