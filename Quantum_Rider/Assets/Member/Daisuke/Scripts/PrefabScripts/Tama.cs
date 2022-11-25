using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    [SerializeField]
    private float WaitTime;
    [SerializeField]
    private float ShotSpeed;
    private float TIME;

    // Å‰‚ÌˆÊ’u
    private Vector3 initialPos;


    void Start()
    {
        // ‰ŠúˆÊ’uî•ñ‚ÌŽæ“¾
        initialPos = transform.position;
    }

    void Update()
    {
        ShotPrefab();

        TIME += Time.deltaTime;

        if (TIME > 5)
        {
            transform.position += transform.right * Time.deltaTime * ShotSpeed;
            //ShotPrefab();
            TIME = 0;
        }
        
        //transform.position += transform.right * Time.deltaTime;
        //Destroy(this,gameObject,3f);

        
    }

    
    IEnumerator ShotPrefab()
    {
        yield return new WaitForSeconds(WaitTime);
        transform.position += transform.right * Time.deltaTime * ShotSpeed;

        Debug.Log("aaa");
    }



    private void Reset()
    {
        if(Time.deltaTime < 5)
        {
            transform.position = initialPos;
        }


    }

    
}
