using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuveControl : MonoBehaviour
{
    SuvePlayerSerch suvePlayerSerch;

    //巡回、突撃それぞれの速度
    [SerializeField]
    private float PatrolSpeed = default;
    [SerializeField]
    private float ChargeSpeed = default;

    //ダメージを与えた後のクールタイム
    [SerializeField]
    private float attackCoolDown = 1.0f;

    private bool startCoolDown = false;

    private float nowTime = 0;

    //進行方向
    public float direction = default;

    //プレイヤー、床の両端を計算
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

    [Header("以下デバッグ用\n(不死)")]
    [SerializeField]
    private bool immortality = false;

    void Start()
    {
        //初期化
        suvePlayerSerch = GetComponentInChildren<SuvePlayerSerch>();
        direction = this.gameObject.transform.localRotation.y;
        playerSerch.transform.localPosition = new Vector3(4.0f, 1.0f, 0.0f);
        AttackArea.transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        //攻撃のクールタイム中は移動速度を変化させない
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
        //バグ対策
        if (stopping)
        {
            stopping = false;
        }
        //空中で動かないように
        if (onFloor)
        {
            FloorEdgeReturn();
        }
        //判別ようにアタッチしたRB対策
        playerSerch.transform.localPosition = new Vector3(4.0f,1.0f,0.0f);
        AttackArea.transform.localPosition = Vector3.zero;
    }

    private void PatrolEnemy()
    {
        if (!stopping)
        {
            //SerializeFieldで操作しやすいように100で割る
            this.transform.Translate(PatrolSpeed / 100, 0, 0);
        }
        
    }
    private void ChargeEnemy()
    {
        if (!stopping)
        {
            //SerializeFieldで操作しやすいように100で割る
            this.transform.Translate(ChargeSpeed / 100, 0, 0);
        }
        
    }
    private void FloorEdgeReturn()
    {
        //プレイヤーの座標の両端を計算
        enemyRightEdge = this.gameObject.transform.position.x + (this.gameObject.transform.localScale.x / 2);
        enemyLeftEdge = this.gameObject.transform.position.x - (this.gameObject.transform.localScale.x / 2);
        //プレイヤーの端が床の端を超えたら戻る
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
        //右に進む
        if (direction == 1)
        {
            direction = 0;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //左に進む
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
            //現在の床の両端を計算する
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
        //バグ対策
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
        //初期地点に床がない＆床から落ちてしまった時用
        if(col.gameObject.tag == "Floor")
        {
            onFloor = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //プレイヤーの攻撃で死亡
        if (!immortality)
        {
            if (col.gameObject.tag == "PlayerAttack")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
