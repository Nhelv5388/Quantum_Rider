using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float hoverMaxX, hoverMaxY = 0, hoverPower = 1;
    [SerializeField]
    GameObject rotationObjectRight, rotationObjectLeft, beamRight,beamLeft;//マウスクリックに応じて角度が変わるオブジェクト
    GameObject[] targets;
    GameObject enemy;
    Quaternion _RotationPlayer,_RotationRight,_RotationLeft;
    
    float count = 0;

    bool _Pressed = true;
    const int _Power = 200;
    Vector3 _Myvelocity, _HoverVec, _HoverDirection, _PlayerScreenPos,_distance;

    // Start is called before the first frame update
    void Start()
    {
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
            BeamActiveFalse();
        }
    }
    void EnemySearch()
    {
        count += Time.deltaTime;
        if (count >= 1)
        {
            count = 0;
            var min = 0f ;
            var dis = 0f;
            foreach (GameObject t in targets)
            {
               
                dis = Vector3.Distance
                (transform.position,
                t.gameObject.transform.position);
                if (dis <= 6)
                {
                    if (min == 0 || dis < min)
                    {//最初の敵若しくは一番近い敵
                        enemy = t;
                        min = dis;//最小の距離を更新
                        Debug.Log(t);
                    }
                    else
                    {

                    }
                }
            }
            //Debug.Log(dis);

            if(dis>6)
            {
                enemy = null;
            }

        }
    }
    void PlayerImageReturn()
    {//プレイヤーの画像反転
        if(enemy!=null)
        {//敵いる
            //Debug.Log(enemy);
            _distance = _PlayerScreenPos-
                Camera.main.WorldToScreenPoint
                (enemy.transform.localPosition);
        }
        else
        {
            _distance = Input.mousePosition - _PlayerScreenPos;
        }
        
        if(_distance.x < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(_distance.x > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
        beamRight.SetActive(true);
        beamLeft.SetActive(true);
        BeamRotation();
        Invoke("BeamActiveFalse", 0.1f);
    }
    void BeamActiveFalse()
    {//ビーム非表示
        beamRight.SetActive(false);
        beamLeft.SetActive(false);
    }
    void Hover()
    {//浮く
        this.gameObject.GetComponent<Rigidbody2D>().AddForce
        (_HoverDirection * hoverPower * _Power);

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