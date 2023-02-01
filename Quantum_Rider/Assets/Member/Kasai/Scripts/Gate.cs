using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private MapManager.SceneID mapName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!Fade.isFade)
        {
            MapManager.Instance.CallFadeIn(mapName);//�}�b�v�}�l�[�W���[����t�F�[�h�����ƃ}�b�v�ړ��������Ă�
        }
    }
}
