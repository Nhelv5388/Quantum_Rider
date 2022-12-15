using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
    //Soundクラス配列
    [SerializeField]
    private Sound[] sounds;

    public static SoundManager instance;

    private void Awake()
    {
        //AudioManagerインスタンスがなければ生成する
        //存在すればDestroy,return
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


        //Soundクラスに入れたデータをAudioSourceに当てはめる
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
            
            Debug.Log("その音源はないよ");
            //s.audiosource.Stop();
            return;
            
        }     
        //あればPlay()
        s.audiosource.Play();
    }
    //public void Stop()
    //{

    //}
}