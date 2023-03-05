using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 3초에 하나씩 enemyfactory에서 생성된다. (한번에가 아닌 랜덤으로 enemyFactory)
//3. 곡선을 그리면서 카메라로 날라와서 멈추도록 하게하면됨!! *
//4. 레이를 쏴서 나를 클릭했을 때 죽는다.
//5. 안 죽이면 화면상에서 계속 날라다님

public class Devil_lyd : MonoBehaviour
{
    //데빌 프리팹을 넣어주기
    //public GameObject devilPre;
    private float createTime = 3;
    float currentTime = 0;
    Camera cam;

    public float speed = 10f;
    public float curveStrength = 1f;
    public float curveFrequency = 1f;

    //fly 상태랑 화면에서 움직이는 상태 만들어주기
    public enum State
    {
        Idle,
        Fly,
        Move
    }
    State state = State.Idle; 
    Vector3 pos;
    //만약 devilCount가 15마리가 되면 2초에 한번씩 생성하도록

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
        //1.오른쪽 마우스를 눌렀을 때 만약 이름이 Devil이면 죽는다.
        //2.만약 timer가 데빌은 3초에 한번씩 생성된다.

        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {

        }
        
        

        if(Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //여기서 범위를 정해줘야 할듯. 
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.transform.name == "Devil" && state == State.Move)
                {
                    Debug.Log("클릭");
                    //사운드 켜기
                    //클릭이펙트 켜주기
                    //+100점 이미지 띄우기
                    //점수 100점
                    GameManager.instance.score += 100;
                    devilCount++;
                    Destroy(gameObject);
                }
            }
        }
        pos = Vector3.back;
        transform.position += speed * Time.deltaTime * pos;

        //카메라의 transform.position

    }
}
