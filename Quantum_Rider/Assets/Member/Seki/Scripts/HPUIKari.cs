using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUIKari : MonoBehaviour
{

    [SerializeField]
    private GameObject[] hpUI = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HPHenkou(int HPLength)
    {
        //Debug.LogError(HPLength);
        for (int i = 0; i < HPLength; i++)
        {
            
            hpUI[i].SetActive(true);
        }
        for(int i =hpUI.Length-1;i>=HPLength;i--)
        {
            hpUI[i].SetActive(false);
        }
        //HPManager.instance.GetHP();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
