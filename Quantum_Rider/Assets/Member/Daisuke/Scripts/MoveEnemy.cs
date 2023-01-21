using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float _Speed;
    private Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * _Speed + StartPosition.x, StartPosition.y, StartPosition.z);
    }
    /*
    [SerializeField] private float _Speed;
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    private Vector3 StartPosition;
    private int direction = 1;
    void Start()
    {
        StartPosition = transform.position;
    }
    void Update()
    {
        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
        if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + _Speed * Time.deltaTime * direction, StartPosition.y, StartPosition.z);
    }
    */
}
