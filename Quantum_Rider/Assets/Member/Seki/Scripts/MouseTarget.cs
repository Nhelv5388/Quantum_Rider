using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    [SerializeField,Header("マウスカーソル消したかったらfalseにしてね")] bool cursortrigger = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = cursortrigger;
        this.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
    }
}
