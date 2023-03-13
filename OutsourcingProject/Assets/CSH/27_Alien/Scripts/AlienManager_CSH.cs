using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AlienManager_CSH : MonoBehaviour
{
    public int HP = 0;
    public TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "남은 HP: " + HP;
        if (HP <= 0)
        {
            HP = 0;
            //게임오버
            GameManager.instance.GameOver = true;
        }
    }
}
