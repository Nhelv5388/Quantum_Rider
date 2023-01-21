using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beforeShieldSpere : MonoBehaviour
{
    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float nowTime = 0.0f;

    //�V�[���h�̃A�C�e���摜
    private GameObject shieldItemImage;
    //�v���C���[�ɕt��������V�[���h�摜
    private GameObject shieldImage;
    //�v���C���[�̉摜
    private GameObject playerPos;

    //���̃A�C�e�����g��ꂽ��
    private bool usedShieldItem = false;
    //���ݎg���Ă��邩
    static public bool usingShieldItem = false;

    void Start()
    {
        shieldItemImage = transform.Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;

        this.gameObject.SetActive(true);

        usedShieldItem = false;
        usingShieldItem = false;
    }

    void Update()
    {

        if (usingShieldItem == true && playerPos != null)
        {
            shieldImage.transform.position = playerPos.transform.localPosition;
        }
        if (usingShieldItem == true)
        {
            nowTime += Time.deltaTime;
            //���ʐ؂�
            if (nowTime >= activeTime)
            {
                usingShieldItem = false;
                shieldImage.SetActive(false);
                usingShieldItem = false;
                nowTime = 0.0f;
                Semanager.instance.Play("BarrierLost");
                Debug.Log("<color=green>BarrierLost</color>");
            }
        }

        //�o�O�΍�
        if (!usingShieldItem)
        {
            usingShieldItem = false;
            shieldImage.SetActive(false);
            usingShieldItem = false;
            nowTime = 0.0f;
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

                usingShieldItem = true;
                Semanager.instance.Play("Barrier");
                //SE�Đ�
                //se.Play("6");

                shieldItemImage.gameObject.SetActive(false);
                shieldImage.SetActive(true);
                playerPos = col.gameObject;
                usedShieldItem = true;

            }
        }
    }
}
