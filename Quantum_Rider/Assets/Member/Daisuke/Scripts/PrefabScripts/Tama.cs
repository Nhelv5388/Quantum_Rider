using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{

    [SerializeField]
    private float ShotSpeed;


    void Start()
    {
        //time = 0;
    }

    void Update()
    {        
        transform.position += transform.right * Time.deltaTime * ShotSpeed;
        Destroy(this.gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject)
        {

            Debug.Log("atata");
            Destroy(this.gameObject);

        }
    }

}
