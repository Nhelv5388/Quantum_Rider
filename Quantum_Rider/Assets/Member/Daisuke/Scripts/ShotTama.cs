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
    private int angle = 0;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ShotPrefab), 1.5f, Shotinterval);
        transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShotPrefab()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));
        Instantiate(Tama, new Vector3(0, 0, 1), Quaternion.Euler(0, 0, angle + 45));
        Instantiate(Tama, new Vector3(0, 0, 1), Quaternion.Euler(0, 0, angle + 135));
        Instantiate(Tama, new Vector3(0, 0, 1), Quaternion.Euler(0, 0, angle + 225));
        Instantiate(Tama, new Vector3(0, 0, 1), Quaternion.Euler(0, 0, angle + 315));
        angle += 45;
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));

    }

    // enemyÇ™éÄÇÒÇæÇÁèeÇ‡è¡Ç¶ÇÈ
    private void GunDestroy()
    {

    }

}
