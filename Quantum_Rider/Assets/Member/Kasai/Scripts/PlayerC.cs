using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public GameObject BulletObj;
    [SerializeField]
    public float WaitTime;
    Vector3 bulletPoint;


    // Start is called before the first frame update
    void Start()
    {
        bulletPoint = transform.Find("Tama").localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {

        ShotPrefab();
    }

    IEnumerator ShotPrefab()
    {
        Instantiate(BulletObj, bulletPoint, Quaternion.identity);
        Debug.Log("at");
        yield return new WaitForSeconds(WaitTime);
    }
}
