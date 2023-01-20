using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager instance = null;

    public delegate void HPZero();
    public HPZero hpZero;
    public delegate void HPChange();
    public HPChange hpChange;

    [SerializeField]
    private int _PlayerHP=10;
    private int _MaxHP;
    private MapManager.SceneID mapName=MapManager.SceneID.GameOver;

    bool death = false;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _MaxHP = _PlayerHP;
    }
    public int GetHP()
    {
        return _PlayerHP;
    }
    public int Damage(int damage)
    {
        if (!ShieldImage.shieldActive)
        {
            if (!DebugScript.Immortality)//葛西が勝手にデバッグ用に書き足しました
            {
                _PlayerHP -= damage;
                hpChange();
            }
        }
        else
        {
            ShieldImage.shieldActive = false;
        }
        if (_PlayerHP <= 0 && death == false)
        {
            //hpZero();
            //HpReset();
            death = true;
            MapManager.Instance.CallFadeIn(mapName);

        }
        return _PlayerHP;
    }
    public int Heal(int heal)
    {
        _PlayerHP += heal;
        hpChange();
        if (_PlayerHP >= _MaxHP)
        {
            _PlayerHP = _MaxHP;
        }
        return _PlayerHP;
    }
    //葛西が勝手にデバッグ用に書き足しました
    public void Kill()
    {
        _PlayerHP = 0;
        hpChange();
        if (_PlayerHP <= 0 && death == false)
        {
            //hpZero();
            //HpReset();
            death = true;
            MapManager.Instance.CallFadeIn(mapName);

        }
    }
    public void HpReset()
    {
        death = false;
        _PlayerHP = _MaxHP;
    }

}
