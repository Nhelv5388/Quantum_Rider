using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    int playerHP=10;
    int playerMaxHP = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMaxHP = playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public int GetHP()
    {
        return playerHP;
    }
    public int GetMaxHP()
    {
        return playerMaxHP;
    }
    */
}
