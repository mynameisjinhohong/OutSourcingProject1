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
    Camera cam;

    public float speed = 10f;

    //fly 상태랑 화면에서 움직이는 상태 만들어주기
    public enum State
    {
        
        Big,
        Move
    }
    public State state;
    Vector3 pos;

    private int Count = 0;
    public int devilCount;
    //스케일커지도록
    public float scaleSpeed = 2f;
    private float maxSizeX = 40f;
    private float maxSizeY = 40f;

    private float moveSpeed = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        state = State.Big;
        if(state == State.Move)
        {
            Vector3 viewPos = transform.position;
            viewPos.x += Random.Range(-1f, 1f) * speed * Time.deltaTime;
            viewPos.y += Random.Range(-1f, 1f) * speed * Time.deltaTime;
            transform.position = viewPos;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //1.오른쪽 마우스를 눌렀을 때 만약 이름이 Devil이면 죽는다. o
       

        if (state == State.Big && transform.localScale.x < maxSizeX  && transform.localScale.y < maxSizeY)
        {
            transform.localScale = new Vector3(transform.localScale.x + 1f * scaleSpeed * Time.deltaTime, transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);

        }
        //DevilMove();
        if(transform.localScale.x >= maxSizeX && transform.localScale.y >= maxSizeY)
        {
            state = State.Move;
            // 이동할 방향 계산
            float moveX = Input.GetAxisRaw("Horizontal"); // 좌우 이동 입력
            float moveY = Input.GetAxisRaw("Vertical"); // 상하 이동 입력
            Vector3 moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            //Vector3 moveDirection = new Vector3(moveX, moveY, 0f).normalized;

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        ViewPos();
       /* currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {

        }*/
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            //한 -3.5부터 죽일수있도록
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.name == "Devil")
                {

                    Debug.Log("클릭");
                    //사운드 켜기
                    //클릭이펙트 켜주기
                    //+100점 이미지 띄우기
                    //점수 100점
                    GameManager.instance.score += 100; //에러뜸
                    devilCount++;
                    Count = devilCount;
                    Destroy(gameObject);
                }

                print(hitinfo.transform.name);
            }
        }

        

    }
    private void ViewPos()
    {
        //화면밖으로 못나가게 하기
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    /*void DevilMove()
    {
        if(transform.localScale.x >= maxSizeX && transform.localScale.y >= maxSizeY)
        {
            state = State.Move;
            ;
            

            *//*float x = Mathf.Clamp(transform.position.x, -5f, 5f);
            float y = Mathf.Clamp(transform.position.y, -5f, 5f);
            transform.position = new Vector3(x, y, 0);*//*

        }
    }*/
}
