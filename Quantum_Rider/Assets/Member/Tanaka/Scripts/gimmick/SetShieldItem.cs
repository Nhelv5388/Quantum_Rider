using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShieldItem : MonoBehaviour
{
    [SerializeField]
    private GameObject sheildItemImage;
    [SerializeField]
    private GameObject sheildImage;
    [SerializeField]
    private GameObject playerPos;

    public bool activeSheild = false;

    void Start()
    {
        this.gameObject.SetActive(true);
    }

    void Update()
    {
        if (activeSheild)
        {
            sheildImage.transform.position = playerPos.transform.localPosition;
        }
        else
        {
            sheildImage.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //�G�ꂽ���\���ɂ���
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("�V�[���h�W�J");
            sheildItemImage.gameObject.SetActive(false);
            sheildImage.SetActive(true);
            activeSheild = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //�G�ꂽ���\���ɂ���
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("�V�[���h�W�J");
            sheildItemImage.gameObject.SetActive(false);
            sheildImage.SetActive(true);
            activeSheild = true;
        }
    }
}
