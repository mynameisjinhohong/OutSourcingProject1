using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilFactory : MonoBehaviour
{
    public GameObject devilPre;

    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //데빌에 있는 스크립트에서 devilCount를 어떻게 가져올수있어?????
        /*currentTime += Time.deltaTime;
        if (devilCount < 15 && currentTime > 3)
        {
            GameObject go = Instantiate(devilPre);
            go.transform.position = transform.position;
            Debug.Log("eo");

        }
        else if (devilCount >= 15 && currentTime > 2)
        {
            GameObject go = Instantiate(devilPre);
            go.transform.position = transform.position;


        }
        else if (devilCount >= 35 && currentTime > 1)
        {
            GameObject go = Instantiate(devilPre);
            go.transform.position = transform.position;

        }*/
    }
}
