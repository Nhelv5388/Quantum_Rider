using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    //public float MoveSpeed = 20.0f;         // 移動値
    //public float time = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 位置の更新
        //transform.Translate(0.03f, 0, 0);
        transform.position += Vector3.right * Time.deltaTime;
        //transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        //Destroy(this.gameObject, time);
    }

}
