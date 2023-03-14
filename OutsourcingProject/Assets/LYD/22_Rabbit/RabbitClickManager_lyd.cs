using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitClickManager_lyd : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            // ���ϼ��ֵ���
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.name == "Devil(Clone)")
                {

                    Debug.Log("Ŭ��");
                    //���� �ѱ�
                    //.Play();
                    //+100�� �̹��� ����
                    //���� 100��
                    GameManager.instance.score += 100;

                    //Ŭ������Ʈ ���ֱ�
                   // Instantiate(, hitinfo.transform.position, Quaternion.identity);
                    //Instantiate(, hitinfo.point, Quaternion.identity);

                    GameObject.Destroy(hitinfo.transform.gameObject);

                }
            }
}
