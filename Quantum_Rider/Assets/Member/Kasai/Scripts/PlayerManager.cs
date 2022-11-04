using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get => _instance; }
    static PlayerManager _instance;

    private GameObject playerObject;
    private GameObject startObject;
    private int _returnHP=0;

    MapManager mapManager;

    private void Awake()
    {

        mapManager = MapManager.Instance;
        if(Instance == null)
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        startObject = GameObject.FindGameObjectWithTag("Start");
    }
    public int Damage(int Damage,int HP)//ダメージ処理
    {
        //プレイヤーのHPバーを作ろうね
        HP -= Damage;
        _returnHP= HP;
        if (_returnHP <= 0)
        {
            //MapManager.Instance.SceneChange(MapManager.SceneID.GameOver);
            mapManager.SceneChange(MapManager.SceneID.GameOver);
        }
        return _returnHP;
               
    }
    public int Heal(int Heal, int HP, int MaxHP)//体力回復
    {
        
        //プレイヤーのHPバーを作ろうね
        HP += Heal;
        _returnHP = HP;
        if (_returnHP > MaxHP)
        {
            _returnHP= MaxHP;
        }
        return _returnHP;

    }
    public void PlayerSetActive(bool setActive)//プレイヤーの表示切替(タイトルなどではfalseにする)
    {
        if(setActive)
        {
            playerObject.SetActive(true);
            playerObject.transform.position = startObject.transform.position;//プレイヤーの座標をStartObjectに移動
        }
        else
        {
            playerObject.SetActive(false);
        }
    }
}
