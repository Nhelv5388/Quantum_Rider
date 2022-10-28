using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource bgmAudioSource;

    public float BgmVolume
    {
        get
        {
            return bgmAudioSource.volume;
        }
        set
        {
            bgmAudioSource.volume = Mathf.Clamp01(value);
        }
    }
    
    void Start()
    {
        GameObject soundManager = CheckOtherSoundManager();
        bool checkResult = soundManager != null && soundManager != gameObject;
        if (checkResult)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    GameObject CheckOtherSoundManager()
    {
        return GameObject.FindGameObjectWithTag("SoundManager");
    }
    public void PlayBgm(AudioClip clip)
    {
        bgmAudioSource.clip = clip;
        if (clip == null)
        {
            return;
        }
        bgmAudioSource.Play();
    }
}