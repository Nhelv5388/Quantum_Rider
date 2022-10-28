using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;
    private bool Start;

    public enum Scene
    {
        Scene1,
        Scene2,
        Scene3,
    }

    void Update()
    {
        if(Start)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                SceneManager.LoadScene(1);
                Player.SetActive(true);
            }
        }
    }

    public void Change()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        anim.SetTrigger("In");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
