using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HalloweenManager_CSH : MonoBehaviour
{
    public int remains = 0;
    public TextMeshProUGUI remainText;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainText.text = "쌓인 먼지: " + remains;
        if (remains >= 20)
        {
            //게임오버
            GameManager.instance.GameOver = true;
        }
    }
}
