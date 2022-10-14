using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator anim;

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
