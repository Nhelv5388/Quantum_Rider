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
    private void OnBecameInvisible()//�J�������ɃI�u�W�F�N�g�����邩�̔���
    {
        isCamera = false;
        Debug.Log("�J�����O");
    }
    private void OnBecameVisible()
    {
        isCamera=true;
        Debug.Log("�J������");
    }
}
