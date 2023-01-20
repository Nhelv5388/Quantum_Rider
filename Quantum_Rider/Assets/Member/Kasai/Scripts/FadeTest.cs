using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class FadeTest
{
    private static MonoBehaviour StaticMono = GameManager.instance as MonoBehaviour;
    private static MonoBehaviour StaticMonotest = GameManager.instance;
    private static float time = 0;
    public static GameObject _fadeImage;
    private static Image image;
    public static IEnumerator IEFadeIn(float _fadeTime)
    {
        GetFadeImage();
        //Debug.Log(_fadeTime);
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();
            image.color = new Color32(0, 0, 0, 255);
        }
        if (_fadeTime != 0)
        {
            while (image.color.a >= 0)
            {
                time += Time.deltaTime;
                if (time >= _fadeTime / 255)
                {
                    time -= _fadeTime / 255;
                    Color32 c = image.color;
                    c.a--;
                    image.color = c;
                }
                yield return null;
                if (image.color.a == 0)
                {
                    time = 0;
                    _fadeImage.gameObject.SetActive(false);
                    break;
                }
            }
            //fadeDelegate(scene);

        }

    }
    public static IEnumerator IEFadeOut(float _fadeTime)
    {
        GetFadeImage();
        _fadeImage.gameObject.SetActive(true);
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();

            image.color = new Color(0, 0, 0, 0);
        }

        if (_fadeTime != 0)
        {
            while (image.color.a <= 1)
            {
                time += Time.deltaTime;
                if (time >= _fadeTime / 255)
                {
                    time -= _fadeTime / 255;
                    Color32 c = image.color;
                    c.a++;
                    image.color = c;
                }
                yield return null;
                if (image.color.a == 1)
                {
                    time = 0;
                    break;
                }
            }
        }

    }
    public static IEnumerator TestFadeIn(float _fadeTime)
    {
        GetFadeImage();
        //Debug.Log(_fadeTime);
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();
            image.color = new Color(0, 0, 0, 1.0f);
        }
        if (_fadeTime != 0)
        {
            //while (image.color.a >= 0)
            //{
            //    time += Time.deltaTime;
            //    if (time >= _fadeTime / 255)
            //    {
            //        time -= _fadeTime / 255;
            //        Color c = image.color;
            //        c.a-= time/_fadeTime;
            //        Debug.Log("alpha-");
            //        image.color = c;
            //    }
            //    yield return null;
            //    if (image.color.a == 0)
            //    {
            //        time = 0;
            //        _fadeImage.gameObject.SetActive(false);
            //        break;
            //    }
            //}
            //fadeDelegate(scene);
            while (image.color.a >= 0)
            {
                time += Time.deltaTime;
                var rate = time / _fadeTime;
                Color c =image.color;
                Debug.Log(rate);
                c.a -= rate;
                image.color = c;

                yield return null;
                if(image.color.a == 0)
                {
                    time = 0;
                    _fadeImage.gameObject.SetActive(false);
                    break;
                }
            }


        }

    }
    public static IEnumerator TestFadeOut(float _fadeTime)
    {
        GetFadeImage();
        _fadeImage.gameObject.SetActive(true);
        //Debug.Log("fadeout");
        //Debug.Log( _fadeImage);
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();

            image.color = new Color(0, 0, 0, 0);
        }

        if (_fadeTime != 0)
        {
            while (image.color.a <= 1)
            {
                time += Time.deltaTime;
                if (time >= _fadeTime / 255)
                {
                    time -= _fadeTime / 255;
                    Color c = image.color;
                    c.a += time / _fadeTime;
                    Debug.Log("alpha+");
                    image.color = c;
                }
                yield return null;
                if (image.color.a == 1)
                {
                    time = 0;
                    break;
                }
            }
        }

    }
    public static void FadeChange(float fadeTime)
    {
        //Debug.Log(_fadeTime);
        StaticMono.StartCoroutine(IEFadeOut(fadeTime));
    }

    public static void GetFadeImage()
    {
        if (_fadeImage == null)
        {
            _fadeImage = GameObject.Find("FadeImage");
        }
        else
        {
            //Debug.Log(_fadeImage);
        }
    }
    public static IEnumerator FadeinFixed(float fadespeed)
    {
        GetFadeImage();
        //_fadeImage.SetActive(true);
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();
            image.color = new Color(0, 0, 0, 1.0f);
        }
        while(image.color.a >= 0)
        {
            Color c = image.color;
            c.a -= fadespeed;
            image.color = c;
            yield return null;
            Debug.Log(c.a);
            if (image.color.a == 0)
            {
                _fadeImage.gameObject.SetActive(false);
                break;
            }
        }
    }
    public static void StartFade(float fadespeed)
    {
        Debug.Log(fadespeed);
        StaticMonotest.StartCoroutine(FadeinFixed(fadespeed));
    }
}