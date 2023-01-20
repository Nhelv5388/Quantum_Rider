using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShieldItem : MonoBehaviour
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

    private GameObject brokenEffect;
    private ParticleSystem brokenPar;

    //���̃A�C�e�����g��ꂽ��
    private bool usedShieldItem = false;
    //���ݎg���Ă��邩
    static public bool usingShieldItem = false;

    //GameObject seManager;
    //Semanager se = null;

    void Start()
    {
        shieldItemImage = transform .Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;

        //
        brokenEffect = transform.Find("BrokenEffect").gameObject;
        if(brokenEffect != null)
        {
            brokenPar = brokenEffect.GetComponent<ParticleSystem>();
        }

        this.gameObject.SetActive(true);

        usedShieldItem = false;
        usingShieldItem = false;
        //(�e�X�g�p�̖��O�̂��ߌ�ŕύX�\��)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();
    }

    void Update()
    {

        if (usingShieldItem == true)
        {
            shieldImage.transform.position = playerPos.transform.localPosition;
            brokenEffect.transform.position = playerPos.transform.localPosition;
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
                if (brokenPar != null) brokenPar.Play();
                Debug.Log("<color=green>BarrierLost</color>");
            }
        }

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
