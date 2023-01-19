using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTama : MonoBehaviour
{
    // îÚÇŒÇ∑íe
    [SerializeField]
    private GameObject Tama;
    // íeÇÃî≠éÀä‘äu
    [SerializeField]
    private float Shotinterval;
    [SerializeField]
    private int angle;
    bool coroutineBool = false;


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
        angle += 45;
        Debug.Log(angle);
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));

    }

    // enemyÇ™éÄÇÒÇæÇÁèeÇ‡è¡Ç¶ÇÈ
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
