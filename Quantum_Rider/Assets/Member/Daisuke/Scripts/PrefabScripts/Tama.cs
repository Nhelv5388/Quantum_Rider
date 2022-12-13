using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{

    [SerializeField]
    private float ShotSpeed;
    [SerializeField]private float _bulletTimer = 3.0f;//íeÇ™è¡ñ≈Ç∑ÇÈÇ‹Ç≈ÇÃéûä‘


    void Start()
    {
        //time = 0;
    }

    void Update()
    {        
        transform.position += transform.right * Time.deltaTime * ShotSpeed;
        Destroy(this.gameObject, _bulletTimer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("DamageFloor"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            HPManager.instance.Damage(1);
            Semanager.instance.Play("Explosion");
        }


    }

}
