using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetAnimator()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GetAnimator();
        //Debug.Log("É{ÉÄçƒê∂");
        anim.SetInteger("Bomb", 1);
    }

    void Des()
    {
        Destroy(this.gameObject);
    }
}
