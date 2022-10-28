using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get => _instance; }
    static MapManager _instance;
    private static string _mapName;
    private int _PlayerMaxHp = 10;//Managerが持つプレイヤーのHP保管用
    public enum SceneID
    {
        Title,
        Tutorial,
        MainGameScene,
        GameOver,
        GameClear
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
    }
    void Start()
    {
        _mapName = SceneManager.GetActiveScene().name;   
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
        switch(Scene)
        {
            case SceneID.Title:
                SceneManager.LoadScene("TitleScene");
                PlayerManager.Instance.PlayerSetActive(false);
                break;
            case SceneID.Tutorial:
                SceneManager.LoadScene("Tutorial");
                PlayerManager.Instance.PlayerSetActive(true);
                break;
            case SceneID.MainGameScene:
                SceneManager.LoadScene("MainGameScene");
                PlayerManager.Instance.PlayerSetActive(true);
                break;
            case SceneID.GameOver:
                SceneManager.LoadScene("GameOver");
                PlayerManager.Instance.PlayerSetActive(false);
                break;
            case SceneID.GameClear:
                SceneManager.LoadScene("GameClear");
                PlayerManager.Instance.PlayerSetActive(false);
                break;
            default:
                Debug.LogWarning("そのマップは存在しません");
                break;
        }
    }

    //シーンが始まったときの処理
    //シーンごとの処理の分岐
    
}
