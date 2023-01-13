using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abbbc : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;//多分使わない
    [SerializeField]
    private float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FadeTest.GetFadeImage();//タイトルでボタンが押せない問題を修正のため
                            Debug.Log(FadeTest._fadeImage);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.I))
        //{
        //    StartCoroutine(FadeTest.IEFadeIn(fadeTime));
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    StartCoroutine(FadeTest.IEFadeOut(fadeTime));
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    FadeTest.FadeChange(fadeTime);
        //}

        ////新しいほうはこっち
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    StartCoroutine(FadeTest.TestFadeIn(fadeTime));
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    StartCoroutine(FadeTest.TestFadeOut(fadeTime));
        //}
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("fadein");
            FadeTest.StartFade(fadeSpeed);
            
        }
    }
}
