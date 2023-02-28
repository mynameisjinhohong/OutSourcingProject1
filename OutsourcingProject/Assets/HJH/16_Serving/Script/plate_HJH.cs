using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate_HJH : MonoBehaviour
{
    enum State
    {
        Idle,
        Open,
        Spider
    }
    State state = State.Idle;
    Camera cam;
    Vector3 foodPositon;
    Vector3 foodRotation;
    Vector3 spiderPosition;

    public GameObject plateEffect;
    public GameObject clickEffect;

    public AudioSource plateSound;
    public AudioSource spiderSound;

    public Animator setAni;
    public GameObject plateParent;
    public GameObject plate;
    public GameObject spider;
    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        foodPositon = food.transform.position;
        foodRotation = food.transform.rotation.eulerAngles;
        spiderPosition = spider.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Scence 에서 카메라에서 나오는 레이저 눈으로 확인하기
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.transform.name == "Plate" && state == State.Idle)
                {
                    if(raycastHit.transform.parent.parent == gameObject.transform)
                    {
                        plateSound.Play();
                        Instantiate(plateEffect, raycastHit.transform.position, Quaternion.identity);
                        state = State.Open;
                        setAni.SetTrigger("SpiderGo");
                        plate.SetActive(false);
                    }
                }
                
                if (raycastHit.transform.name == "Spider" && state == State.Open)
                {
                    if (raycastHit.transform.parent == gameObject.transform)
                    {
                        spiderSound.Play();
                        Debug.Log("소리남");
                        Instantiate(clickEffect, raycastHit.transform.position, Quaternion.identity);
                        GameManager.instance.score += Random.Range(50, 70);
                        spider.SetActive(false);
                    }
                }

                if (raycastHit.transform.name == "Spider" && state == State.Spider)
                {
                    if (raycastHit.transform.parent == gameObject.transform)
                    {
                        spiderSound.Play();
                        Debug.Log("소리남");
                        Instantiate(clickEffect, raycastHit.transform.position, Quaternion.identity);
                        GameManager.instance.score += Random.Range(80, 100);
                        spider.SetActive(false);
                    }
                    //Invoke("SpiderEnd", 1f);
                }
            }
        }
    }
    public void SpiderGo()
    {
        setAni.SetTrigger("SpiderGo");
    }

    public void MoveParent()
    {
        if (spider.activeInHierarchy)
        {
            food.transform.parent = spider.transform;
            state = State.Spider;
        }
    }

    public void SpiderEnd()
    {
        spider.SetActive(true);
        if (state == State.Spider)
        {
            plate.SetActive(true);
            state = State.Idle;
        }
        else if(state == State.Open)
        {
            Invoke("SpiderGo", 1);
        }
        food.transform.parent = plateParent.transform;
        food.transform.position = foodPositon;
        food.transform.localEulerAngles = foodRotation;
    }
}
