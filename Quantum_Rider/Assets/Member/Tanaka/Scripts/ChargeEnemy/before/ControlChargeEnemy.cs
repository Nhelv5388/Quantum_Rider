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
    private float attackCoolDown = 1.0f;

    private bool startCoolDown = false;
    private float nowTime = 0;

    //進行方向
    private bool RightDirection = true;
    private bool returnNow = false;
    

    [SerializeField]
    private GameObject detectionFloor;
    private Vector3 dStartPos = new Vector3(0.5f, -0.45f, 0f);
    [SerializeField]
    private GameObject playerSerch;
    private Vector3 pStartPos = new Vector3(4.0f, 1.0f, 0.0f);

    [Header("以下デバッグ用\n(不死)")]
    [SerializeField]
    private bool immortality = false;
    [Header("(停止)")]
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
        if (floorSerch.noFloor || returnNow)
        {
            StartCoroutine(ReturnEnemy());
        }
        //判別ようにアタッチしたRB対策
        detectionFloor.transform.localPosition = dStartPos;
        playerSerch.transform.localPosition = pStartPos;
        
    }

    //巡回中(プレイヤー未発見時)
    private void MovePatrol()
    {
        if (!stopping)
        {
            //SerializeFieldで操作しやすいように100で割る
            this.transform.Translate(PatrolSpeed / 100, 0, 0);
        }

    }
    private void MoveCharge()
    {
        if (!stopping)
        {
            //SerializeFieldで操作しやすいように100で割る
            this.transform.Translate(ChargeSpeed / 100, 0, 0);
        }

    }
    //転回
    IEnumerator ReturnEnemy()
    {
        returnNow = false;
        //右に進む
        if (RightDirection)
        {
            RightDirection = false;
            this.gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        //左に進む
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
            //Debug.Log("衝突ダメージ");
            HPManager.instance.Damage(1);
            Semanager.instance.Play("Explosion");//使用するseはあとで確認します
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
        //バグ対策
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
