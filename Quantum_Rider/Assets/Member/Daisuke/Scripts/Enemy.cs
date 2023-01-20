using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            Semanager.instance.Play("Explosion");
            this.gameObject.SetActive(false);
        }
    }

}
