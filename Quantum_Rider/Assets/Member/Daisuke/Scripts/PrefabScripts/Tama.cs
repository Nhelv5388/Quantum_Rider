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

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            HPManager.instance.Damage(1);
        }


    }

}
