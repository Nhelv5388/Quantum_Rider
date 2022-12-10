using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image _HPBar;
    private int _MaxHP, _NowHP = 0;
    const int HPBarLength = 10;
    public static UIManager instance = null;
    [SerializeField]
    private GameObject HPUI=null;
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

        if (HPUI == null)
        {
            GameObject.Find("HP");
        }
    }
    // Start is called before the first frame update
    void Start()
    {/*
        if(_HPBar==null)
        {
            _HPBar = GameObject.Find("HPBar").GetComponent<Image>();
        }*/
        _MaxHP = HPManager.instance.GetHP();
        HPManager.instance.hpChange += HPBarChange;
    }
    void HPBarChange()
    {
        /*
        if (_HPBar == null)
        {
            _HPBar = GameObject.Find("HPBar").GetComponent<Image>();
        }*/
        _NowHP = HPManager.instance.GetHP();
        if(_NowHP > _MaxHP)
        {
            _NowHP = _MaxHP;
        }
        var NowHPLegth = (int)(HPBarLength * ((float)_NowHP / _MaxHP));
        //HPUI.GetComponent<Hp>().Life = _NowHP;
        HPUI.GetComponent<HPUIKari>().HPHenkou(NowHPLegth);
        if(NowHPLegth<=0)
        {
            Destroy(HPUI.GetComponent<HPUIKari>());
        }
        /*
        _HPBar.transform.localScale=
            new Vector3((int)(HPBarLength*((float)_NowHP/_MaxHP)), 1, 1);
        */
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
