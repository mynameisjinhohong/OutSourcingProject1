using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager_lyd : MonoBehaviour
{
    Camera cam;
    public GameObject devilPre; //데빌 프리팹
    public GameObject devilFactory; //데빌팩토리에서 데빌 프리팹이 생성되도록
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
            // 죽일수있도록
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.name == "Devil(Clone)")
                {

                    Debug.Log("클릭");
                    //사운드 켜기
                    //클릭이펙트 켜주기
                    //+100점 이미지 띄우기
                    //점수 100점
                    //GameManager.instance.score += 100; //에러뜸
                    
                    Instantiate(devilExplosion, hitinfo.transform.position, Quaternion.identity);
                    GameObject.Destroy(hitinfo.transform.gameObject);
                    devilCount++;
                    Debug.Log("죽었다");

                }

                print(hitinfo.transform.name);
                print(devilCount);
            }
        }
    }
}
