using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //private bool EnemyFlag;


    private void Start()
    {
        //EnemyFlag = true;
    }

    private void Update()
    {
        //EnemyHP();
    }

    /*private void EnemyHP()
    {
        if(EnemyFlag == false)
        {
            Destroy(this.gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Tama")
        {

            Debug.Log("atata");
            Destroy(this.gameObject);

        }
    }

}
