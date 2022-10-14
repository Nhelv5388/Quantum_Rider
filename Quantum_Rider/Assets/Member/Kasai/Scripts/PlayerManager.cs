using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get => _instance; }
    static PlayerManager _instance;

    private GameObject playerObject;
    private int _returnHP=0;

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    public int Damage(int Damage,int HP)
    {
        //プレイヤーのHPバーを作ろうね
        HP -= Damage;
        _returnHP= HP;
        if (_returnHP <= 0)
        {
            //しね
        }
        return _returnHP;
               
    }
    public int Heal(int Heal, int HP, int MaxHP)
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
    public void PlayerSetActive(bool setActive)
    {
        if(setActive)
        {
            playerObject.SetActive(true);
        }
        else
        {
            playerObject.SetActive(false);
        }
    }
}
