using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager_lyd : MonoBehaviour
{
    Camera cam;
    public GameObject devilPre; //���� ������
    //public GameObject devilFactory; //�������丮���� ���� �������� �����ǵ���
    public GameObject devilExplosion;

    public AudioSource clickSound;

    float currentTime = 0;
    float randomX;
    float randomY;
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
            randomX = Random.Range(-7.97f, 7.97f); //������ ��Ÿ�� x��ǥ ���� ����
            randomY = Random.Range(-2.46f, 4.48f); //���� ��Ÿ�� y��ǥ ���� ����
            GameObject devil = (GameObject)Instantiate(devilPre, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            print(randomX);
            print(randomY);
            currentTime = 0;
        }
       else if (devilCount >= 15 && currentTime > 2)
        {
            randomX = Random.Range(-7.97f, 7.97f); //������ ��Ÿ�� x��ǥ ���� ����
            randomY = Random.Range(-2.46f, 4.48f); //���� ��Ÿ�� y��ǥ ���� ����
            GameObject devil = (GameObject)Instantiate(devilPre, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            print(randomX);
            print(randomY);
            currentTime = 0;

        }
        else if (devilCount >= 35 && currentTime > 1)
        {
            randomX = Random.Range(-7.97f, 7.97f); //������ ��Ÿ�� x��ǥ ���� ����
            randomY = Random.Range(-2.46f, 4.48f); //���� ��Ÿ�� y��ǥ ���� ����
            GameObject devil = (GameObject)Instantiate(devilPre, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            print(randomX);
            print(randomY);
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
                    clickSound.Play();
                    //+100�� �̹��� ����
                    //���� 100��
                    GameManager.instance.score += 100; 
                    
                    //Ŭ������Ʈ ���ֱ�
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
