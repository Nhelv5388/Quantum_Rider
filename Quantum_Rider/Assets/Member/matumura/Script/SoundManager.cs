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
            s.audiosource.loop=true;
        }
    }
    public void Play(string name)
    {
        //
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Sound audio1=Array.Find(sounds, sound => sound.name == "Title");
        Sound audio2=Array.Find(sounds, sound => sound.name == "MainGame");
        Sound audio3=Array.Find(sounds, sound => sound.name == "GameClear");
        Sound audio4=Array.Find(sounds, sound => sound.name == "GameOver");
        audio1.audiosource.Stop();
        audio2.audiosource.Stop();
        audio3.audiosource.Stop();
        audio4.audiosource.Stop();
        if (s == null)
        {
            //print("Sound" + name + "was not found");
            
            Debug.Log("���̉����͂Ȃ���");
            //s.audiosource.Stop();
            return;
            
        }     
        //�����Play()
        s.audiosource.Play();
    }
    //public void Stop()
    //{

    //}
}