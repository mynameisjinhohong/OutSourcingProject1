using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano_HJH : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> pianoTilesWhite;
    Camera cam;
    public AudioSource wrong;
    public GameObject xMark;
    public AudioSource pianoSound;
    public AudioSource clap;

    public List<AudioClip> clips;
    public Material White;
    public Material green;
    public List<List<int>> akbos;

    GameObject nowTile;
    public int nowAkbo;
    public int nowIdx;

    public List<Animator> anis;

    void Start()
    {
        cam = Camera.main;
        akbos = new List<List<int>>();
        List<int> list = new List<int>() { 0, 0, 4, 4, 5, 5, 4, 3, 3, 2, 2, 1, 1, 0, 4, 4, 3, 3, 2, 2, 1, 4, 4, 3, 3, 2, 2, 1, 0, 0, 4, 4, 5, 5, 4, 3, 3, 2, 2, 1, 1, 0 };
        List<int> list2 = new List<int>() { 4,2,2,3,1,1,0,1,2,3,4,4,4,4,2,2,2,3,1,1,0,2,4,4,2,2,2,1,1,1,1,1,2,3,2,2,2,2,2,3,4,4,2,2,3,1,1,0,2,4,4,2,2,2,};
        List<int> list3 = new List<int>() { 2, 4, 2, 4, 0, 0, 0, 2, 4, 2, 4, 1, 1, 1, 2, 4, 2, 4, 3, 3, 3, 3, 3, 2, 2, 1, 1, 0, 3, 5, 4, 5, 4, 2, 3, 2, 1, 2, 3, 1, 2, 1, 2, 4, 5, 5, 5, 5, 5, 0, 0, 4, 4, 0, 0};
        List<int> list4 = new List<int>() { 2, 4, 4, 2, 4, 4, 5, 5, 5, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 4, 4, 4, 2, 4, 4, 5, 5, 2, 2, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1, 4, 4, 0 };
        akbos.Add(list);
        akbos.Add(list2);
        akbos.Add(list3);
        akbos.Add(list4);
        GameManager.instance.score = 1000;
        nowAkbo = Random.Range(0, akbos.Count);
        nowIdx = 0;
        nowTile = pianoTilesWhite[akbos[nowAkbo][nowIdx]];
        nowTile.GetComponent<MeshRenderer>().material = green;
    }
    float currentTime;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > 1)
        {
            GameManager.instance.score -= 1;
            currentTime = 0;
        }
        if(nowIdx > akbos[nowAkbo].Count - 1)
        {
            GameManager.instance.GameOver = true;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Scence 에서 카메라에서 나오는 레이저 눈으로 확인하기
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.gameObject == nowTile)
                {
                    nowTile.GetComponent<MeshRenderer>().material = White;
                    pianoSound.clip = clips[akbos[nowAkbo][nowIdx]];
                    pianoSound.Play();
                    nowIdx++;
                    if (nowIdx > akbos[nowAkbo].Count - 1)
                    {
                        clap.Play();
                        nowTile.GetComponent<MeshRenderer>().material = White;
                        for(int i =0;i <anis.Count; i++)
                        {
                            anis[i].SetTrigger("Jump");
                        }
                    }
                    else
                    {
                        nowTile = pianoTilesWhite[akbos[nowAkbo][nowIdx]];
                        Invoke("GoGreen", 0.1f);
                    }
                }
                else
                {
                    wrong.Play();
                    xMark.transform.position = new Vector3(raycastHit.point.x, -1.44f, 7.24f);
                    xMark.SetActive(true);
                    if (GameManager.instance.score > 15)
                    {
                        GameManager.instance.score -= 15;
                    }
                }
            }
        }
    }

    void GoGreen()
    {
        nowTile.GetComponent<MeshRenderer>().material = green;
    }
}
