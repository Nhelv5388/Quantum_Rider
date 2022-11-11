using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMove : MonoBehaviour
{

    [SerializeField]

    GameObject parent;

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Quaternion.Euler
           (parent.transform.rotation.eulerAngles) * Vector3.right;
        this.gameObject.transform.Translate(direction * Time.deltaTime);
    }

    private void OnEnable()
    {

        
    }

    private void OnDisable()
    {
        
    }
}
