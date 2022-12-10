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


        //(�e�X�g�p�̖��O�̂��ߌ�ŕύX�\��)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //�G�ꂽ���\���ɂ���
        if (col.gameObject.tag == "Player")
        {
            if (!usedHeal)
            {
                usedHeal = true;

                //SE�Đ�
                //se.Play("1");

                healImage.gameObject.SetActive(false);

                //Debug.Log("HP��5��");
                Semanager.instance.Play("Heal");
                HPManager.instance.Heal(5);
                //HPManager.instance.HpReset();
            }
        }
    }
}
