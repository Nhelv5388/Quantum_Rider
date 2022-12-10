using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHealItem : MonoBehaviour
{
    private GameObject healImage;
    private bool usedHeal = false;

    //GameObject seManager;
    //Semanager se = null;
    void Start()
    {
        this.gameObject.SetActive(true);
        healImage = transform.Find("HealImage").gameObject;


        //(テスト用の名前のため後で変更予定)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //触れたら非表示にする
        if (col.gameObject.tag == "Player")
        {
            if (!usedHeal)
            {
                usedHeal = true;

                //SE再生
                //se.Play("1");

                healImage.gameObject.SetActive(false);

                //Debug.Log("HPを5回復");
                Semanager.instance.Play("Heal");
                HPManager.instance.Heal(5);
                //HPManager.instance.HpReset();
            }
        }
    }
}
