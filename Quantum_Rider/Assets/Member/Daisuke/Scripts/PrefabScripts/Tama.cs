using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    /*
    [SerializeField]
    private float WaitTime;
    
    private float time;
    [SerializeField]
    private float ShotTime;
    */
    [SerializeField]
    private float ShotSpeed;


    void Start()
    {
        //time = 0;
    }

    void Update()
    {        

        transform.position += transform.right * Time.deltaTime * ShotSpeed;

        /*
        time += Time.deltaTime;

        if (time > ShotTime)
        {
            ShotPrefab();
            time = 0;
        }
        */
        //Destroy(this,gameObject,3f);
        
    }

    /*
    private void ShotPrefab()
    {
        //yield return new WaitForSeconds(WaitTime);

        Instantiate(this.gameObject, new Vector3(0, 0, 1), Quaternion.identity);
        transform.position += transform.right * Time.deltaTime * ShotSpeed;

        Debug.Log("aaa");
    }
    */
   /*private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject)
        {

            Debug.Log("atata");
            Destroy(this.gameObject);

        }
    }
   */

    
}
