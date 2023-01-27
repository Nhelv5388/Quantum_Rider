using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParDamageFloor : MonoBehaviour
{
    private float nowTime = 0.0f;
    [SerializeField]
    private float damageCoolTime = 1.0f;

    private bool startCol = false;
    private bool endCol = false;

    [SerializeField] private GameObject LaserPar;
     //private ParticleSystem par;

    void Start()
    {
        LaserPar.SetActive(false);
        //LaserPar = transform.GetChild(0).gameObject;
        //par = LaserPar.GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if (startCol)
        {
            nowTime += Time.deltaTime;
            //1秒以上ダメージ床に触れていたら1ダメージ
            if (nowTime >= damageCoolTime)
            {
                nowTime = 0.0f;
                HPManager.instance.Damage(1);
                Semanager.instance.Play("Damaged");
                //par.Play();
                //Debug.Log("Damage");
            }
            if (endCol)
            {
                startCol = false;
                endCol = false;
                nowTime = 0.0f;
            }
        }


    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            HPManager.instance.Damage(1);
            Semanager.instance.Play("Damaged");
            LaserPar.transform.position= col.transform.position;
            LaserPar.SetActive(true);

            //par.Play();
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startCol = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endCol = true;
        }
    }
}
