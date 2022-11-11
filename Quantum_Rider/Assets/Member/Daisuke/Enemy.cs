using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float WaitTime;
    private bool EnemyFlag = false;
    [SerializeField]
    private float ShotDamage;

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if(EnemyFlag == true)
        {
            ShotPrefab();
        }
    }

    IEnumerator ShotPrefab()
    {


        yield return new WaitForSeconds(WaitTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tama")
        {
            EnemyFlag = false;
            Destroy(this.gameObject);

        }
    }

}
