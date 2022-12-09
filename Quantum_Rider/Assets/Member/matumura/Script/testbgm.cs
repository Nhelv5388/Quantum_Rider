using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testbgm : MonoBehaviour
{


    public static testbgm instance;

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
    //ƒVƒ“ƒOƒ‹ƒgƒ“İ’è‚±‚±‚Ü‚Å

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
