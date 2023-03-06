using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<string> gameName;
    public List<string> gameSubscribe;
    public List<Sprite> gameThumbnail;

    public Transform buttonParent;
    public Image preview;
    public TextMeshProUGUI subscribeText;
    public GameObject buttonPrefab;

    public GameObject passWordBG;
    public TMP_InputField passWordInput;
    public int passWord;

    public GameObject mainMenuBG;

    bool gameOver;
    
    
    public bool GameOver
    {
        
        get
        {
            return gameOver;
        }
        set
        {
            if(value == true)
            {
                //만들 예정
            }
        }
    }

    public List<string> scenesName;

    public TextMeshProUGUI scoreText;
    public int score;
    
    public static GameManager instance = null;
    int nowGameIdx = 0;

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
        for(int i =0; i < gameName.Count; i++)
        {
            GameObject btn = Instantiate(buttonPrefab, buttonParent);
            btn.GetComponent<GameButton_HJH>().idx = i;
            string name = gameName[i].Replace(" ", "\n");
            btn.GetComponent<GameButton_HJH>().gameName = name;
        }
        preview.sprite = gameThumbnail[nowGameIdx];
        subscribeText.text = gameSubscribe[nowGameIdx];
        nowGameIdx = 0;
        gameOver = false;
        passWordInput.onSubmit.AddListener(PassWordDone);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "점수 : " + score;
        if(score >= 100000)
        {
            score = 99999;
        }
        else if(score <= 0)
        {
            score = 0;
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene(scenesName[nowGameIdx]);
        Invoke("MainBgOff", 0.1f);
        
    }

    void MainBgOff()
    {
        mainMenuBG.SetActive(false);

    }

    public void GameSet(int idx)
    {
        preview.sprite = gameThumbnail[idx];
        subscribeText.text = gameSubscribe[idx];
        nowGameIdx = idx;
    }

    public void PassWordDone(string pass)
    {
        if(passWord == int.Parse(pass))
        {
            passWordBG.SetActive(false);
            SceneManager.LoadScene("SettingScene");
        }
    }
}
