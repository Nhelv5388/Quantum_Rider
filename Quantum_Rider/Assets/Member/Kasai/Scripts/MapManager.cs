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
        //�ʃX�N���v�g����}�b�v�����w�肷��Ƃ��Ɏg�p
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
        ////Fade����Image���擾
        //Fade.GetFadeImage();//�^�C�g���Ń{�^���������Ȃ������C���̂���
        ////var _fadeImage = GameObject.Find("FadeImage");
        ////_image= _fadeImage.GetComponent<Image>();
        //Debug.Log(Fade._fadeImage);
        //Fade._fadeImage.gameObject.SetActive(false);

    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        Fade.fadeDelegate += CallFadeIn;

        //�^�C�g���V�[���݂̂Ŏ��s
        if (SceneManager.GetActiveScene().name == "TitleSeki")
        {
            SoundManager.instance.Play("Title");
            //Fade����Image���擾
            Fade.GetFadeImage();//�^�C�g���Ń{�^���������Ȃ������C���̂���
            //Debug.Log(Fade._fadeImage);
            Fade._fadeImage.gameObject.SetActive(false);
        }

    }
    private void Update()
    {
        //�f�o�b�O�p
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
                SoundManager.instance.Play("GameClear");//����Q�[���N���A�p�̉����ǉ��\��
                break;
            default:
                Debug.LogWarning("���̃}�b�v�͑��݂��܂���");
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
