using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xmark_HJH : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        Invoke("TurnOff", 0.5f);
    }
    void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
