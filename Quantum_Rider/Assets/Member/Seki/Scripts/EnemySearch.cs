using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    float count = 0;

    public delegate void OneSecond();
    public OneSecond one;
    //OneSecond one;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 1) 
        {
            count = 0;  
            if(true)
            {
                one();
            }
        }
    }
}
