using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uku : MonoBehaviour
{
    [SerializeField]
    GameObject rayStart;
    [SerializeField]
    float hoverMax = 0,hoverPower=1;
    [SerializeField]
    GameObject rot;
    float _HoverTime = 0;

    bool _WallTrigger = false;

    Vector3 _HoverVec,_HoverDirection;
        
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Hover();
        }
        if(Input.GetMouseButton(0))
        {//左クリック
            Ins();
            //Vector2.Distance(this.gameObject.transform.position, Input.mousePosition);
            //Debug.Log();
            //Debug.Log("左クリック");
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //Hover(DirectionMath());
        }
        else if(Input.GetMouseButtonUp(0))
        {//離したらビーム非表示
            rot.SetActive(false);
        }

        if(_WallTrigger)
        {//ビームがあたった時の動き
            _HoverTime += Time.deltaTime;
            Debug.Log(_HoverTime);
            /*
            this.gameObject.GetComponent<Rigidbody2D>().AddForce
            (new Vector3(0, hoverPower, 0));*/

            this.gameObject.GetComponent<Rigidbody2D>().AddForce
            (_HoverDirection*_HoverTime);
        }
        else if(!_WallTrigger&&_HoverTime>0)
        {
            _HoverTime -= Time.deltaTime;
        }
    }
    /*
    Vector3 DirectionMath()
    {
        Vector3 Vec = 
            this.gameObject.transform.position - 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(Vec.x>=1)
        {
            Vec.x = 1;
        }
        else if(Vec.x<=-1)
        {
            Vec.x = -1;
        }
        if (Vec.y >= 1)
        {
            Vec.y = 1;
        }
        else if (Vec.y <= -1)
        {
            Vec.y = -1;
        }
        return Vec;
    }
    */
    void Ins()
    {
        //Vector3 Vec = DirectionMath();
        //Debug.Log(Mathf.Atan2(Vec.y, Vec.x));

        //進む方向決め
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        _HoverVec = rotation.eulerAngles;
        _HoverDirection = Quaternion.Euler(_HoverVec) * -Vector3.up;

        //_HoverDirection = new Vector3(Mathf.Abs(_HoverDirection.x), Mathf.Abs(_HoverDirection.y), 0);
        //Debug.Log(_HoverDirection);

        //ビーム表示、ビーム方向
        rot.SetActive(true);
        rot.transform.localRotation = rotation;

        //beem.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Vec.y, Vec.x));

        //beem.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    
    //過去の
    private void Hover()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, hoverPower, 0));
        /*
        Ray ray = new Ray(rayStart.transform.position, vec);
        //レイの出す場所と向き -Vector3.upのところをマウスの向きとかにする
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, hoverMax);
        //ながさとか？
        //Debug.DrawRay(ray.origin, ray.direction , Color.green);
        if (hit.collider!=null && !hit.collider.CompareTag("Player"))
        {
            
            //Debug.Log(hit.collider.gameObject.name);
            
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _WallTrigger = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        _WallTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _WallTrigger = false;
    }
}
