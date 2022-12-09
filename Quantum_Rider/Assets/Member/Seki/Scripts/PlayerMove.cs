using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float hoverMaxX, hoverMaxY = 0, hoverPower = 1,beamActiveTime=0.5f;

    [SerializeField]
    GameObject rotationObjectRight, rotationObjectLeft, 
        beamRight,beamLeft, beamRightPos, beamLeftPos;

    [SerializeField]
    GameObject[] targets,rightGun,leftGun;

    GameObject enemy;
    Quaternion _RotationPlayer,_RotationRight,_RotationLeft;
    
    float count,min,dis = 0;

    bool _Pressed = true;

    public bool moveFrag=true;

    const int Power = 200;
    const float SerchRange = 6;

    Vector3 _Myvelocity, _HoverVec, _HoverDirection, _PlayerScreenPos,_distance;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
        targets = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        EnemySearch();
        Direction();
        BeamRotation();
        PlayerImageReturn();
        if (Input.GetMouseButton(0))
        {//左クリック
            if (_Pressed)
            {
                _Pressed = false;
                Direction();
                BeamActive();
                Hover();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {//離したらビーム非表示
            _Pressed = true;
            //BeamActiveFalse();
        }
    }
    void EnemySearch()
    {
        count += Time.deltaTime;
        
        if (count >= 1)
        {
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            count = 0;
            
            foreach (GameObject t in targets)
            {
                //Debug.Log(t);

                //Debug.Log(t.gameObject.transform.position);
                dis = Vector3.Distance
                (transform.position,
                t.gameObject.transform.position);
                if (dis <= SerchRange)
                {//サーチ範囲内なら
                 //
                 /*
                    Debug.Log("敵近いよ");
                    Debug.Log("最小"+min);
                    Debug.Log("距離"+dis);*/
                    
                    if (min == 0 || dis < min)
                    {//最初の敵もしくは一番近い敵
                        Debug.Log("ターゲットは"+ t);
                        
                        enemy = t;
                        min = dis;//最小の距離を更新
                        

                    }
                }
                else
                {
                    min = 0;
                    enemy = null;
                }
            }
            if(dis>SerchRange)
            {
                
                //enemy = null;
            }
        }
    }
    void PlayerImageReturn()
    {//プレイヤーの画像反転
        Debug.Log(enemy);
        if(enemy!=null)
        {//敵いる
            //Debug.Log(enemy);
            _distance = _PlayerScreenPos-
                Camera.main.WorldToScreenPoint
                (enemy.transform.position);
        }
        else
        {
            _distance = Input.mousePosition - _PlayerScreenPos;
        }
        
        if(_distance.x < 0)
        {
            //Debug.Log("右向き");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            FlipFalse();
        }
        else if(_distance.x > 0)
        {
            //Debug.Log("左向き");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            FlipTrue();
        }
    }

    void FlipTrue()
    {//銃のレイヤー変え
        foreach(var t in rightGun)
        {
            if (t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder >=7)
            {
                t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder -= 4;
            }
                
        }
        foreach (var t in leftGun)
        {
            if(t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder <= 5)
            {
                t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder += 4;
            }
            
        }
    }

    void FlipFalse()
    {//銃のレイヤー変え
        foreach (var t in rightGun)
        {
            if (t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder <= 5)
            {
                t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder += 4;
            }
        }
        foreach (var t in leftGun)
        {
            if (t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder >= 7)
            {
                t.gameObject.
                GetComponent<SpriteRenderer>().sortingOrder -= 4;
            }
        }
    }
    void Direction()
    {//進む方向決め
        _PlayerScreenPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rightPos = Camera.main.WorldToScreenPoint(rotationObjectRight.transform.position);
        var leftPos = Camera.main.WorldToScreenPoint(rotationObjectLeft.transform.position);
        _RotationPlayer = Quaternion.LookRotation
            (Vector3.forward, Input.mousePosition - _PlayerScreenPos);
        _RotationRight = Quaternion.LookRotation
            (Vector3.forward, Input.mousePosition - rightPos);
        _RotationLeft = Quaternion.LookRotation
            (Vector3.forward, Input.mousePosition - leftPos);
        _HoverVec = _RotationPlayer.eulerAngles;
        _HoverDirection = Quaternion.Euler(_HoverVec) * -Vector3.up;
    }
    void BeamRotation()
    {//ビーム方向
        rotationObjectRight.transform.localRotation = _RotationRight;
        rotationObjectLeft.transform.localRotation = _RotationLeft;
    }
    void BeamActive()
    {//ビーム表示
        Instantiate(beamRight, beamRightPos.transform.position, _RotationRight);
        Instantiate(beamLeft, beamLeftPos.transform.position, _RotationLeft);
        /*:beamRight.SetActive(true);
        beamLeft.SetActive(true);*/
        BeamRotation();
        //Invoke("BeamActiveFalse", beamActiveTime);
    }
    void BeamActiveFalse()
    {//ビーム非表示
        beamRight.SetActive(false);
        beamLeft.SetActive(false);
    }
    void Hover()
    {//浮く
        this.gameObject.GetComponent<Rigidbody2D>().AddForce
        (_HoverDirection * hoverPower * Power);

        VelocityApply();

        if (_Myvelocity.x > hoverMaxX)
        {
            _Myvelocity.x = hoverMaxX;
        }
        else if (_Myvelocity.x < -hoverMaxX)
        {
            _Myvelocity.x = -hoverMaxX;
        }

        if (_Myvelocity.y > hoverMaxY)
        {
            _Myvelocity.y = hoverMaxY;
        }
        else if (_Myvelocity.y < -hoverMaxY)
        {
            _Myvelocity.y = -hoverMaxY;
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity = _Myvelocity;
    }
    void VelocityApply()
    {
        _Myvelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
    }
}