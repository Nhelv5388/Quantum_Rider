using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawn = new Vector3(0,0,0);

    private void Start()
    {
        Instantiate(prefab, spawn, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("Done");
        }
    }
}
