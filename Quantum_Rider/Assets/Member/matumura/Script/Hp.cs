using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    //���̃X�N���v�g�̓v���C���[�ɂ��Ē��������B�B
    //�\��t������Slider���X�N���v�g�Ƀh���b�O���܂��B

    public int hp = 10;//hp��10�ɂ���BSlider��MaxValue��Value�͂���ɍ��킹�܂�
    private Slider _slider;//Slider�̒l��������_slider��錾
    public GameObject slider;//�̗̓Q�[�W�Ɏw�肷��Slider

    // Use this for initialization
    void Start()
    {
        //_slider = slider.GetComponent();//slider���擾����
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = hp;//�X���C�_�[��HP�̕R�Â�
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")//������������̃^�O��Enemy�Ȃ�//hp��-1���ς���
        {
            hp -= 1;
        }

        if (hp <= 0)//����hp��0�ȉ��Ȃ�
        {
            print("GameOver");//GameOver�ƃR���\�[���ɕ\������
        }
    }
}