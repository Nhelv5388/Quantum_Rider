using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama45 : MonoBehaviour
{
    [SerializeField]
    private float ShotSpeed;


    void Start()
    {
        //time = 0;
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * ShotSpeed;

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
