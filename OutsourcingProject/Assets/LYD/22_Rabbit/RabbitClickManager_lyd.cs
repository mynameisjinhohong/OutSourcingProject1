using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitClickManager_lyd : MonoBehaviour
{
    Camera cam;
    public AudioSource cakeSound;
    public AudioSource goodSound;
    public GameObject smile;
    public GameObject skull;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -cam.transform.position.z;
            Vector3 ray = cam.ScreenToWorldPoint(mousePos);
            RaycastHit2D hitinfo = Physics2D.Raycast(ray, Vector2.zero);

            // 죽일수있도록
            if (hitinfo)
            {
                if (hitinfo.collider != null && hitinfo.collider.CompareTag("Cake"))
                {

                    Debug.Log("클릭");
                    //사운드 켜기
                    cakeSound.Play();
                    //+100점 이미지 띄우기
                    //점수 100점
                    GameManager.instance.score -= 100;

                    //클릭이펙트 켜주기
                    Instantiate(skull, hitinfo.transform.position, Quaternion.identity);

                    GameObject.Destroy(hitinfo.transform.gameObject);

                }

                if (hitinfo.collider != null && hitinfo.collider.CompareTag("Carrot"))
                {
                    GameManager.instance.score += 200;
                    goodSound.Play();
                    Instantiate(smile, hitinfo.transform.position, Quaternion.identity);

                    GameObject.Destroy(hitinfo.transform.gameObject);
                }
                if(hitinfo.collider != null && hitinfo.collider.CompareTag("Plant"))
                {
                    GameManager.instance.score += 100;
                    goodSound.Play();

                    Instantiate(smile, hitinfo.transform.position, Quaternion.identity);
                    GameObject.Destroy(hitinfo.transform.gameObject);

                }
                Debug.DrawRay(ray, transform.forward * 10, Color.red, 0.3f);

            }
        }
    }
}
