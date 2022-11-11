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
    private bool RetrunNow = false;
    public float direction = default;

    //プレイヤー、床の両端を計算
    private float floorRightEdge = default;
    private float floorLeftEdge = default;
    private float enemyRightEdge = default;
    private float enemyLeftEdge = default;

    [SerializeField]
    private GameObject playerSerch;
    [SerializeField]
    private GameObject AttackArea;

    [Header("以下デバッグ用(不死)")]
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

        //プレイヤーの座標の両端を計算
        enemyRightEdge = this.gameObject.transform.position.x + (this.gameObject.transform.localScale.x / 2);
        enemyLeftEdge = this.gameObject.transform.position.x - (this.gameObject.transform.localScale.x / 2);
        //プレイヤーの端が床の端を超えたら戻る
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
        //SerializeFieldで操作しやすいように100で割る
        this.transform.Translate(PatrolSpeed/100, 0, 0);
        
    }
    private void ChargeEnemy()
    {
        //SerializeFieldで操作しやすいように100で割る
        this.transform.Translate(ChargeSpeed/100, 0, 0);
        
    }

    private void ReturnEnemy()
    {
        //右に進む
        if (direction == 1)
        {
            direction = 0;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            RetrunNow = false;
        }
        //左に進む
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
            Debug.Log("衝突ダメージ");
            startCoolDown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            //現在の床の両端を計算する
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
