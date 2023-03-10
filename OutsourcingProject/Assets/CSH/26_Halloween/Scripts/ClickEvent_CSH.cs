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

    public AudioSource TreasureSound;
    public GameObject TreasureEffect;

    public AudioSource DrinkSound;
    public GameObject DrinkEffect;

    public AudioSource TargetSound;
    //public GameObject TargetEffect;

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
            //화면에 클릭한 방향으로 ray발사
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Scence 에서 카메라에서 나오는 레이저 눈으로 확인하기
            //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit raycastHit)) 
            {
                //첫번째 게임
                if (raycastHit.transform.name == "Dust(Clone)") //먼지를 클릭하면
                {
                    //Score 상승
                    GameManager.instance.score += 100;
                    //남은 개수 줄이기
                    GameObject.Find("HalloweenCanvas").GetComponent<HalloweenManager_CSH>().remains--;
                    //먼지 파괴
                    clickSound.Play();
                    Instantiate(clickEffect, raycastHit.transform.position, Quaternion.identity);
                    GameObject.Destroy(raycastHit.transform.gameObject);
                }
                //두번째 게임
                else if(raycastHit.transform.name == "Alien1(Clone)"|| raycastHit.transform.name == "Alien2(Clone)"|| raycastHit.transform.name == "Alien3(Clone)" || raycastHit.transform.name == "Missile(Clone)")
                {
                    //Score 상승
                    GameManager.instance.score += 100;
                    
                    //외계인 파괴, 소리와 이펙트 재생
                    AlienExplosionSound.Play();
                    Instantiate(AlienClickEffect, raycastHit.transform.position, Quaternion.identity);
                    GameObject.Destroy(raycastHit.transform.gameObject);
                }
                //세번째 게임
                else if(raycastHit.transform.name == "TreasureBox(Clone)")
                {
                    //Score 상승
                    GameManager.instance.score += 100;
                    //남은 개수 줄이기
                    GameObject.Find("TreasureCanvas").GetComponent<TreasureManager_CSH>().remains--;

                    //상자 파괴,소리와 이펙트 재생
                    TreasureSound.Play();
                    Instantiate(TreasureEffect, raycastHit.transform.position, Quaternion.identity);
                    GameObject.Destroy(raycastHit.transform.gameObject);
                }

                //다섯번째 게임
                else if(raycastHit.transform.name == "TargetPan(Clone)")
                {
                    //Score 상승
                    GameManager.instance.score += 100;
                    //과녁판 파괴,소리와 이펙트 재생
                    TargetSound.Play();
                    Instantiate(TreasureEffect, raycastHit.transform.position, Quaternion.identity);
                    GameObject.Destroy(raycastHit.transform.gameObject);
                    //재생성
                    Invoke("otherSummon",2f);
                }
            }
            
        }
    }

    public void otherSummon()
    {
        GameObject.Find("SpawnZone").GetComponent<TargetSpawn_CSH>().Summon();
    }
}
