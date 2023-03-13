using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager_HJH : MonoBehaviour
{
    Camera cam;
    Vector3 camOriginPos;
    public List<GameObject> instruments;
    AudioSource audio;
    public AudioSource clapAudio;
    public List<GameObject> Checks;
    public GameObject effects;
    public List<Transform> downPos;
    public List<Transform> stayPos;
    public GameObject clapImage;
    bool[] checks;
    void Start()
    {
        checks = new bool[13];
        cam = Camera.main;
        camOriginPos = cam.transform.position;
        audio = GetComponent<AudioSource>();
        StartCoroutine(MakeInstruments());
        StartCoroutine(MakeInstruments2());
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
                instruments_HJH instruments;
                if(raycastHit.transform.gameObject.TryGetComponent(out instruments))
                {
                    audio.clip = instruments.sound;
                    Checks[(int)instruments.instruments].GetComponent<SpriteRenderer>().color = Color.white;
                    checks[(int)instruments.instruments] = true;
                    audio.Play();
                    GameManager.instance.score += 50;
                    Instantiate(effects, raycastHit.transform.position, Quaternion.identity);
                    Destroy(raycastHit.transform.gameObject);
                    for(int i =0; i<checks.Length; i++)
                    {
                        if(checks[i] == false)
                        {
                            break;
                        }
                        if(i == checks.Length - 1)
                        {
                            clapAudio.Play();
                            GameManager.instance.score += 1000;
                            clapImage.GetComponent<Animator>().SetTrigger("Clap");
                            for(int j =0; j<checks.Length; j++)
                            {
                                Color color = Color.white;
                                color.a = 0.4f;
                                checks[j] = false;
                                Checks[j].GetComponent<SpriteRenderer>().color = color;
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator MakeInstruments()
    {
        while (true)
        {
            for (int i = 0; i < downPos.Count; i++)
            {
                int ran = Random.Range(0, 3);
                if (ran == 1)
                {
                    int ran2 = Random.Range(0, 13);
                    GameObject g = Instantiate(instruments[ran2], downPos[i].position, Quaternion.identity);
                    g.GetComponent<instruments_HJH>().type = instruments_HJH.Type.down;
                    g.GetComponent<instruments_HJH>().start = true;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
    IEnumerator MakeInstruments2()
    {
        while (true)
        {
            for (int i = 0; i < stayPos.Count; i++)
            {
                int ran = Random.Range(0, 2);
                if (ran == 1)
                {
                    int ran2 = Random.Range(0, 13);
                    GameObject g = Instantiate(instruments[ran2], stayPos[i].position, Quaternion.identity);
                    g.GetComponent<instruments_HJH>().type = instruments_HJH.Type.wait;
                    g.GetComponent<instruments_HJH>().start = true;
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitForSeconds(7f);
        }
    }


}
