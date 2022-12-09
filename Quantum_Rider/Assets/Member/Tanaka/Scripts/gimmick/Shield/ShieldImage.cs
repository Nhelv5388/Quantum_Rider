using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldImage : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnemyAttack" || col.gameObject.tag == "DamageFloor")
        {
            HPManager.instance.Heal(1);
            this.gameObject.SetActive(false);
            SetShieldItem.usingShieldItem = false;
        }
    }
}
