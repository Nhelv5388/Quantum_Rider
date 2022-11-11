using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuveControl : MonoBehaviour
{
    SuvePlayerSerch suvePlayerSerch;

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
    private bool RetrunNow = false;
    public float direction = default;

    //�v���C���[�A���̗��[���v�Z
    private float floorRightEdge = default;
    private float floorLeftEdge = default;
    private float enemyRightEdge = default;
    private float enemyLeftEdge = default;

    [SerializeField]
    private GameObject playerSerch;
    [SerializeField]
    private GameObject AttackArea;

    [Header("�ȉ��f�o�b�O�p(�s��)")]
    [SerializeField]
    private bool immortality = false;


    void Start()
    {
        suvePlayerSerch = GetComponentInChildren<SuvePlayerSerch>();
        direction = this.gameObject.transform.localRotation.y;
        playerSerch.transform.localPosition = new Vector3(4.0f, 1.0f, 0.0f);
        AttackArea.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
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
            PatrolEnemy();
        }
        else
        {
            if (suvePlayerSerch.foundPlayer)
            {
                ChargeEnemy();
            }
            else
            {
                PatrolEnemy();
            }
        }

        //�v���C���[�̍��W�̗��[���v�Z
        enemyRightEdge = this.gameObject.transform.position.x + (this.gameObject.transform.localScale.x / 2);
        enemyLeftEdge = this.gameObject.transform.position.x - (this.gameObject.transform.localScale.x / 2);
        //�v���C���[�̒[�����̒[�𒴂�����߂�
        if (enemyRightEdge >= floorRightEdge)
        {
            ReturnEnemy();
        }
        else if (enemyLeftEdge <= floorLeftEdge)
        {
            ReturnEnemy();
        }

        playerSerch.transform.localPosition = new Vector3(4.0f,1.0f,0.0f);
        AttackArea.transform.localPosition = Vector3.zero;
    }

    private void PatrolEnemy()
    {
        //SerializeField�ő��삵�₷���悤��100�Ŋ���
        this.transform.Translate(PatrolSpeed/100, 0, 0);
        
    }
    private void ChargeEnemy()
    {
        //SerializeField�ő��삵�₷���悤��100�Ŋ���
        this.transform.Translate(ChargeSpeed/100, 0, 0);
        
    }

    private void ReturnEnemy()
    {
        //�E�ɐi��
        if (direction == 1)
        {
            direction = 0;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            RetrunNow = false;
        }
        //���ɐi��
        else if (direction == 0)
        {
            direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            RetrunNow = true;
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
        if(col.gameObject.tag == "Floor")
        {
            //���݂̏��̗��[���v�Z����
            floorRightEdge = col.gameObject.transform.position.x + (col.gameObject.transform.localScale.x / 2);
            floorLeftEdge = col.gameObject.transform.position.x - (col.gameObject.transform.localScale.x / 2);
        }
        if(col.gameObject.tag == "Wall")
        {
            ReturnEnemy();
        }
        if (col.gameObject.tag == "Player")
        {
            ChargeHit(col);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!immortality)
        {
            if (col.gameObject.tag == "PlayerAttack")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
