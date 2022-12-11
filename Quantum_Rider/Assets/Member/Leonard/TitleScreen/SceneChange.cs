using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private MapManager.SceneID mapName;
    public void MoveToScene()
    {
        //Debug.Log("MoveToScene");
        MapManager.Instance.CallFadeIn(mapName);
    }
}
