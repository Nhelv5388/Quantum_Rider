using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShieldItem : MonoBehaviour
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

    private GameObject brokenEffect;
    private ParticleSystem brokenPar;

    //このアイテムが使われたか
    private bool usedShieldItem = false;
    //現在使われているか
    static public bool usingShieldItem = false;

    //GameObject seManager;
    //Semanager se = null;

    void Start()
    {
        shieldItemImage = transform .Find("ShieldItemImage").gameObject;
        shieldImage = transform.Find("ShieldImage").gameObject;

        //
        brokenEffect = transform.Find("BrokenEffect").gameObject;
        if(brokenEffect != null)
        {
            brokenPar = brokenEffect.GetComponent<ParticleSystem>();
        }

        this.gameObject.SetActive(true);

        usedShieldItem = false;
        usingShieldItem = false;
        //(テスト用の名前のため後で変更予定)
        //seManager = GameObject.Find("SEManager");
        //se = seManager.GetComponent<Semanager>();
    }

    void Update()
    {

        if (usingShieldItem == true)
        {
            shieldImage.transform.position = playerPos.transform.localPosition;
            brokenEffect.transform.position = playerPos.transform.localPosition;
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
                if (brokenPar != null) brokenPar.Play();
                Debug.Log("<color=green>BarrierLost</color>");
            }
        }

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
