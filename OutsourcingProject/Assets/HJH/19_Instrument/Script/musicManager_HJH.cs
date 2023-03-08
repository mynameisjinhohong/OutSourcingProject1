using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager_HJH : MonoBehaviour
{
    Camera cam;
    Vector3 camOriginPos;
    void Start()
    {
        cam = Camera.main;
        camOriginPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CameraShake(float duration,float magnitude)
    {
        float timer = 0;
        while(timer <= duration)
        {
            cam.transform.localPosition = Random.insideUnitSphere * magnitude + camOriginPos;
            timer += Time.deltaTime;
            yield return null;
        }
        cam.transform.localPosition = camOriginPos;
    }
}
