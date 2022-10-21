using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{

    SpriteRenderer sp;
    float a = 0;
    // Start is called before the first frame update
    void Start()
    {
        sp= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(a<1)
        {
            sp.color = new Color(1, 1, 1, a);
        }else
        {
            a = 0;
        }
        a+=Time.deltaTime;
        
    }
}
