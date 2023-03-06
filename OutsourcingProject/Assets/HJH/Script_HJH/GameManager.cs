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
                //���� ����
            }
        }
    }


    public TextMeshProUGUI timeText;
    public List<string> scenesName;
    public List<int> scenesList;
    public int time;

    public TextMeshProUGUI scoreText;
    public int score;
    
    public static GameManager instance = null;
    
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
        gameOver = false;
        passWordInput.onSubmit.AddListener(PassWordDone);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "���� : " + score;
        if(score >= 100000)
        {
            score = 99999;
        }
        else if(score <= 0)
        {
            score = 0;
        }
    }
    //public void GameStart()
    //{
    //    SceneManager.LoadScene(scenesName[scenesList[0]]);
    //    StartCoroutine(Timer());
    //}

    //IEnumerator Timer()
    //{
    //    int nowTime = time;
    //    int nowIdx = 1;
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        nowTime--;
    //        if(nowTime <= 0)
    //        {
    //            nowTime = time;
    //            nowIdx++;
    //            if(nowIdx == scenesList.Count - 1)
    //            {
    //                if (loop)
    //                {
    //                    nowIdx = 0;
    //                }
    //                else
    //                {
    //                    SceneManager.LoadScene(1);
    //                    break;
    //                }
    //            }
    //        }

    //    }
    //}

    public void PassWordDone(string pass)
    {
        if(passWord == int.Parse(pass))
        {
            passWordBG.SetActive(false);
            SceneManager.LoadScene("SettingScene");
        }
    }
}
