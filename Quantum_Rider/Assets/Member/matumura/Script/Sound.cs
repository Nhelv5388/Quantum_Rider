using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    [Tooltip("サウンドの名前")]
    public string name;
    [Tooltip("サウンドの音源")]
    public AudioClip clip;
    [Tooltip("サウンドのボリュームを、0.0から1.0まで")]
    [SerializeField, Range(0.0f, 1.0f)]
    public float volume;
    //AudioSource,Inspectorに表示させないようにしています。
    [HideInInspector]
    public AudioSource audiosource;
}
