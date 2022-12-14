using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abbbc : MonoBehaviour
{

    [SerializeField]
    private Image _image;
    [SerializeField]
    private float fadeTime;
    // Start is called before the first frame update
    void Start()
    {
        FadeTest.GetFadeImage();//�^�C�g���Ń{�^���������Ȃ������C���̂���
                            //Debug.Log(Fade._fadeImage);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(FadeTest.IEFadeIn(fadeTime));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeTest.IEFadeOut(fadeTime));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            FadeTest.FadeChange(fadeTime);
        }

        //�V�����ق��͂�����
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(FadeTest.TestFadeIn(fadeTime));
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(FadeTest.TestFadeOut(fadeTime));
        }
    }
}
