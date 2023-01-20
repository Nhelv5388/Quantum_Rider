using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTest2 : MonoBehaviour
{
    public static GameObject _fadeImage;
    private static Image image;

    [SerializeField] private float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetFadeImage();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            FadeinFixed(fadeSpeed);
        }
        
    }
    public static void FadeinFixed(float fadespeed)
    {
        
        //_fadeImage.SetActive(true);
        if (image == null)
        {
            image = _fadeImage.GetComponent<Image>();
            image.color = new Color32(0, 0, 0, 255);
        }
        while (image.color.a >= 0)
        {
            Color c = image.color;
            c.a -= fadespeed;
            image.color = c;
            if (image.color.a == 0)
            {
                _fadeImage.gameObject.SetActive(false);
                break;
            }
        }
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
