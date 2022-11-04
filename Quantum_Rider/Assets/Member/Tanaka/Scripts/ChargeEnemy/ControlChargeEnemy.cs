using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChargeEnemy : MonoBehaviour
{
    AreaSerchPlayer areaSerchPlayer;
    FloorSerch floorSerch;

    //巡回、突撃それぞれの速度
    [SerializeField]
    private float PatrolSpeed = default;
    [SerializeField]
    private float ChargeSpeed = default;

    //ダメージを与えた後のクールタイム
    [SerializeField]
    private float attackCoolDown = 3.0f;

    private bool startCoolDown = false;

    private float nowTime = 0;

    //進行方向
    private int direction = 1;
    private bool RetrunNow = false;

    [SerializeField]
    public Collision2D detectionFloor;

    void Start()
    {
        areaSerchPlayer = GetComponentInChildren<AreaSerchPlayer>();
        floorSerch = GetComponentInChildren<FloorSerch>();
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
            ReturnEnemy();
        }
    }

    //巡回中(プレイヤー未発見時)
    private void MovePatrol()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x + PatrolSpeed * direction, this.transform.localPosition.y);
    }
    //突撃中(プレイヤー発見時)
    private void MoveCharge()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x + ChargeSpeed * direction, this.transform.localPosition.y);
    }

    //転回
    private void ReturnEnemy()
    {
        //右に進む
        if (RetrunNow)
        {
            direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            RetrunNow = false;
        }
        //左に進む
        else if (!RetrunNow)
        {
            direction = -1;
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
        if(col.gameObject.tag == "Wall")
        {
            ReturnEnemy();
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
