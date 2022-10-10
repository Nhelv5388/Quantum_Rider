using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uku : MonoBehaviour
{
    [SerializeField]
    GameObject rayStart;
    [SerializeField]
    float hoverMax = 0,hoverPower=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Hover();
        }
    }
    

    private void Hover()
    {
        Ray ray = new Ray(rayStart.transform.position, -Vector3.forward);
        //ƒŒƒC‚Ìo‚·êŠ‚ÆŒü‚«
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, hoverMax);
        //‚È‚ª‚³‚Æ‚©H
        
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, hoverPower, 0));
        }
        Debug.DrawRay(ray.origin, ray.direction * hoverMax, Color.green, 5, true);
    }
}
