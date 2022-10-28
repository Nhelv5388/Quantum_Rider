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
        //G‚ê‚½‚ç”ñ•\¦‚É‚·‚é
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("HP‚ğ5‰ñ•œ");
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //G‚ê‚½‚ç”ñ•\¦‚É‚·‚é
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("HP‚ğ5‰ñ•œ");
            this.gameObject.SetActive(false);
        }
    }
}
