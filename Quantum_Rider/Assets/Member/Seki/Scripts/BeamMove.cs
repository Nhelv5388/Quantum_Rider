using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMove : MonoBehaviour
{

    [SerializeField]

    GameObject beamPos,beamDirection;

    [SerializeField]
    int speed = 1;

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.up* Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ç±Ç±Ç…è¡Ç∑èåèÇ
        if(collision.gameObject.CompareTag("Wall")||
            collision.gameObject.CompareTag("Floor")||
            collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        //this.gameObject.transform.position = beamPos.transform.position;

        //this.gameObject.transform.rotation = beamDirection.transform.rotation;
    }

    private void OnDisable()
    {
        //this.gameObject.transform.position = beamPos.transform.position;
    }
}
