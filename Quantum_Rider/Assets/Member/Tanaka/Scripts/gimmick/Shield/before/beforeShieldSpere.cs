using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beforeShieldSpere : MonoBehaviour
{
    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float nowTime = 0.0f;

    //シールドのアイテム画像
    private GameObject shieldItemImage;
    //プレイヤーに付属させるシールド画像
    private GameObject shieldImage;
    //プレイヤーの画像
    private GameObject playerPos;

    //このアイテムが使われたか
    private bool usedShieldItem = false;
    //現在使われているか
    static public bool usingShieldItem = false;

    void Start()
    {
        shieldItemImage = transform.Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;

        this.gameObject.SetActive(true);

        usedShieldItem = false;
        usingShieldItem = false;
    }

    void Update()
    {

        if (usingShieldItem == true && playerPos != null)
        {
            shieldImage.transform.position = playerPos.transform.localPosition;
        }
        if (usingShieldItem == true)
        {
            nowTime += Time.deltaTime;
            //効果切れ
            if (nowTime >= activeTime)
            {
                usingShieldItem = false;
                shieldImage.SetActive(false);
                usingShieldItem = false;
                nowTime = 0.0f;
                Semanager.instance.Play("BarrierLost");
                Debug.Log("<color=green>BarrierLost</color>");
            }
        }

        //バグ対策
        if (!usingShieldItem)
        {
            usingShieldItem = false;
            shieldImage.SetActive(false);
            usingShieldItem = false;
            nowTime = 0.0f;
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

                usingShieldItem = true;
                Semanager.instance.Play("Barrier");
                //SE再生
                //se.Play("6");

                shieldItemImage.gameObject.SetActive(false);
                shieldImage.SetActive(true);
                playerPos = col.gameObject;
                usedShieldItem = true;

            }
        }
    }
}
