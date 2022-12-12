using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Fade
{
    private static MonoBehaviour StaticMono = GameManager.instance as MonoBehaviour;
    private static float time = 0;

	public delegate void FadeDelegate(MapManager.SceneID scene);
    public static FadeDelegate fadeDelegate;
    public static bool isFade = false;
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
                    isFade = false;
                    _fadeImage.gameObject.SetActive(false);
                    break;
                }
            }
            //fadeDelegate(scene);
            
        }

    }
    public static IEnumerator IEFadeOut(float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        GetFadeImage();
        _fadeImage.gameObject.SetActive(true);
        //Debug.Log("fadeout");
        //Debug.Log( _fadeImage);
        isFade = true;
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();

            image.color = new Color32(0, 0, 0, 0);
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
            fadeDelegate(scene);
        }
        
    }
    public static void FadeChange(float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        StaticMono.StartCoroutine(IEFadeOut(_fadeTime,fadeDelegate,scene));
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
}