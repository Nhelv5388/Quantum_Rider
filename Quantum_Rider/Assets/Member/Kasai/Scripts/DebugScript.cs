using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public int damage;
    private bool debugMode=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            debugMode = true;
        }
        if(Input.GetKeyUp(KeyCode.Space)&&debugMode)
        {
            HPManager.instance.Damage(damage);
        }
        if(Input.GetKeyDown(KeyCode.Tab)&&debugMode)
        {
            HPManager.instance.Heal(10);
        }
        
    }
}
