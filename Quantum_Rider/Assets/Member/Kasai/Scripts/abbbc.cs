using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abbbc : MonoBehaviour
{

    [SerializeField]
    private Image _image;
    [SerializeField]
    private float fadetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    _image = null;
        //    _image = GameObject.Find("FadeImage").GetComponent<Image>();
        //    Debug.Log(_image);
        //}
        //if(Input.GetKeyDown(KeyCode.H))
        //{
        //    //FadeTest.IEFade(image, fadetime,true);
        //    StartCoroutine(FadeTest.IEFade(image,fadetime,true));
        //    Debug.Log("a");
        //}
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    //FadeTest.IEFade(image, fadetime,false);
        //    StartCoroutine(FadeTest.IEFade(image, fadetime, false));
        //    Debug.Log("b");
        //}
        //FadeTest.IEFadeIn(image, fadetime);
        ////サウンドテスト
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Semanager.instance.Play("Heal");
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Semanager.instance.Play("Laser");
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Semanager.instance.Play("Explosion");
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Semanager.instance.Play("Damaged");
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Semanager.instance.Play("Select");
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    Semanager.instance.Play("Barrier");
        //}
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    SoundManager.instance.Play("Title");
        //}
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    SoundManager.instance.Play("MainGame");
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    SoundManager.instance.Play("GameOver");
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    //SoundManager.instance.Stop();

        //}

    }
}
