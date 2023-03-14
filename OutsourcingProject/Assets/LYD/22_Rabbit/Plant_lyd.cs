using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_lyd : MonoBehaviour
{
    //public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
            Debug.Log("트리거 발동!");
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
            Debug.Log("트리거 발동!");
        }
    }*/
   
}
