using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testtest : MonoBehaviour
{
    public GameObject aaa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(aaa);
        }
    }
}