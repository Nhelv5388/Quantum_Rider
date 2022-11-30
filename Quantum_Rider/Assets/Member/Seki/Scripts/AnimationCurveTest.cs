using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveTest : MonoBehaviour
{

    [SerializeField]
    AnimationCurve _Jump,_Fall;
    [SerializeField]
    float power = 1;
    float jumpTime = 0;
    int count = 0;
    Vector3 _JumpForce,_FallForce;

    Vector3 one;

    Rigidbody2D rb;

    bool isJump,isFall = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        jumpTime =_Jump[1].time;
        Debug.Log(_Jump[1].time);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isJump = true;
            Debug.Log("押す");
            //StartCoroutine(JumpCor());
            //one = new Vector3(0, GetCurve(0.0f), 0);
            //this.gameObject.GetComponent<Rigidbody2D>().
            //    AddForce(one, ForceMode2D.Impulse);

        }
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            Jump(count);
        }
        
        if (isFall) rb.velocity = _FallForce;
        //Debug.Log(rb.velocity);
    }
    void Jump(float time)
    {//ここをいじれ！！！！

        GetCurve(time);
        count ++;
        Debug.Log(count);
        Debug.Log(jumpTime * 50);
        if (count >= jumpTime*50)
        {
            count = 0;
            isJump = false;
            Debug.Log("ジャンプ終わり");
        }
    }
    //IEnumerator JumpCor()
    //{
    //    float count = 0;
    //    while(count <jumpTime)
    //    {
             
    //        _JumpForce = new Vector3(0, GetCurve(count)*power, 0);
            
    //        //Debug.Log(GetCurve(count));
    //        count += 0.01f;
    //        yield return null;
    //    }
    //    isJump = false;
    //    rb.velocity = Vector3.zero;
    //    Debug.Log("ジャンプ終わり");
    //}
    float GetCurve(float time)
    {
        float r;
        r = _Jump.Evaluate(time);
        return r;
    }
}
