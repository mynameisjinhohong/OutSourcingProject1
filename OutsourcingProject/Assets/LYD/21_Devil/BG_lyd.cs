using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_lyd : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Vector3 leftBottom = cam.ScreenToWorldPoint(new Vector3(0, 0, 10));
        Vector3 rightTop = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 10));
        Vector3 finish = rightTop - leftBottom;
        gameObject.transform.localScale = new Vector3(finish.x, finish.y, 1);
        print(finish.x);
        print(finish.y);
        //1. �������ߴ� �� ����� 11:20 ������ �Ǽ� ȭ�� �̳��̻���.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
