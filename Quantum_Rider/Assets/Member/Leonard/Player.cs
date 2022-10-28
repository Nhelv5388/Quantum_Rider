using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ChangeScene change;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Text");
        change.Change();

    }
}
