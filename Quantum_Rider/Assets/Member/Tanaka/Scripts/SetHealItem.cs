using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHealItem : MonoBehaviour
{

    void Start()
    {
        this.gameObject.SetActive(true);
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //触れたら非表示にする
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("HPを5回復");
            this.gameObject.SetActive(false);
        }
    }
}
