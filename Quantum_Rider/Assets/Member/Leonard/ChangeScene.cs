using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;

    public enum Scene
    {
        Scene1,
        Scene2,
        Scene3,
    }

    public void Change()
    {
        StartCoroutine(SceneChange());
    }

    public void SceneChange(Scene Scene)
    {
        switch (Scene)
        {
            case Scene.Scene1:
                SceneManager.LoadScene("Title");
                this.Player.SetActive(false);
                break;
            case Scene.Scene2:
                SceneManager.LoadScene("GameOver");
                this.Player.SetActive(true);
                break;
            case Scene.Scene3:
                SceneManager.LoadScene("Clear");
                this.Player.SetActive(false);
                break;
            default:
                Debug.Log("No Map");
                break;
        }
    }

    IEnumerator SceneChange()
    {
        anim.SetTrigger("In");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
