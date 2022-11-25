using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamegeFloor : MonoBehaviour
{
    [Header("左側コーンを設定")]
    [SerializeField]
    private GameObject DamageFloorCone = default;

    [Header("対になるコーンを設定")]
    [SerializeField]
    GameObject anotherDamegeFloorCone = default;

    private bool anotherConeSerch = false;

    [SerializeField]
    private float damageCoolTime = 0.0f;

    private float nowTime = 0.0f;

    [SerializeField]
    private float FloorDamage = 1.0f;

    private Vector2 playerPosition = default;

    void Start()
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        var linePositions = new Vector3[]
        {
            new Vector3(DamageFloorCone.transform.localPosition.x+0.5f,DamageFloorCone.transform.localPosition.y,0),
            new Vector3(anotherDamegeFloorCone.transform.localPosition.x-0.5f,anotherDamegeFloorCone.transform.localPosition.y,0),
        };
        renderer.startWidth = 0.5f;
        renderer.endWidth = 0.5f;
        renderer.material = new Material(Shader.Find("Sprites/Default"));
        renderer.startColor = new Color(0,255,0,255);
        renderer.endColor = new Color(0,255,0,255);
        renderer.SetPositions(linePositions);
    }


    void Update()
    {

        //対になっているコーンを探す
        if (anotherDamegeFloorCone != null)
        {
            anotherConeSerch = true;
        }
        else
        {
            Debug.Log("<color=red>対応しているコーンが見つかりません</color>");
        }
        //見つからなかった場合何も実行しない
        if(anotherConeSerch == true)
        {
            //プレイヤーの座標を探す
            playerPosition = GameObject.FindWithTag("Player").transform.position;

            //コーンの座標間に入っていると1秒ごとにダメージを与える
            if (playerPosition.x >= DamageFloorCone.transform.localPosition.x &&
               playerPosition.x <= anotherDamegeFloorCone.transform.localPosition.x &&
               playerPosition.y >= DamageFloorCone.transform.localPosition.y &&
               playerPosition.y <= anotherDamegeFloorCone.transform.localPosition.y)
            {
                nowTime += Time.deltaTime;
                //1秒以上ダメージ床に触れていたら1ダメージ
                if (nowTime >= damageCoolTime)
                {
                    nowTime = 0.0f;
                    StartCoroutine(DamageFloorCT());
                }
            }
        }
    }

    IEnumerator DamageFloorCT()
    {
        Debug.Log("ダメージを"+FloorDamage+"受けました");
        //プレイヤーのHPを1減少させる

        yield return null;
    }
}
