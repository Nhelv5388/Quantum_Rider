using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePing : MonoBehaviour
{
    private bool isCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()//カメラ内にオブジェクトがあるかの判定
    {
        isCamera = false;
        Debug.Log("カメラ外");
    }
    private void OnBecameVisible()
    {
        isCamera=true;
        Debug.Log("カメラ内");
    }
}
