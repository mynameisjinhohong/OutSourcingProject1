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
            // 죽일수있도록
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.name == "Devil(Clone)")
                {

                    Debug.Log("클릭");
                    //사운드 켜기
                    //.Play();
                    //+100점 이미지 띄우기
                    //점수 100점
                    GameManager.instance.score += 100;

                    //클릭이펙트 켜주기
                   // Instantiate(, hitinfo.transform.position, Quaternion.identity);
                    //Instantiate(, hitinfo.point, Quaternion.identity);

                    GameObject.Destroy(hitinfo.transform.gameObject);

                }
            }
}
