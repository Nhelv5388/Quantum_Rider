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
        //�G�ꂽ���\���ɂ���
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("HP��5��");
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //�G�ꂽ���\���ɂ���
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("HP��5��");
            this.gameObject.SetActive(false);
        }
    }
}
