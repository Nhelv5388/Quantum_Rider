using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDamageFloor : MonoBehaviour
{
    private float nowTime = 0.0f;
    [SerializeField]
    private float damageCoolTime = 1.0f;

    private bool startCol = false;
    private bool endCol = false;

    void Start()
    {

    }


    void Update()
    {
        if (startCol)
        {
            nowTime += Time.deltaTime;
            //1�b�ȏ�_���[�W���ɐG��Ă�����1�_���[�W
            if (nowTime >= damageCoolTime)
            {
                nowTime = 0.0f;
                Debug.Log("�t�B�[���h�_���[�W");
            }
            if (endCol)
            {
                startCol = false;
                endCol = false;
                nowTime = 0.0f;
            }
        }

        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startCol = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endCol = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endCol = true;
        }
    }
}
