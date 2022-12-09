using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTama : MonoBehaviour
{
    // ��΂��e
    [SerializeField]
    private GameObject Tama;
    // �e�̔��ˊԊu
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
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 45));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 135));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 225));
        Instantiate(Tama, this.gameObject.transform.position, Quaternion.Euler(0, 0, angle + 315));
        angle += 45;
        transform.Rotate(new Vector3(0.0f, 0.0f, angle));

    }

    // enemy�����񂾂�e��������
    private void GunDestroy()
    {

    }
    private void OnDisable()
    {
        CancelInvoke("ShotPrefab");
    }

}
