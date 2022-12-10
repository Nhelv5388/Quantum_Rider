using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChargeEnemy : MonoBehaviour
{
    AreaSerchPlayer areaSerchPlayer;
    FloorSerch floorSerch;

    //����A�ˌ����ꂼ��̑��x
    [SerializeField]
    private float PatrolSpeed = default;
    [SerializeField]
    private float ChargeSpeed = default;

    //�_���[�W��^������̃N�[���^�C��
    [SerializeField]
    private float attackCoolDown = 1.0f;

    private bool startCoolDown = false;
    private float nowTime = 0;

    //�i�s����
    private bool RightDirection = true;
    private bool returnNow = false;
    

    [SerializeField]
    private GameObject detectionFloor;
    private Vector3 dStartPos = new Vector3(0.5f, -0.45f, 0f);
    [SerializeField]
    private GameObject playerSerch;
    private Vector3 pStartPos = new Vector3(4.0f, 1.0f, 0.0f);

    [Header("�ȉ��f�o�b�O�p\n(�s��)")]
    [SerializeField]
    private bool immortality = false;
    [Header("(��~)")]
    [SerializeField]
    private bool stopping = false;
    void Start()
    {
        if(this.gameObject.transform.localRotation == Quaternion.Euler(0f, 0f, 0f))
        {
            RightDirection = true;
        }
        else
        {
            RightDirection = false;
        }

        areaSerchPlayer = GetComponentInChildren<AreaSerchPlayer>();
        floorSerch = GetComponentInChildren<FloorSerch>();
        
        playerSerch.transform.localPosition = dStartPos;
        detectionFloor.transform.localPosition = pStartPos;
        
    }


    void Update()
    {
        //�U���̃N�[���^�C�����͈ړ����x��ω������Ȃ�
        if (startCoolDown)
        {
            nowTime += Time.deltaTime;
            if (nowTime >= attackCoolDown)
            {
                startCoolDown = false;
                nowTime = 0;
            }
            MovePatrol();
        }
        else
        {
            if (areaSerchPlayer.foundPlayer)
            {
                MoveCharge();
            }
            else
            {
                MovePatrol();
            }
        }
        if (floorSerch.noFloor || returnNow)
        {
            StartCoroutine(ReturnEnemy());
        }
        //���ʂ悤�ɃA�^�b�`����RB�΍�
        detectionFloor.transform.localPosition = dStartPos;
        playerSerch.transform.localPosition = pStartPos;
        
    }

    //����(�v���C���[��������)
    private void MovePatrol()
    {
        if (!stopping)
        {
            //SerializeField�ő��삵�₷���悤��100�Ŋ���
            this.transform.Translate(PatrolSpeed / 100, 0, 0);
        }

    }
    private void MoveCharge()
    {
        if (!stopping)
        {
            //SerializeField�ő��삵�₷���悤��100�Ŋ���
            this.transform.Translate(ChargeSpeed / 100, 0, 0);
        }

    }
    //�]��
    IEnumerator ReturnEnemy()
    {
        returnNow = false;
        //�E�ɐi��
        if (RightDirection)
        {
            RightDirection = false;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        //���ɐi��
        else if (!RightDirection)
        {
            RightDirection = true;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        yield return new WaitForSeconds(1);
    }
    
    private void ChargeHit()
    {
        if (!startCoolDown)
        {
            //Debug.Log("�Փ˃_���[�W");
            HPManager.instance.Damage(1);
            Semanager.instance.Play("Explosion");//�g�p����se�͂��ƂŊm�F���܂�
            startCoolDown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log(this.gameObject.name);
            returnNow = true;
        }
        if (col.gameObject.tag == "Enemy")
        {
            returnNow = true;
        }
        if (col.gameObject.tag == "Player")
        {
            ChargeHit();
        }

    }
    private void OnCollisionStay2D(Collision2D col)
    {
        //�o�O�΍�
        if (col.gameObject.tag == "Enemy")
        {
            if(col.gameObject.transform.localRotation == Quaternion.Euler(0f, 0f, 0f))
            {
                if(this.gameObject.transform.localRotation == Quaternion.Euler(0f, -180f, 0f))
                {
                    returnNow = true;
                }
            }
            else
            {
                returnNow = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //�v���C���[�̍U���Ŏ��S
        if (!immortality)
        {
            if (col.gameObject.tag == "PlayerAttack")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
