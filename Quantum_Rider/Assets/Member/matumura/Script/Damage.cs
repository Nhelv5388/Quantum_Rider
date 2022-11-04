using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー(動かす機体専用)
public class Damage : MonoBehaviour
{
    public GameObject hpbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObjectがモブで、それに当たった時にダメージを受ける判定
        if(collision.gameObject.tag == "enemy")
        {
            hpbar.gameObject.SendMessage("onDamage", 10);
        }
    }

}
