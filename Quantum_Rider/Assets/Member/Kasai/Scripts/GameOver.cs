using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public static MapManager.SceneID mapName;//�Q�[���I�[�o�[�ɂȂ����Ƃ���MapManager���璼�O�̃V�[������������Ă���
    public void Retry()
    {
        MapManager.Instance.CallFadeIn(mapName);//�t�F�[�h�����ƃV�[���J��
    }
}
