using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static MapManager.SceneID mapName;//�}�b�v�ړ��ɕK�v������R�����g�A�E�g���Ȃ���
    public void Retry()
    {
        Debug.Log(mapName);
        MapManager.Instance.CallFadeIn(mapName);
    }
}
