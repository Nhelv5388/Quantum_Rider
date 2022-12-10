using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDamageFloor : MonoBehaviour
{
    private float nowTime = 0.0f;
    [SerializeField]
    private float damageCoolTime = 1.0f;

    private bool startCol = false;
    private bool endCol = false;

    //GameObject seManager;
    //Semanager se = null;

    void Start()
    {
        //(テスト用の名前のため後で変更予定)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();
    }


    void Update()
    {
        if (startCol)
        {
            nowTime += Time.deltaTime;
            //1秒以上ダメージ床に触れていたら1ダメージ
            if (nowTime >= damageCoolTime)
            {
                nowTime = 0.0f;
                HPManager.instance.Damage(1);
                //Debug.Log("フィールドダメージ");
                Semanager.instance.Play("Damaged");
                //SE再生
                //se.Play("4");
            }
            if (endCol)
            {
                startCol = false;
                endCol = false;
                nowTime = 0.0f;
            }
        }

        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startCol = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endCol = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endCol = true;
        }
    }
}
