using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    //このスクリプトはプレイヤーにつけて頂きたい。。
    //貼り付けたらSliderをスクリプトにドラッグします。

    public int hp = 10;//hpを10にする。SliderのMaxValueとValueはこれに合わせます
    private Slider _slider;//Sliderの値を代入する_sliderを宣言
    public GameObject slider;//体力ゲージに指定するSlider

    // Use this for initialization
    void Start()
    {
        //_slider = slider.GetComponent();//sliderを取得する
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = hp;//スライダーとHPの紐づけ
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")//当たった相手のタグがEnemyなら//hpを-1ずつ変える
        {
            hp -= 1;
        }

        if (hp <= 0)//もしhpが0以下なら
        {
            print("GameOver");//GameOverとコンソールに表示する
        }
    }
}