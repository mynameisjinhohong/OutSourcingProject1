using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent_CSH : MonoBehaviour
{
    Camera cam;
    public AudioSource clickSound;
    public GameObject clickEffect;

    public AudioSource AlienExplosionSound;
    public GameObject AlienClickEffect;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ȭ�鿡 Ŭ���� �������� ray�߻�
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Scence ���� ī�޶󿡼� ������ ������ ������ Ȯ���ϱ�
            //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit raycastHit)) 
            {
                //ù��° ����
                if (raycastHit.transform.name == "Dust(Clone)") //������ Ŭ���ϸ�
                {
                    //Score ���
                    GameManager.instance.score += 100;
                    //���� ���� ���̱�
                    GameObject.Find("HalloweenCanvas").GetComponent<HalloweenManager_CSH>().remains--;
                    //���� �ı�
                    clickSound.Play();
                    Instantiate(clickEffect, raycastHit.transform.position, Quaternion.identity);
                    GameObject.Destroy(raycastHit.transform.gameObject);
                }
                //�ι�° ����
                else if(raycastHit.transform.name == "Alien1(Clone)"|| raycastHit.transform.name == "Alien2(Clone)"|| raycastHit.transform.name == "Alien3(Clone)" || raycastHit.transform.name == "Missile(Clone)")
                {
                    //Score ���
                    GameManager.instance.score += 100;
                    
                    //�ܰ��� �ı�, �Ҹ��� ����Ʈ ���
                    AlienExplosionSound.Play();
                    Instantiate(AlienClickEffect, raycastHit.transform.position, Quaternion.identity);
                    GameObject.Destroy(raycastHit.transform.gameObject);
                }
            }
            
        }
    }
}
