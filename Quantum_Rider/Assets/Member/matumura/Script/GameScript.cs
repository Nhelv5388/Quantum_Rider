using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    public Image image;

    //Startは、最初のフレーム更新の前に呼び出されます。
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            image.fillAmount -= Time.deltaTime;
        }
        else
        {

            image.fillAmount += Time.deltaTime;
        }


    }
}