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
    public static IEnumerator IEFadeIn(/*Image _image, float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene*/Image _image, float _fadeTime)
    {
        //Debug.Log("fadein");
        if (_image == null)
        {
            _image = GameObject.Find("FadeImage").GetComponent<Image>();
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
                    _image.gameObject.SetActive(false);
                    break;
                }
            }
            //fadeDelegate(scene);
            
        }

    }
    public static IEnumerator IEFadeOut(/*Image _image, float _fadeTime*/Image _image, float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        Debug.Log("fadeout");
        isFade = true;
        if (_image == null)
        {
            _image = GameObject.Find("FadeImage").GetComponent<Image>();
            _image.gameObject.SetActive(true);
            _image.color = new Color32(0, 0, 0, 0);
        }
        if (_fadeTime != 0)
        {
            while (_image.color.a <= 1)
            {
                //Debug.Log(_image.color.a);
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
            //SoundManager.instance.Play("");
            fadeDelegate(scene);
        }
        
    }
    public static void FadeChange(Image _image, float _fadeTime, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        StaticMono.StartCoroutine(IEFadeOut(_image, _fadeTime,fadeDelegate,scene));

        //StaticMono.StartCoroutine(IEFadeIn(_image, _fadeTime));
    }
}