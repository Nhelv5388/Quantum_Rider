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
        if(_HPBar==null)
        {
            _HPBar = GameObject.Find("HPBar").GetComponent<Image>();
        }
        _MaxHP = HPManager.instance.GetHP();
        HPManager.instance.hpChange += HPBarChange;
    }
    void HPBarChange()
    {
        _NowHP = HPManager.instance.GetHP();
        //Debug.Log(_NowHP);
        //Debug.Log(_MaxHP);
        //float a = _NowHP / _MaxHP;
        Debug.Log(HPBarLength * (float)_NowHP/_MaxHP);
        _HPBar.transform.localScale=new Vector3((int)(HPBarLength*((float)_NowHP/_MaxHP)), 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
