using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTama : MonoBehaviour
{
    /*
    [SerializeField]
    private float ShotSpeed;
    */
    [SerializeField]
    private GameObject Tama;
    [SerializeField]
    private float Shot;
    /*
    [SerializeField]
    private int ;
    */

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ShotPrefab), 1.5f, Shot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShotPrefab()
    {
        //yield return new WaitForSeconds(WaitTime);

        Instantiate(Tama, new Vector3(0, 0, 1), Quaternion.identity);
        //transform.position += transform.right * Time.deltaTime * ShotSpeed;

        //Debug.Log("aaa");
    }

}
