using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama45 : MonoBehaviour
{
    [SerializeField]
    private float WaitTime;
    [SerializeField]
    private float ShotSpeed;
    private float time;
    [SerializeField]
    private float ShotTime;


    void Start()
    {
        time = 0;
    }

    void Update()
    {
        Invoke(nameof(Shot), 2.0f);
        //transform.position += transform.right * Time.deltaTime * ShotSpeed;


        time += Time.deltaTime;

        if (time > ShotTime)
        {
            transform.position += transform.right * Time.deltaTime * ShotSpeed;
            ShotPrefab();
            time = 0;
        }

        //Destroy(this,gameObject,3f);

    }

    private void Shot()
    {
        transform.position += transform.right * Time.deltaTime * ShotSpeed;
    }


    IEnumerator ShotPrefab()
    {
        yield return new WaitForSeconds(WaitTime);

        Instantiate(this.gameObject, new Vector3(0, 0, 1), Quaternion.identity);
        transform.position += transform.right * Time.deltaTime * ShotSpeed;

        Debug.Log("aaa");
    }

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
