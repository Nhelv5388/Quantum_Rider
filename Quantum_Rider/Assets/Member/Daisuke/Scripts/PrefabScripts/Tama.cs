using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    //[SerializeField]
    //private float WaitTime;

    // �ŏ��̈ʒu
    private Vector3 initialPos;


    void Start()
    {
        // �����ʒu���̎擾
        initialPos = transform.position;
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime;
        //Destroy(this,gameObject,3f);


    }

    /*
    IEnumerator ShotPrefab1()
    {
        transform.position += transform.right * Time.deltaTime * 2;
        yield return new WaitForSeconds(WaitTime);

    }

    IEnumerator ShotPrefab2()
    {
        transform.position += transform.right * Time.deltaTime * 2;
        yield return new WaitForSeconds(WaitTime);

    }
    */

    private void Reset()
    {
        if(Time.deltaTime < 5)
        {
            transform.position = initialPos;
        }


    }

    
}
