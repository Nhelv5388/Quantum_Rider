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

    private void OnEnable()
    {
        this.gameObject.transform.position = beamPos.transform.position;

        this.gameObject.transform.rotation = beamDirection.transform.rotation;
    }

    private void OnDisable()
    {
        this.gameObject.transform.position = beamPos.transform.position;
    }
}
