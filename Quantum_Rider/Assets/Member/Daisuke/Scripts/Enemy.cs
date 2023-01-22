using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void Destroy()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            //Debug.Log("a");
            Semanager.instance.Play("Explosion");
            Instantiate(bomb,this.transform.position,Quaternion.identity);
            this.gameObject.SetActive(false);
            
        }


    }

}
