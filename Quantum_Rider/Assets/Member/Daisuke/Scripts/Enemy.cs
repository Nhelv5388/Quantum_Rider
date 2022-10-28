using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float WaitTime;
    private bool EnemyFlag;
    [SerializeField]
    private float ShotDamage;

    private void Start()
    {
        EnemyFlag = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ShotPrefab();
        }
        /*if (EnemyFlag == true)
        {
            ShotPrefab();
        }*/
        EnemyHP();
    }

    private void EnemyHP()
    {
        if(EnemyFlag == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShotPrefab()
    {
        GameObject bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); //打ち出す弾についての処理
        bulletRigidbody.AddForce(10,0,0);　//弾を指定した方向へとばす
        Debug.Log(this.transform);

        yield return new WaitForSeconds(WaitTime);
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tama")
        {
            EnemyFlag = false;
            Destroy(this.gameObject);

        }
    }*/

}
