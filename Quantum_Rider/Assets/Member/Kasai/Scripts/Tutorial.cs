using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] wall;
    [SerializeField] private GameObject[] enemy;
    private int EnemyKillCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemy.Length <= 4)
        {
            wall[0].SetActive(false);
        }
        if (enemy.Length <= 1)
        {
            Debug.Log(2);
            wall[1].SetActive(false);
        }
        if (enemy.Length <= 0)
        {
            wall[2].SetActive(false);
        }

    }
}
