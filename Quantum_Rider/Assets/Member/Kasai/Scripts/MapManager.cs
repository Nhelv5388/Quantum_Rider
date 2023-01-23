using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get => _instance; }
    static MapManager _instance;
    [SerializeField] private float _fadeTime;
    private SceneID beforeMap = SceneID.None;
    public enum SceneID
    {
        //別スクリプトからマップ名を指定するときに使用
        Title,
        Tutorial,
        EasyMap,
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
        //Debug.Log(beforeMap);

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
                SceneManager.LoadScene("TutorialMap");
                SoundManager.instance.Play("MainGame");
                beforeMap = Scene;
                HPManager.instance.HpReset();
                break;
            case SceneID.EasyMap:
                SceneManager.LoadScene("EasyMap");
                SoundManager.instance.Play("MainGame");
                beforeMap = Scene;
                HPManager.instance.HpReset();
                break;
            case SceneID.MainGameScene:
                SceneManager.LoadScene("MainGameScene");
                SoundManager.instance.Play("MainGame");
                beforeMap = Scene;
                HPManager.instance.HpReset();
                break;
            case SceneID.GameOver:
                SceneManager.LoadScene("GameOver");
                SoundManager.instance.Play("GameOver");
                HPManager.instance.HpReset();
                break;
            case SceneID.GameClear:
                SceneManager.LoadScene("GameClear");
                SoundManager.instance.Play("GameClear");
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
        //メインゲームに移動したらマウスカーソルを消す
        if (SceneManager.GetActiveScene().name == "MainGameScene" ||
            SceneManager.GetActiveScene().name == "EasyMap" ||
            SceneManager.GetActiveScene().name == "TutorialMap")
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        //
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            GetComponent<GameOver>();
            GameOver.mapName = beforeMap;
        }
            StartCoroutine(Fade.IEFadeIn(_fadeTime));
    }
}
