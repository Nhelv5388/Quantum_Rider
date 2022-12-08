using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{

    public GameObject a;//a～jがhpでいう1～10です
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;

    int Life = 10;

       
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ダメージ判定見つけられなかったんで、テストでスペース押したら減る(非表示)ようにしてます。
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Life -= 1;
            Debug.Log(Life);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Life += 1;
            Debug.Log(Life);
        }

        if (Life == 10)
        {
            a.SetActive(true);
        }

        if(Life == 9)
        {
            a.SetActive(false);
            b.SetActive(true);
            
        }

        if (Life == 8)
        {
            b.SetActive(false);
            c.SetActive(true);

        }

        if (Life == 7)
        {
            c.SetActive(false);
            d.SetActive(true);

        }

        if (Life == 6)
        {
            d.SetActive(false);
            e.SetActive(true);

        }

        if (Life == 5)
        {
            e.SetActive(false);
            f.SetActive(true);

        }

        if (Life == 4)
        {
            f.SetActive(false);
            g.SetActive(true);

        }

        if (Life == 3)
        {
            g.SetActive(false);
            h.SetActive(true);

        }

        if (Life == 2)
        {
            h.SetActive(false);
            i.SetActive(true);

        }

        if (Life == 1)
        {
            i.SetActive(false);
            
        }

        if (Life == 0)
        {
            j.SetActive(false);

        }
    }

}