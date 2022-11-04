using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTile : MonoBehaviour
{
    float _count = 0;
    [SerializeField]
    float coolTime = 0f;

    bool onPlayer=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _count += Time.deltaTime;
        if (_count > coolTime)
        {//coolTimeïbÇ≤Ç∆ÇÃèàóù
            _count = 0;
            if(onPlayer)
            {
                HPManager.instance.Damage(1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            _count = 0;
            onPlayer = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            _count = 0;
            onPlayer = false;
        }
            
    }
}
