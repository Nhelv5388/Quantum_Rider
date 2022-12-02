using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private MapManager.SceneID mapName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //MapManager.Instance.SceneChange(mapName);
            MapManager.Instance.CallFadeIn(mapName);
        }
    }
}
