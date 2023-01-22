using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    GameObject a;
    [SerializeField]
    float seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            a = col.gameObject;
            col.gameObject.GetComponent<PlayerMove>().throughFrag = true;
            StartCoroutine(Frag(col.gameObject));
            Semanager.instance.Play("Barrier");
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            
        }
    }

    IEnumerator Frag(GameObject a)
    {
        yield return new WaitForSeconds(seconds);
        Semanager.instance.Play("BarrierLost");
        a.gameObject.GetComponent<PlayerMove>().throughFrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
