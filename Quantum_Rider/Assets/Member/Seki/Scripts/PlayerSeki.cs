using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeki : MonoBehaviour
{

    [SerializeField]
    string _EnemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(_EnemyTag))
        {
            HPManager.instance.Damage(1);
        }
    }


}
