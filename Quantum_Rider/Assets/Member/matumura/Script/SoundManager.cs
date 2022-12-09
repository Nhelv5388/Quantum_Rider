using UnityEngine;
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
}