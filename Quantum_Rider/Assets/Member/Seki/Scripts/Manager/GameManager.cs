using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance=null;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        HPManager.instance.hpZero += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChange(string gotoScene)
    {
        SceneManager.LoadScene(gotoScene);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    private void GameOver()
    {
        SceneChange("GameOver");
    }

}