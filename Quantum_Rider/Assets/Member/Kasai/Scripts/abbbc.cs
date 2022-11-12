using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abbbc : MonoBehaviour
{

    [SerializeField]
    private Image image;
    [SerializeField]
    private float fadetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            FadeTest.FadeOut(image, fadetime);
        }
    }
}
