using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uku : MonoBehaviour
{
    [SerializeField]
    float hoverMaxX,hoverMaxY = 0,hoverPower=1;
    [SerializeField]
    GameObject rotationObject;//�}�E�X�N���b�N�ɉ����Ċp�x���ς��I�u�W�F�N�g
    Quaternion _Rotation;

    bool _Pressed = true;
    const int _Power = 200;
    Vector3 _Myvelocity,_HoverVec, _HoverDirection;
        
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {//���N���b�N
            if (_Pressed)
            {
                Debug.Log("�����ꂽ");
                _Pressed = false;
                Direction();
                BeamActive();
                Hover();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {//��������r�[����\��
            _Pressed=true;
            rotationObject.SetActive(false); 
        }
    }
    
    void Direction()
    {
        //�i�ޕ�������
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        _Rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        _HoverVec = _Rotation.eulerAngles;
        _HoverDirection = Quaternion.Euler(_HoverVec) * -Vector3.up;
    }
    void BeamActive()
    {
        //�r�[���\���A�r�[������
        rotationObject.SetActive(true);
        rotationObject.transform.localRotation = _Rotation;
    }
    private void Hover()
    {//����
        this.gameObject.GetComponent<Rigidbody2D>().AddForce
        (_HoverDirection * hoverPower * _Power);
        
        VelocityApply();

        if (_Myvelocity.x>hoverMaxX)
        {
            _Myvelocity.x = hoverMaxX;
        }
        else if(_Myvelocity.x<-hoverMaxX)
        {
            _Myvelocity.x = -hoverMaxX;
        }
        if(_Myvelocity.y > hoverMaxY)
        {
            _Myvelocity.y = hoverMaxY;
        }
        else if (_Myvelocity.y < -hoverMaxY)
        {
            _Myvelocity.y = -hoverMaxY;
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity = _Myvelocity;
    }
    void  VelocityApply()
    {
        _Myvelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
    }
}
