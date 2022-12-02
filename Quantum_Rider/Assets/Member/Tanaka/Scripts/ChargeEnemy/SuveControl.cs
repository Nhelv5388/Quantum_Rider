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
    public float direction = default;

    //�v���C���[�A���̗��[���v�Z
    private float floorRightEdge = default;
    private float floorLeftEdge = default;
    private float enemyRightEdge = default;
    private float enemyLeftEdge = default;
    private bool onFloor = false;
    private bool stopping = false;

    [SerializeField]
    private GameObject playerSerch;
    [SerializeField]
    private GameObject AttackArea;

    [Header("�ȉ��f�o�b�O�p\n(�s��)")]
    [SerializeField]
    private bool immortality = false;

    void Start()
    {
        //������
        suvePlayerSerch = GetComponentInChildren<SuvePlayerSerch>();
        direction = this.gameObject.transform.localRotation.y;
        playerSerch.transform.localPosition = new Vector3(4.0f, 1.0f, 0.0f);
        AttackArea.transform.localPosition = Vector3.zero;
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
        //�o�O�΍�
        if (stopping)
        {
            stopping = false;
        }
        //�󒆂œ����Ȃ��悤��
        if (onFloor)
        {
            FloorEdgeReturn();
        }
        //���ʂ悤�ɃA�^�b�`����RB�΍�
        playerSerch.transform.localPosition = new Vector3(4.0f,1.0f,0.0f);
        AttackArea.transform.localPosition = Vector3.zero;
    }

    private void PatrolEnemy()
    {
        if (!stopping)
        {
            //SerializeField�ő��삵�₷���悤��100�Ŋ���
            this.transform.Translate(PatrolSpeed / 100, 0, 0);
        }
        
    }
    private void ChargeEnemy()
    {
        if (!stopping)
        {
            //SerializeField�ő��삵�₷���悤��100�Ŋ���
            this.transform.Translate(ChargeSpeed / 100, 0, 0);
        }
        
    }
    private void FloorEdgeReturn()
    {
        //�v���C���[�̍��W�̗��[���v�Z
        enemyRightEdge = this.gameObject.transform.position.x + (this.gameObject.transform.localScale.x / 2);
        enemyLeftEdge = this.gameObject.transform.position.x - (this.gameObject.transform.localScale.x / 2);
        //�v���C���[�̒[�����̒[�𒴂�����߂�
        if (enemyRightEdge >= floorRightEdge)
        {
            this.transform.position = new Vector3(this.gameObject.transform.position.x - (enemyRightEdge - floorRightEdge),
                this.gameObject.transform.position.y,
                this.gameObject.transform.position.z);
            ReturnEnemy();
        }
        else if (enemyLeftEdge <= floorLeftEdge)
        {
            this.transform.position = new Vector3(this.gameObject.transform.position.x - (enemyLeftEdge - floorLeftEdge),
                this.gameObject.transform.position.y,
                this.gameObject.transform.position.z);
            ReturnEnemy();
        }
    }
    private void ReturnEnemy()
    {    
        //�E�ɐi��
        if (direction == 1)
        {
            direction = 0;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //���ɐi��
        else if (direction == 0)
        {
            direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    private void ChargeHit(Collision2D col)
    {
        if (!startCoolDown)
        {
            HPManager.instance.Damage(1);
            startCoolDown = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Floor")
        {
            onFloor = true;
            //���݂̏��̗��[���v�Z����
            floorRightEdge = col.gameObject.transform.position.x + (col.gameObject.transform.localScale.x / 2);
            floorLeftEdge = col.gameObject.transform.position.x - (col.gameObject.transform.localScale.x / 2);
        }
        if(col.gameObject.tag == "Wall")
        {
            ReturnEnemy();
        }
        if (col.gameObject.tag == "Enemy")
        {
            ReturnEnemy();
        }
        if (col.gameObject.tag == "Player")
        {
            ChargeHit(col);
        }
        
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        //�o�O�΍�
        if(col.gameObject.tag == "Enemy")
        {
            if(col.gameObject.transform.position.x <= this.gameObject.transform.position.x)
            {
                stopping = true;
            }
            if (!stopping)
            {
                ReturnEnemy();
            }
        }
    }
    private void OnCollisionExit2D(Collision col)
    {
        //�����n�_�ɏ����Ȃ��������痎���Ă��܂������p
        if(col.gameObject.tag == "Floor")
        {
            onFloor = false;
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
