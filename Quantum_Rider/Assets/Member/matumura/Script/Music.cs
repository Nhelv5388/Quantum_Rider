using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource[] BGM_Sources = new AudioSource[1];

    void Awake()
    {
        BGM_Sources[0] = gameObject.AddComponent<AudioSource>();
        BGM_Sources[1] = gameObject.AddComponent<AudioSource>();
    }


        /// BGMêâ~
        public void MuteBGM()
    {
        BGM_Sources[0].Stop();
        BGM_Sources[1].Stop();
    }

    
    /// êâ~µ½¯¶BGMðÄ¶
    public void ResumeBGM()
    {
        BGM_Sources[0].Play();
        BGM_Sources[1].Play();
    }

}
