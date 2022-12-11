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
    private static GameObject _fadeImage;
    //public static IEnumerator FadeChange(bool trigger, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    //{
        //true‚Åfadein
        //false‚Åfadeout
  //      if (trigger)
  //      {
  //          while (alfa > 0)
  //          {
  //              alfa -= (byte)fadeSpeed;                
  //              SetAlpha();
  //              yield return null;
  //          }
  //          fadeImage.enabled = false;

  //      }
  //      else
  //      {
  //          while (alfa < 255)
  //          {
  //              alfa += (byte)fadeSpeed;
  //              SetAlpha();
                //yield return null;
  //          }
		//	fadeDelegate(scene);
		//}
    //}
    public static IEnumerator IEFadeIn(Image _image, float _fadeTime)
    {
        if (_fadeImage == null)
        {
            _fadeImage = GameObject.Find("FadeImage");
        }
        //Debug.Log("fadein");
        //Debug.Log("FadeIn" + _image);
        Debug.Log(_fadeTime);
        if (_image == null)
        {
            _image = _fadeImage.GetComponent<Image>();
            _image.color = new Color32(0, 0, 0, 255);
        }
        if (_fadeTime != 0)
        {
            while (_image.color.a >= 0)
            {
                time += Time.deltaTime;
                if (time >= _fadeTime / 255)
                {
                    time -= _fadeTime / 255;
                    Color32 c = _image.color;
                    c.a--;
                    _image.color = c;
                }
                yield return null;
                if (_image.color.a == 0)
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
    public static IEnumerator IEFadeOut(Image _image, float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        if (_fadeImage == null)
        {
            _fadeImage = GameObject.Find("FadeImage");
        }
        //Debug.Log("fadeout");
        Debug.Log("FadeOut" + _image);
        isFade = true;
        if (_image == null)
        {
            _image = _fadeImage.GetComponent<Image>();

            _image.color = new Color32(0, 0, 0, 0);
        }
        _fadeImage.gameObject.SetActive(true);
        if (_fadeTime != 0)
        {
            while (_image.color.a <= 1)
            {
                time += Time.deltaTime;
                if (time >= _fadeTime / 255)
                {
                    time -= _fadeTime / 255;
                    Color32 c = _image.color;
                    c.a++;
                    _image.color = c;
                }
                yield return null;
                if (_image.color.a == 1)
                {
                    time = 0;
                    break;
                }
            }
            fadeDelegate(scene);
        }
        
    }
    public static void FadeChange(Image _image, float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        StaticMono.StartCoroutine(IEFadeOut(_image, _fadeTime,fadeDelegate,scene));
    }
}