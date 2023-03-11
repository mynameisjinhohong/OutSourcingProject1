using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager_lyd : MonoBehaviour
{
    Camera cam;
    public GameObject devilPre; //µ¥ºô ÇÁ¸®ÆÕ
    //public GameObject devilFactory; //µ¥ºôÆÑÅä¸®¿¡¼­ µ¥ºô ÇÁ¸®ÆÕÀÌ »ý¼ºµÇµµ·Ï
    public GameObject devilExplosion;

    public AudioSource clickSound;

    float currentTime = 0;
    float randomX;
    float randomY;
    public int devilCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (devilCount < 15 && currentTime > 3)
        {
            randomX = Random.Range(-7.97f, 7.97f); //µ¥ºôÀÌ ³ªÅ¸³¯ xÁÂÇ¥ ·£´ý »ý¼º
            randomY = Random.Range(-2.46f, 4.48f); //µ¥ºô ³ªÅ¸³¯ yÁÂÇ¥ ·£´ý »ý¼º
            GameObject devil = (GameObject)Instantiate(devilPre, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            print(randomX);
            print(randomY);
            currentTime = 0;
        }
       else if (devilCount >= 15 && currentTime > 2)
        {
            randomX = Random.Range(-7.97f, 7.97f); //µ¥ºôÀÌ ³ªÅ¸³¯ xÁÂÇ¥ ·£´ý »ý¼º
            randomY = Random.Range(-2.46f, 4.48f); //µ¥ºô ³ªÅ¸³¯ yÁÂÇ¥ ·£´ý »ý¼º
            GameObject devil = (GameObject)Instantiate(devilPre, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            print(randomX);
            print(randomY);
            currentTime = 0;

        }
        else if (devilCount >= 35 && currentTime > 1)
        {
            randomX = Random.Range(-7.97f, 7.97f); //µ¥ºôÀÌ ³ªÅ¸³¯ xÁÂÇ¥ ·£´ý »ý¼º
            randomY = Random.Range(-2.46f, 4.48f); //µ¥ºô ³ªÅ¸³¯ yÁÂÇ¥ ·£´ý »ý¼º
            GameObject devil = (GameObject)Instantiate(devilPre, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            print(randomX);
            print(randomY);
            currentTime = 0;

        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            // Á×ÀÏ¼öÀÖµµ·Ï
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.name == "Devil(Clone)")
                {

                    Debug.Log("Å¬¸¯");
                    //»ç¿îµå ÄÑ±â
                    clickSound.Play();
                    //+100Á¡ ÀÌ¹ÌÁö ¶ç¿ì±â
                    //Á¡¼ö 100Á¡
                    GameManager.instance.score += 100; 
                    
                    //Å¬¸¯ÀÌÆåÆ® ÄÑÁÖ±â
                    Instantiate(devilExplosion, hitinfo.transform.position, Quaternion.identity);
                    GameObject.Destroy(hitinfo.transform.gameObject);
                    devilCount++;
                    Debug.Log("Á×¾ú´Ù");

                }

                

                print(hitinfo.transform.name);
                print(devilCount);
            }
        }
    }
}
