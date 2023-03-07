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
        remainText.text = "���� ����: " + remains;
        if (remains >= 20)
        {
            //���ӿ���
            GameManager.instance.GameOver = true;
        }
    }
}
