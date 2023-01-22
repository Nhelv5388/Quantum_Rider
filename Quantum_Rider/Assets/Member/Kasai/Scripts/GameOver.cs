using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static MapManager.SceneID mapName;//マップ移動に必要だからコメントアウトしないで
    public void Retry()
    {
        Debug.Log(mapName);
        MapManager.Instance.CallFadeIn(mapName);
    }
}
