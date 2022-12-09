using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Semanager : MonoBehaviour
{
    //Sound�N���X�z��
    [SerializeField]
    private Sound[] sounds;

    public static Semanager instance;

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


    public void Play(String name)
    {
        //
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        //�����Play()
        s.audiosource.PlayOneShot(s.clip);
    }
}
