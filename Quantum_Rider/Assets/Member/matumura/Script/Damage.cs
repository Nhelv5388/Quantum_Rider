using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[(�������@�̐�p)
public class Damage : MonoBehaviour
{
    public GameObject hpbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject�����u�ŁA����ɓ����������Ƀ_���[�W���󂯂锻��
        if(collision.gameObject.tag == "enemy")
        {
            hpbar.gameObject.SendMessage("onDamage", 10);
        }
    }

}
