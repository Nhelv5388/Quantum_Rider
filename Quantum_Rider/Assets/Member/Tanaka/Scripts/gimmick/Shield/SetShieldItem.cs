using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShieldItem : MonoBehaviour
{
    //�V�[���h�̃A�C�e���摜
    private GameObject shieldItemImage;
    //�v���C���[�ɕt��������V�[���h�摜
    private GameObject shieldImage;
    //�v���C���[�̉摜
    private GameObject playerPos;

    private bool activeSheild = false;
    private bool usedShieldItem = false;
    static public bool usingShieldItem = false;

    //GameObject seManager;
    //Semanager se = null;

    void Start()
    {
        shieldItemImage = transform .Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;
        this.gameObject.SetActive(true);

        usedShieldItem = false;
        usingShieldItem = false;
        //(�e�X�g�p�̖��O�̂��ߌ�ŕύX�\��)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();
    }

    void Update()
    {
        if (activeSheild)
        {
            shieldImage.transform.position = playerPos.transform.localPosition;
        }
        else
        {
            shieldImage.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!usedShieldItem && !usingShieldItem)
        {
            //�G�ꂽ���\���ɂ���
            if (col.gameObject.tag == "Player")
            {
                //Debug.Log("�V�[���h�W�J");

                ShieldImage.shieldActive = true;
                Semanager.instance.Play("Barrier");
                //SE�Đ�
                //se.Play("6");

                shieldItemImage.gameObject.SetActive(false);
                shieldImage.SetActive(true);
                playerPos = col.gameObject;
                activeSheild = true;
                usedShieldItem = true;
                usingShieldItem = true;
                
            }
        }
    }
}
