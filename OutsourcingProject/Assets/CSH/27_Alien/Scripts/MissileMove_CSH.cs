using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove_CSH : MonoBehaviour
{
    GameObject attackTarget;
    Vector3 dir;
    public float speed;
    public AudioSource ExplosionSound;
    public GameObject ExplosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        attackTarget = GameObject.Find("EarthCollider");
        dir = attackTarget.transform.position - transform.position;
        dir.Normalize();
        transform.up = dir;
    }

    // Update is called once per frame
    void Update()
    {
        //float tempX = attackTarget.transform.position.x - transform.position.x;
        //float tempY = attackTarget.transform.position.y - transform.position.y;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "EarthCollider")
        {
            GameObject.Find("AlienCanvas").GetComponent<ClickEvent_CSH>().AlienExplosionSound.Play();
            //HP감소
            GameObject.Find("AlienCanvas").GetComponent<AlienManager_CSH>().HP--;
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            //미사일 파괴
            
            Destroy(this.transform.gameObject);
        }
    }
}
