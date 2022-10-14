using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float hoverMaxX, hoverMaxY = 0, hoverPower = 1;
    [SerializeField]
    GameObject rotationObject,beamObject;//マウスクリックに応じて角度が変わるオブジェクト
    Quaternion _Rotation;

    bool _Pressed = true;
    const int _Power = 200;
    Vector3 _Myvelocity, _HoverVec, _HoverDirection, _PlayerScreenPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        BeamRotation();
        PlayerImageReturn();
        if (Input.GetMouseButton(0))
        {//左クリック
            if (_Pressed)
            {
                //Debug.Log("おされた");
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
    void PlayerImageReturn()
    {
        var vec = Input.mousePosition - _PlayerScreenPos;
        if (vec.x < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(vec.x>0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void Direction()
    {//進む方向決め
        _PlayerScreenPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        _Rotation = Quaternion.LookRotation
            (Vector3.forward, Input.mousePosition - _PlayerScreenPos);
        _HoverVec = _Rotation.eulerAngles;
        _HoverDirection = Quaternion.Euler(_HoverVec) * -Vector3.up;
        //Debug.Log(Input.mousePosition - pos);
    }
    void BeamRotation()
    {//ビーム方向
        rotationObject.transform.localRotation = _Rotation;
    }
    void BeamActive()
    {//ビーム表示
        beamObject.SetActive(true);
        BeamRotation();
        Invoke("BeamActiveFalse", 0.1f);
    }
    void BeamActiveFalse()
    {//ビーム非表示
        beamObject.SetActive(false);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        Debug.Log("ぬけ");
    }
}