using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public MapManager.SceneID mapName;//マップ移動に必要だからコメントアウトしないで
    public void Retry()
    { 
        MapManager.Instance.CallFadeIn(mapName);
    }
}
