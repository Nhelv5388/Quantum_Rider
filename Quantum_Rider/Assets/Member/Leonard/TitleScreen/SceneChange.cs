using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //[SerializeField] private MapManager.SceneID mapName;
    public void MoveToScene()
    {
        //Debug.Log("MoveToScene");
        //MapManager.Instance.CallFadeIn(mapName);
        SceneManager.LoadScene("Difficulty");
    }

    public void exitgame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    public void EasyMode()
    {
        Debug.Log("Easy");
        SceneManager.LoadScene("Easy");
    }

    public void HardMode()
    {
        Debug.Log("Hard");
        SceneManager.LoadScene("Hard");
    }
}
