using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float _BulletSpeed=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*_BulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if(collision.gameObject.CompareTag("Wall")||collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            HPManager.instance.Damage(1);
        }


    }
}
