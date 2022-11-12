using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get => _instance; }
    static MapManager _instance;
    private static string _mapName;

    PlayerManager playerManager;
    public enum SceneID
    {
        Title,
        Tutorial,
        MainGameScene1,
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
        _mapName = SceneManager.GetActiveScene().name;
        //Fade.Instance.fadeDelegate += Delegedetest;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MapManager.Instance.CallFadeOut(SceneID.Tutorial);
        }
    }
    public int SceneStart(int HP,int MaxHP)
    {
        int returnHP;
        if(_mapName == "TutorialScene"||_mapName=="MainGameScene")
        {
            HP = MaxHP;
        }
        return returnHP = HP;
    }
    public void SceneChange(SceneID Scene)
    {
        switch (Scene)
        {
            case SceneID.Title:
                SceneManager.LoadScene("TitleScene");
                PlayerManager.Instance.PlayerSetActive(false);
                //playerManager.PlayerSetActive(false);
                break;
            case SceneID.Tutorial:
                SceneManager.LoadScene("TutorialScene");
                HPManager.instance.HpReset();
                //playerManager.PlayerSetActive(true);
                break;
            case SceneID.MainGameScene1:
                SceneManager.LoadScene("MainGameScene");
                HPManager.instance.HpReset();
                //playerManager.PlayerSetActive(true);
                break;
            case SceneID.GameOver:
                SceneManager.LoadScene("GameOver");
                //playerManager.PlayerSetActive(false);
                break;
            case SceneID.GameClear:
                SceneManager.LoadScene("GameClear");
                //playerManager.PlayerSetActive(false);
                break;
            default:
                Debug.LogWarning("ÇªÇÃÉ}ÉbÉvÇÕë∂ç›ÇµÇ‹ÇπÇÒ");
                break;
        }
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //Fade.FadeReset();

    }
    public void CallFadeOut(SceneID scene)
    {
       //StartCoroutine(Fade.FadeChange(false,SceneChange, scene));
    }

}
