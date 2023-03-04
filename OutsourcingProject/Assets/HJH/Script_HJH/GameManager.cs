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
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "점수 : " + score;
        if(score > 100000)
        {
            score = 99999;
        }
        //timeText.text = time.ToString();
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

    void PassWordDone()
    {
        if(passWord == int.Parse(passWordInput.text))
        {
            SceneManager.LoadScene("SettingScene");
            passWordBG.SetActive(false);
        }
    }
}
