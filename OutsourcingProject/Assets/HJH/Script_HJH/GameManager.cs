using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject passWordBG;
    public TMP_InputField passWordInput;
    public int passWord;

    public TextMeshProUGUI scoreText;
    public int score;
    static GameManager instance = null;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "  Á¡¼ö : " + score;
    }
    void PassWordDone()
    {
        if(passWord == int.Parse(passWordInput.text))
        {
            SceneManager.LoadScene("SettingScene");
            passWordBG.SetActive(false);
        }
    }
}
