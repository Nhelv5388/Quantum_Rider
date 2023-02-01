using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get => _instance; }
    static MapManager _instance;
    [SerializeField] private float _fadeTime;
    private SceneID beforeMap = SceneID.None;//���O�ɂ����V�[�������i�[
    public enum SceneID
    {
        //�ʃX�N���v�g����}�b�v�����w�肷��Ƃ��Ɏg�p
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
        //FPS���Œ�
        Application.targetFrameRate = 160;

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
            Fade._fadeImage.gameObject.SetActive(false);
        }

    }
    //Scene�̃}�b�v�Ɉړ�
    public void SceneChange(SceneID Scene)
    {
        switch (Scene)
        {
            case SceneID.Title:
                SceneManager.LoadScene("TitleSeki");
                SoundManager.instance.Play("Title");
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
        //���C���Q�[���Ɉړ�������}�E�X�J�[�\��������
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
        //GameOver�X�N���v�g�Ƀ��g���C���Ɉړ�����}�b�v���w�肷��
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            GetComponent<GameOver>();
            GameOver.mapName = beforeMap;
        }
            StartCoroutine(Fade.IEFadeIn(_fadeTime));
    }
}
