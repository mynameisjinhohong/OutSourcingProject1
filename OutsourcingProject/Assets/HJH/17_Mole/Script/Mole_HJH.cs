using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mole_HJH : MonoBehaviour
{
    Camera cam;
    public List<GameObject> moles;
    public AudioSource wrong;
    public GameObject xMark;
    AudioSource click;

    public TextMeshProUGUI moleText;

    int remainMole = 30;
    public GameObject clickEffect;
    void Start()
    {
        click = GetComponent<AudioSource>();
        StartCoroutine(Mole());
        cam = Camera.main;
    }
    float currentTime;
    // Update is called once per frame
    void Update()
    {
        moleText.text = "남은 두더지 수 : " + remainMole;
        if(remainMole <= 0)
        {
            GameManager.instance.GameOver = true;
            return;
        }
        currentTime += Time.deltaTime;
        if(currentTime > 1)
        {
            currentTime = 0;
            if(GameManager.instance.score > 10)
            {
                GameManager.instance.score -= 10;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Scence 에서 카메라에서 나오는 레이저 눈으로 확인하기
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.transform.name == "Mole1")
                {
                    click.Play();
                    Instantiate(clickEffect, raycastHit.transform.position, Quaternion.identity);
                    raycastHit.transform.parent.GetChild(2).gameObject.SetActive(true);
                    raycastHit.transform.gameObject.SetActive(false);
                    GameManager.instance.score += 100;
                    remainMole -= 1;
                }
                else if(raycastHit.transform.name == "Mole2")
                {
                    wrong.Play();
                    Instantiate(clickEffect, raycastHit.transform.position, Quaternion.identity);
                    xMark.transform.position = new Vector3(raycastHit.point.x,raycastHit.point.y,-0.5f);
                    xMark.SetActive(true);
                    if (GameManager.instance.score > 15)
                    {
                        GameManager.instance.score -= 15;
                    }
                }
            }
        }
    }
    IEnumerator Mole()
    {
        while (true)
        {
            bool[] moleCheck = new bool[8];
            for (int i = 0; i < 5; i++)
            {
                int check = Random.Range(0, 8);
                moleCheck[check] = true;
            }
            for (int i = 0; i < 8; i++)
            {
                if (moleCheck[i])
                {
                    int oneTwo = Random.Range(0, 2);
                    if (oneTwo == 0)
                    {
                        moles[i].transform.GetChild(0).gameObject.SetActive(true);
                        moles[i].transform.GetChild(1).gameObject.SetActive(false);
                        moles[i].transform.GetChild(2).gameObject.SetActive(false);
                    }
                    else if (oneTwo == 1)
                    {
                        moles[i].transform.GetChild(0).gameObject.SetActive(false);
                        moles[i].transform.GetChild(1).gameObject.SetActive(true);
                        moles[i].transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                else
                {
                    moles[i].transform.GetChild(0).gameObject.SetActive(false);
                    moles[i].transform.GetChild(1).gameObject.SetActive(false);
                    moles[i].transform.GetChild(2).gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
