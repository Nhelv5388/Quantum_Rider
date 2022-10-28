using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    [Tooltip("�T�E���h�̖��O")]
    public string name;
    [Tooltip("�T�E���h�̉���")]
    public AudioClip clip;
    [Tooltip("�T�E���h�̃{�����[�����A0.0����1.0�܂�")]
    public float volume;
    //AudioSource,Inspector�ɕ\�������Ȃ��悤�ɂ��Ă��܂��B
    [HideInInspector]
    public AudioSource audiosource;
}
