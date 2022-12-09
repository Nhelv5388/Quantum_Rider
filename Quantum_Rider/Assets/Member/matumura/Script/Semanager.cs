using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Semanager : MonoBehaviour
{
    //Soundクラス配列
    [SerializeField]
    private Sound[] sounds;

    public static Semanager instance;

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


    public void Play(String name)
    {
        //
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        //あればPlay()
        s.audiosource.PlayOneShot(s.clip);
    }
}
