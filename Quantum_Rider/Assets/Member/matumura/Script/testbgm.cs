using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class testbgm : MonoBehaviour
{
    //Sound�N���X�z��
    [SerializeField]
    private Sound[] sounds;

    public static testbgm instance;

    private void Awake()
    {
        //AudioManager�C���X�^���X���Ȃ���ΐ�������
        //���݂����Destroy,return
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        //Sound�N���X�ɓ��ꂽ�f�[�^��AudioSource�ɓ��Ă͂߂�
        foreach (Sound s in sounds)
        {
            s.audiosource = gameObject.AddComponent<AudioSource>();
            s.audiosource.clip = s.clip;
            s.audiosource.volume = s.volume;
        }
    }

}