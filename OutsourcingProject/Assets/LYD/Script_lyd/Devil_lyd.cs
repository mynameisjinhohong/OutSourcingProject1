using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 3초에 하나씩 enemyfactory에서 생성된다. (한번에가 아닌 랜덤으로 enemyFactory)
//2. 날라올 때 작아지면서 커지도록 날라옴. (크기 키우기)
//3. 곡선을 그리면서 
//4. 레이를 쏴서 나를 클릭했을 때 죽는다.
//5. 안 죽이면 화면상에서 계속 날라다님

public class Devil_lyd : MonoBehaviour
{
    //데빌 프리팹을 넣어주기
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
        //1.오른쪽 마우스를 눌렀을 때 만약 이름이 Devil이면 죽는다.
        //2.데빌은 3초에 한번씩 생성된다.
        if(currentTime > createTime)
        {

        }
        //3. 크기가 점점 커진다.
        

        if(Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.transform.name == "Devil")
                {
                    //사운드 켜기
                    //클릭이펙트 켜주기
                    //+100점 이미지 띄우기
                    //점수 100점
                    GameManager.instance.score += 100;
                    Destroy(gameObject);
                }
            }
        }


    }
}
