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
            this.gameObject.SetActive(false);
            StartCoroutine(Frag(col.gameObject));
        }
    }

    IEnumerator Frag(GameObject a)
    {
        yield return new WaitForSeconds(seconds);
        a.gameObject.GetComponent<PlayerMove>().throughFrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
