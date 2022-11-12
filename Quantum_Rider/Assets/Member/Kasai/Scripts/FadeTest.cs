using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class FadeTest
{
    private static MonoBehaviour StaticMono = GameManager.instance as MonoBehaviour;

    private static float time = 0;
    private static IEnumerator IEFadeOut(Image _image, float _fadeTime)
    {
        if (_fadeTime != 0)
        {
            //while (_image.color.a >= 0)
            //{
            //    var c = _image.color;
            //    c.a -= (Time.deltaTime / _fadeTime);
            //    _image.color = c;
            //    yield return null;
            //}

            while (_image.color.a >= 0)
            {
                time += Time.deltaTime;
                if(time >= _fadeTime/255)
                {
                    time -= _fadeTime/255;
                    Color32 c = _image.color;
                    c.a--;
                    _image.color = c;
                }
                yield return null;
                if (_image.color.a == 0)
                {
                    time = 0;
                    break;
                }
            }
        }
    }


    public static void FadeOut(Image _image, float _fadeTime)
    {
        StaticMono.StartCoroutine(IEFadeOut(_image, _fadeTime));
    }
}
