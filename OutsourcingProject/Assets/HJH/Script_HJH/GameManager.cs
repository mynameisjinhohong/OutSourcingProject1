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

    public TextMeshProUGUI timeText;
    public List<string> scenesName;
    public List<int> scenesList;
    public bool loop;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "  Á¡¼ö : " + score;
        timeText.text = time.ToString();
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
