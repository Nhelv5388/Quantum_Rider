using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float WaitTime;
    private bool EnemyFlag = true;
    [SerializeField]
    private float ShotDamage;

    private void Update()
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
        if (EnemyFlag == true)
        {
            //GameObject bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            //Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); 
            //bulletRigidbody.AddForce();

            Destroy(BulletPrefab, 5.0f);  
        }

        yield return new WaitForSeconds(WaitTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tama")
        {
            EnemyFlag = false;
            Destroy(this.gameObject);
        }
    }
}
