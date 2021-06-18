using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title2 : MonoBehaviour
{
    [Header("�t�F�[�h")] public Fade fade;

    private bool firstPush = false;
    private bool goNextScene = false;
    private bool tutorial = false;
    //
    public void PressStart()
    {
        Debug.Log("osareta");
        if (!firstPush)
        {
            Debug.Log("Tutorialnai");
            fade.StartFadeOut();
            firstPush = true;
            tutorial = true;
        }
    }
    private void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete() && tutorial)
        {
            Debug.Log("�`���[�g���A���X�e�[�W");
            SceneManager.LoadScene("Tutorial");
            goNextScene = true;
        }
    }
}
