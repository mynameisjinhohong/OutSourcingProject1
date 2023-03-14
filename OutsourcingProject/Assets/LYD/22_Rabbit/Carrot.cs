using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] GameObject[] plantPre;
    [SerializeField] float secondSpawn = 0.3f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlantSpawn());
    }

    IEnumerator PlantSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y, -0.3f);
            GameObject go = Instantiate(plantPre[Random.Range(0, plantPre.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
