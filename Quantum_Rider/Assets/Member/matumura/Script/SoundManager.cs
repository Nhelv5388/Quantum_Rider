using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
    //Sound�N���X�z��
    [SerializeField]
    private Sound[] sounds;

    public static SoundManager instance;

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
    public void Play(string name,bool flag)
    {
        //
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            //print("Sound" + name + "was not found");
            
            Debug.Log("���̉����͂Ȃ���");
            //s.audiosource.Stop();
            return;
            
        }
        if (flag)
        {
            //�����Play()
            s.audiosource.Play();
        }
        else
        {
            s.audiosource.Stop();
        }
    }
    //public void Stop()
    //{

    //}
}