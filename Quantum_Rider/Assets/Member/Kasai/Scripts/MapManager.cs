using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get => _instance; }
    static MapManager _instance;
    [SerializeField] private float _fadeTime;
    public enum SceneID
    {
        //別スクリプトからマップ名を指定するときに使用
        Title,
        Tutorial,
        MainGameScene,
        GameOver,
        GameClear,
        None
    }
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


        Application.targetFrameRate = 160;
        ////FadeからImageを取得
        //Fade.GetFadeImage();//タイトルでボタンが押せない問題を修正のため
        ////var _fadeImage = GameObject.Find("FadeImage");
        ////_image= _fadeImage.GetComponent<Image>();
        //Debug.Log(Fade._fadeImage);
        //Fade._fadeImage.gameObject.SetActive(false);

    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        Fade.fadeDelegate += CallFadeIn;

        //タイトルシーンのみで実行
        if (SceneManager.GetActiveScene().name == "TitleSeki")
        {
            SoundManager.instance.Play("Title");
            //FadeからImageを取得
            Fade.GetFadeImage();//タイトルでボタンが押せない問題を修正のため
            //Debug.Log(Fade._fadeImage);
            Fade._fadeImage.gameObject.SetActive(false);
        }

    }
    private void Update()
    {
        //デバッグ用
        //if(Input.GetKeyDown(KeyCode.I))
        //{
        //    StartCoroutine(Fade.IEFadeIn(_fadeTime));
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    StartCoroutine(Fade.IEFadeOut(_fadeTime,SceneChange,SceneID.GameOver));
        //}
        
        
    }
    public void SceneChange(SceneID Scene)
    {
        switch (Scene)
        {
            case SceneID.Title:
                SceneManager.LoadScene("TitleSeki");
                SoundManager.instance.Play("Title");
                //PlayerManager.Instance.PlayerSetActive(false);
                break;
            case SceneID.Tutorial:
                SceneManager.LoadScene("TutorialScene");
                //SoundManager.instance.Play("MainGame");
                HPManager.instance.HpReset();
                break;
            case SceneID.MainGameScene:
                SceneManager.LoadScene("MainGameScene");
                SoundManager.instance.Play("MainGame");
                HPManager.instance.HpReset();
                break;
            case SceneID.GameOver:
                SceneManager.LoadScene("GameOver");
                SoundManager.instance.Play("GameOver");
                HPManager.instance.HpReset();
                break;
            case SceneID.GameClear:
                SceneManager.LoadScene("GameClear");
                SoundManager.instance.Play("GameClear");//今後ゲームクリア用の音源追加予定
                break;
            default:
                Debug.LogWarning("そのマップは存在しません");
                break;
        }
    }
    public void CallFadeIn(SceneID scene)
    {
        Fade.FadeChange(_fadeTime, SceneChange, scene);
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //if (_image == null&& GameObject.Find("FadeImage") != null)
        //{
        //    _image = GameObject.Find("FadeImage").GetComponent<Image>();
        //}
        if (SceneManager.GetActiveScene().name == "MainGameScene")
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        StartCoroutine(Fade.IEFadeIn(_fadeTime));
    }
}
