using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMove : MonoBehaviour
{

    [SerializeField]

    GameObject parent;

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
        direction = Quaternion.Euler
           (parent.transform.rotation.eulerAngles) * -Vector3.up;
        this.gameObject.transform.Translate(direction * Time.deltaTime * speed);
    }

    private void OnEnable()
    {

        
    }

    private void OnDisable()
    {
        this.gameObject.transform.position = parent.transform.position;
    }
}
