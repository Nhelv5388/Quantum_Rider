using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossEnemy : MonoBehaviour
{

    float _count = 0;

    [SerializeField]
    float coolTime = 0f;
    [SerializeField]
    GameObject crossBullet;
    bool _CrossFrag = true;

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
            if(_CrossFrag)
            {
                Instantiate(crossBullet,transform.position,Quaternion.Euler(0,0,0));
            }
            else
            {
                Instantiate(crossBullet, transform.position, Quaternion.Euler(0, 0, 45));
            }
            _CrossFrag ^= true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerAttack"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
