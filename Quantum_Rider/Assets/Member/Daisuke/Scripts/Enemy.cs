using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float WaitTime;
    private bool EnemyFlag;


    private void Start()
    {
        EnemyFlag = true;
    }

    private void Update()
    {
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

    /*
    IEnumerator ShotPrefab()
    {
        GameObject bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.identity);//������ւ��ς���
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); //�ł��o���e�ɂ��Ă̏���
        bulletRigidbody.AddForce(10,0,0);�@//�e���w�肵�������ւƂ΂�
        Debug.Log(this.transform);

        yield return new WaitForSeconds(WaitTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tama")
        {
            EnemyFlag = false;
            Destroy(this.gameObject);

        }
    }*/

}
