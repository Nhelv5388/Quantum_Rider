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



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Tama")
        {

            Debug.Log("atata");
            Destroy(this.gameObject);

        }
    }

}
