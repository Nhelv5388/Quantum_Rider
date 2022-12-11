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
    private Image _image;

    PlayerManager playerManager;
    public enum SceneID
    {
        Title,
        Tutorial,
        MainGameScene,
        GameOver,
        GameClear,
        None
    }
    private void Awake()
    {
        playerManager = PlayerManager.Instance;
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        Fade.fadeDelegate += CallFadeIn;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(Fade.IEFadeIn(_image, _fadeTime));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(Fade.IEFadeOut(_image, _fadeTime,SceneChange,SceneID.GameOver));
        }
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
                SoundManager.instance.Play("Title");//今後ゲームクリア用の音源追加予定
                break;
            default:
                Debug.LogWarning("そのマップは存在しません");
                break;
        }
    }
    public void CallFadeIn(SceneID scene)
    {
        //StartCoroutine(Fade.FadeChange(false,SceneChange, scene));
        //StartCoroutine(Fade.FadeChange(_image,_fadeTime,SceneChange,scene));
        Fade.FadeChange(_image, _fadeTime, SceneChange, scene);
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (_image == null&& GameObject.Find("FadeImage") != null)
        {
            _image = GameObject.Find("FadeImage").GetComponent<Image>();
            
        }
        
        //Debug.Log(_image);
        //シーン実行時にimage取得
        StartCoroutine(Fade.IEFadeIn(_image, _fadeTime));
    }
}
