using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSerch : MonoBehaviour
{
    public bool noFloor = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            noFloor = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            noFloor = true;
        }
    }
}
