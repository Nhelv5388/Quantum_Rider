using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldImage : MonoBehaviour
{
    static public bool shieldActive = false;
    
    /*�������p
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnemyAttack" || col.gameObject.tag == "DamageFloor")
        {
            //HPManager.instance.Heal(1);
        }
    }*/
    
    public void ShieleBroken()
    {
        this.gameObject.SetActive(false);
        SetShieldItem.usingShieldItem = false;
    }
    
}
