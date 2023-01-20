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
    static public bool usingShieldItem = false;

    //GameObject seManager;
    //Semanager se = null;

    void Start()
    {
        shieldItemImage = transform .Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;
        this.gameObject.SetActive(true);

        usedShieldItem = false;
        usingShieldItem = false;
        //(テスト用の名前のため後で変更予定)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();
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
        if (!usedShieldItem && !usingShieldItem)
        {
            //触れたら非表示にする
            if (col.gameObject.tag == "Player")
            {
                //Debug.Log("シールド展開");

                ShieldImage.shieldActive = true;
                Semanager.instance.Play("Barrier");
                //SE再生
                //se.Play("6");

                shieldItemImage.gameObject.SetActive(false);
                shieldImage.SetActive(true);
                playerPos = col.gameObject;
                activeSheild = true;
                usedShieldItem = true;
                usingShieldItem = true;
                
            }
        }
    }
}
