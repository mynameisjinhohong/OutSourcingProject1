using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove_CSH : MonoBehaviour
{
    Camera cam;
    public Vector3 dir;
    public int speed;
    public GameObject bulletFactory;
    float changeDirTime = 0;
    float fireTime = 0;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        float randirX = Random.Range(-5, 5);
        float randirY = Random.Range(-5, 5);
        dir = new Vector3(randirX, randirY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        checkPos();
        //계속 움직임
        Moving();
        //방향도 계속바꿈
        changeDir();
        //발사
        shooting();
    }


    void checkPos()
    {
        //화면 밖으로 안나가게 제한
        Vector3 worldPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldPos.x < -0.05f) worldPos.x = -0.05f;
        if (worldPos.y < -0.05f) worldPos.y = -0.05f;
        if (worldPos.x > 1.05f) worldPos.x = 1.05f;
        if (worldPos.y > 1.05f) worldPos.y = 1.05f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }


    void changeDir()
    {
        //2초에 한번씩 움직이는 방향 바꾸기
        changeDirTime += Time.deltaTime;
        if (changeDirTime >= 2)
        {
            changeDirTime = 0;
            float randirX = Random.Range(-5, 5);
            float randirY = Random.Range(-5, 5);
            dir = new Vector3(randirX, randirY, 0.0f);
        }
    }
    void shooting()
    {
        fireTime += Time.deltaTime;
        if (fireTime >= fireRate)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = transform.position;
            fireTime = 0;
        }
    }

    void Moving()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

}
