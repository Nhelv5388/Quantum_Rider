using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseBgm : MonoBehaviour
{

    [SerializeField] AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stop()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // �ꎞ��~
            audiosource.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // �ĊJ
            audiosource.UnPause();
        }
    }
}
