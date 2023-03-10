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
    void Start()
    {
        cam = Camera.main;
        camOriginPos = cam.transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Scence ���� ī�޶󿡼� ������ ������ ������ Ȯ���ϱ�
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                instruments_HJH instruments;
                if(raycastHit.transform.gameObject.TryGetComponent(out instruments))
                {
                    audio.clip = instruments.sound;
                    audio.Play();
                }
            }
        }
    }

    
}
