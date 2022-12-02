using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : MonoBehaviour
{
    public static FadeImage Instance { get => _instance; }
    static FadeImage _instance;
    private void Awake()
    {
        
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
