using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager_HJH : MonoBehaviour
{

    planet_HJH[,] planets;

    public GameObject planetPrefab;
    public Transform[] planetFac;
    // Start is called before the first frame update
    void Start()
    {
        planets = new planet_HJH[8, 5];
        for(int i =0; i< 8; i++)
        {
            for(int j =0; j<5; j++)
            {
                GameObject planet = Instantiate(planetPrefab, planetFac[i].position,Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
