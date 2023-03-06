using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameButton_HJH : MonoBehaviour
{
    public int idx;
    public string gameName;
    public TextMeshProUGUI gameNameTxt;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        gameNameTxt.text = gameName;
    }

    public void Clicked()
    {
        GameManager.instance.GameSet(idx);
    }

}
