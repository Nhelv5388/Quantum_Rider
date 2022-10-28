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
    private float attackCoolDown = 3.0f;

    private bool startCoolDown = false;

    private float nowTime = 0;

    //�i�s����
    private int direction = 1;

    [SerializeField]
    public Collision2D detectionFloor;

    void Start()
    {
        areaSerchPlayer = GetComponentInChildren<AreaSerchPlayer>();
        floorSerch = GetComponentInChildren<FloorSerch>();
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

        if (floorSerch.noFloor)
        {
            ReturnEnemy(detectionFloor);
        }
    }

    //����(�v���C���[��������)
    private void MovePatrol()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x + PatrolSpeed * direction, this.transform.localPosition.y);
    }
    //�ˌ���(�v���C���[������)
    private void MoveCharge()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x + ChargeSpeed * direction, this.transform.localPosition.y);
    }

    private void ReturnEnemy(Collision2D col)
    {
        //���ɕ�
        if (col.gameObject.transform.localPosition.x <= this.transform.localPosition.x)
        {
            direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (col.gameObject.transform.localPosition.x >= this.transform.localPosition.x)
        {
            direction = -1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    private void ChargeHit(Collision2D col)
    {
        if (!startCoolDown)
        {
            Debug.Log("�Փ˃_���[�W");
            startCoolDown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            ReturnEnemy(col);
        }
        if(col.gameObject.tag == "Player")
        {
            ChargeHit(col);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PlayerAttack")
        {
            this.gameObject.SetActive(false);
        }
    }
}
