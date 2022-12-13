using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldImage : MonoBehaviour
{
    static public bool shieldActive = false;
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
    public void ShieleBroken()
    {
        this.gameObject.SetActive(false);
        SetShieldItem.usingShieldItem = false;
    }
}
