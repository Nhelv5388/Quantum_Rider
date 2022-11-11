using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuvePlayerSerch : MonoBehaviour
{
    //プレイヤーが範囲内に入ったか?
    public bool foundPlayer = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            foundPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            foundPlayer = false;
        }
    }
}
