using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShieldItem : MonoBehaviour
{
    //シールドのアイテム画像
    private GameObject shieldItemImage;
    //プレイヤーに付属させるシールド画像
    private GameObject shieldImage;
    //プレイヤーの画像
    private GameObject playerPos;

    private bool activeSheild = false;
    private bool usedShieldItem = false;

    void Start()
    {
        shieldItemImage = transform .Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;
        this.gameObject.SetActive(true);
    }

    void Update()
    {
        if (activeSheild)
        {
            shieldImage.transform.position = playerPos.transform.localPosition;
        }
        else
        {
            shieldImage.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!usedShieldItem)
        {
            //触れたら非表示にする
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("シールド展開");
                shieldItemImage.gameObject.SetActive(false);
                shieldImage.SetActive(true);
                playerPos = col.gameObject;
                activeSheild = true;
                usedShieldItem = true;
            }
        }
    }
}
