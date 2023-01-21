using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTama : MonoBehaviour
{
    // ”ò‚Î‚·’e
    [SerializeField]
    private GameObject Tama;
    // ’e‚Ì”­ŽËŠÔŠu
    [SerializeField]
    private float Shotinterval;
    [SerializeField]
    private int angle;
    bool coroutineBool = false;
    int i;


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating(nameof(ShotPrefab), 1.5f, Shotinterval);
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShotPrefab()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 45));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 135));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 225));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 315));
        for(i = 0; i <= 45; i++)
        {
            this.gameObject.transform.Rotate(0,0,1);
            
        }
        //angle += 45;
        Debug.Log(angle);
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));


    }

    // enemy‚ªŽ€‚ñ‚¾‚çe‚àÁ‚¦‚é
    private void GunDestroy()
    {
        /*
        if(Destroy(gameObject.tag == Enemy))
        {

        }
        */
    }
    private void OnDisable()
    {
        CancelInvoke("ShotPrefab");
    }

}
