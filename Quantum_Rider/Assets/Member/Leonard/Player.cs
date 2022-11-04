using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    ChangeScene change;
    private GameObject player;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Text");
        change.Change();
    }

    public void PlayerSetActive(bool setActive)
    {
        if (setActive)
        {
            player.SetActive(true);
        }
        else
        {
            player.SetActive(false);
        }
    }
}
