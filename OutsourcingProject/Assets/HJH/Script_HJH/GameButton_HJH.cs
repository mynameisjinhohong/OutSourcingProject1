using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameButton_HJH : MonoBehaviour
{
    public int idx;
    public string gameName;
    public TextMeshProUGUI gameNameTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameNameTxt.text = gameName;
    }

}
