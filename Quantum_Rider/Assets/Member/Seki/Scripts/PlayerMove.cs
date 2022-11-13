using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float hoverMaxX, hoverMaxY = 0, hoverPower = 1,beamActiveTime=0.5f;

    [SerializeField,Header("�}�E�X�N���b�N�ɉ����Ċp�x���ς��I�u�W�F�N�g")]
    GameObject rotationObjectRight, rotationObjectLeft, beamRight,beamLeft;

    [SerializeField]
    GameObject[] targets,rightGun,leftGun;

    GameObject enemy;
    Quaternion _RotationPlayer,_RotationRight,_RotationLeft;
    
    float count = 0;

    bool _Pressed = true;

    const int Power = 200;
    const float SerchRange = 6;

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
        {//���N���b�N
            if (_Pressed)
            {
                _Pressed = false;
                Direction();
                BeamActive();
                Hover();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {//��������r�[����\��
            _Pressed = true;
            //BeamActiveFalse();
        }
    }
    void EnemySearch()
    {
        count += Time.deltaTime;
        if (count >= 1)
        {
            count = 0;
            var min = 0f;
            var dis = 0f;
            foreach (GameObject t in targets)
            {
               
                dis = Vector3.Distance
                (transform.position,
                t.gameObject.transform.position);
                if (dis <= SerchRange)
                {
                    if (min == 0 || dis < min)
                    {//�ŏ��̓G�������͈�ԋ߂��G
                        enemy = t;
                        min = dis;//�ŏ��̋������X�V
                        //Debug.Log(dis);
                    }
                }
            }
            if(dis>SerchRange)
            {
                enemy = null;
            }
        }
    }
    void PlayerImageReturn()
    {//�v���C���[�̉摜���]
        if(enemy!=null)
        {//�G����
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
            //Debug.Log("�E����");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            FlipFalse();
        }
        else if(_distance.x > 0)
        {
            //Debug.Log("������");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            FlipTrue();
        }
    }

    void FlipTrue()
    {//�e�̃��C���[�ς�
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
    {//�e�̃��C���[�ς�
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
    {//�i�ޕ�������
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
    {//�r�[������
        rotationObjectRight.transform.localRotation = _RotationRight;
        rotationObjectLeft.transform.localRotation = _RotationLeft;
    }
    void BeamActive()
    {//�r�[���\��
        beamRight.SetActive(true);
        beamLeft.SetActive(true);
        BeamRotation();
        Invoke("BeamActiveFalse", beamActiveTime);
    }
    void BeamActiveFalse()
    {//�r�[����\��
        beamRight.SetActive(false);
        beamLeft.SetActive(false);
    }
    void Hover()
    {//����
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