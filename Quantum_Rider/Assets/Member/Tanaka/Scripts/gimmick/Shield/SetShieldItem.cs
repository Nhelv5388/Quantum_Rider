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

    void Start()
    {
        shieldItemImage = transform .Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;
        this.gameObject.SetActive(true);
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
        if (!usedShieldItem)
        {
            //�G�ꂽ���\���ɂ���
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("�V�[���h�W�J");
                shieldItemImage.gameObject.SetActive(false);
                shieldImage.SetActive(true);
                playerPos = col.gameObject;
                activeSheild = true;
                usedShieldItem = true;
            }
        }
    }
}
