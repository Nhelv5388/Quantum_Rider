using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public int damage;
    public static bool Immortality=false;
    private bool _debugSwitch = false;
    private bool _debugStart=false;
    [SerializeField]private GameObject _debugObject;
    [SerializeField] private GameObject _debugText;
    [SerializeField] private GameObject _immortalText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            _debugSwitch = true;
            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _debugSwitch= false;        
        }
        DebugMode(_debugSwitch);

    }
    private void DebugMode(bool debugswitch)
    {
        if(!_debugStart&&debugswitch)
        {
            _debugObject.SetActive(true);
            _debugText.SetActive(true);
            _debugStart = true;
        }
        if (debugswitch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HPManager.instance.Kill();
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                HPManager.instance.Heal(10);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Immortality = true;
                _immortalText.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Immortality = false;
                _immortalText.SetActive(false);
            }

        }
        else
        {
            _debugObject.SetActive(false);
            _debugText.SetActive(false);
            _debugStart =false;
            Immortality = false;
        }
    }

}
