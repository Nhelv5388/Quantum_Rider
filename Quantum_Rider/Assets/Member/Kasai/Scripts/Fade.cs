using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //public static Fade Instance { get => _instance; }
    //static Fade _instance;
    byte fadeSpeed = 1;        //�����x���ς��X�s�[�h���Ǘ�
	byte alfa;   //�p�l���̐F�A�s�����x���Ǘ�

	public delegate void FadeDelegate(MapManager.SceneID scene);

	Image fadeImage;                //�����x��ύX����p�l��
	private void Awake()
	{
        //if (Instance == null)
        //{
        //    _instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
        SceneManager.sceneLoaded += OnSceneLoad;

        
    }
	void Start()
	{
		fadeImage.color = new Color32(0, 0, 0, 0);
	}

	public void FadeReset()
    {
		fadeImage.color=new Color32(0, 0, 0, 255);
    }
    public IEnumerator	FadeChange(bool trigger, FadeDelegate fadeDelegate, MapManager.SceneID scene)
    {
        //true��fadein
        //false��fadeout
        if (trigger)
        {
            while (alfa > 0)
            {
                alfa -= (byte)fadeSpeed;                
                SetAlpha();
                yield return null;
            }
            fadeImage.enabled = false;

        }
        else
        {
            while (alfa < 255)
            {
                alfa += (byte)fadeSpeed;
                SetAlpha();
                yield return null;
            }
			fadeDelegate(scene);
		}
    }

	public void SetAlpha()
	{
		GetComponent<Image>().color = new Color32(0, 0, 0, alfa);
	}
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(fadeImage==null)
        {
            fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();
        }
        
    }
}