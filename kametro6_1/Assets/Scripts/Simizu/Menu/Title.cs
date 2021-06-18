using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [Header("フェード")] public Fade fade;

    private bool firstPush = false;
    private bool goNextScene = false;
    private bool firsthalf = false;
    //
    public void PressStart()
    {
        Debug.Log("osareta");
        if(!firstPush)
        {
            Debug.Log("Firstifnai");
            fade.StartFadeOut();
            firstPush = true;
            firsthalf = true;
        }
    }
    private void Update()
    {
        if(!goNextScene && fade.IsFadeOutComplete() && firsthalf)
        {
            Debug.Log("第一ステージ");
            SceneManager.LoadScene("first half");
            goNextScene = true;
        }
    }

}
