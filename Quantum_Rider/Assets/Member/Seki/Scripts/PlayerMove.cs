using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float hoverMaxX, hoverMaxY = 0, hoverPower = 1,beamActiveTime=0.5f;

    [SerializeField]
    GameObject rotationObjectRight, rotationObjectLeft, 
        beamRight,beamLeft, beamRightPos, beamLeftPos,beamParent;

    [SerializeField]
    GameObject[] targets,rightGun,leftGun;

    GameObject enemy;
    Quaternion _RotationPlayer,_RotationRight,_RotationLeft;
    
    float count,min,dis = 0;

    bool _Pressed = true;

    public bool moveFrag=true;
    public bool throughFrag = false;
    const int Power = 200;
    const float SerchRange = 6;

    Vector3 _Myvelocity, _HoverVec, _HoverDirection, _PlayerScreenPos,_distance;

    Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        targets = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Fade.isFade)
        {
            EnemySearch();
            Direction();
            BeamRotation();
            PlayerImageReturn();
            //Rounding();
            
            if (Input.GetMouseButton(0))
            {//左クリック
                if (_Pressed)
                {
                    MouseClick();
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {//
                _Pressed = true;
                //BeamActiveFalse();
            }
        }

        //VelocityApply();
        if (rb.velocity.y<-11)
        {
            rb.velocity = new Vector2(rb.velocity.x, -11);
            //this.gameObject.gameObject.GetComponent<Rigidbody2D>().velocity.y = -11;
        }
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity);
    }
    void MouseClick()
    {
        Semanager.instance.Play("Laser");
        _Pressed = false;
        Direction();
        BeamActive();
        Hover();
    }
    void EnemySearch()
    {//敵探索
        count += Time.deltaTime;
        
        if (count >= 1)
        {
            var enemyFrag = false;
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            count = 0;
            if(targets.Length==0)
            {
                enemy = null;
            }
            foreach (GameObject t in targets)
            {

                dis = Vector3.Distance
                (transform.position,
                t.gameObject.transform.position);
                if (dis <= SerchRange)
                {//サーチ範囲内なら
                    if (min == 0 || dis < min)
                    {//最初の敵もしくは一番近い敵
                        Debug.Log("ターゲットは"+ t);
                        enemyFrag = true;
                        enemy = t;
                        min = dis;//最小の距離を更新
                        

                    }
                }
                else
                {
                    /*
                    Debug.Log("ターゲットはなし");
                    min = 0;
                    enemy = null;
                    */
                }
                //Debug.Log("最小" + min);
                if (min > SerchRange)
                {
                    enemy = null;
                }
            }
            if(enemyFrag == false)
            {
                enemy=null;
                min = 0;
            }
            
        }
    }
    void PlayerImageReturn()
    {//プレイヤーの画像反転
        //Debug.Log(enemy);
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
        var RightBeam= Instantiate(beamRight, beamRightPos.transform.position, _RotationRight,beamParent.transform);
        var LeftBeam =Instantiate(beamLeft, beamLeftPos.transform.position, _RotationLeft,beamParent.transform);
        if(throughFrag)
        {
            RightBeam.GetComponent<BeamMove>().through = true;
            LeftBeam.GetComponent<BeamMove>().through = true;
            
        }
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
        rb.AddForce
        (_HoverDirection * hoverPower * Power);
        //Debug.Log(_HoverDirection * hoverPower * Power);
        VelocityApply();
        //Debug.Log(_Myvelocity.y);
        Rounding();
        //Debug.Log(_Myvelocity.y);
        
    }

    void Rounding()
    {
        //_Myvelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
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
        rb.velocity = _Myvelocity;

    }
    void VelocityApply()
    {
        _Myvelocity = rb.velocity;
    }
}