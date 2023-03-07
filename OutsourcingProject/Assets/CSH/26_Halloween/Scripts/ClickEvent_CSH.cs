using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent_CSH : MonoBehaviour
{
    Camera cam;
    public AudioSource clickSound;
    public GameObject clickEffect;
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
            }
        }
    }
}
