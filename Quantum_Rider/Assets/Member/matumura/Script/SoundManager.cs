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
        }
    }
    public void Play(string name,bool flag)
    {
        //
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            //print("Sound" + name + "was not found");
            
            Debug.Log("その音源はないよ");
            //s.audiosource.Stop();
            return;
            
        }
        if (flag)
        {
            //あればPlay()
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