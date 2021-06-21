using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlev2 : MonoBehaviour
{
    [Header("�t�F�[�h")] public Fade fade;
    private bool goNextScene = false;
    private float pos_y;
   
    private void Update()
    {
        //recttransform���擾
        RectTransform pos;
        pos = GetComponent<RectTransform>();
        //D-Pad-vertical
        float dpv = Input.GetAxis("Pad_Vertical");
        //�f�o�b�O�p key-vertical
        float kv = Input.GetAxis("Vertical");
        //������
        if (dpv < 0 || kv < 0)
        {
            Debug.Log("-360");
            //����̈ʒu��
            pos.localPosition = new Vector3(-330, -360, 0);
            
        }
        //�����
        if(dpv > 0 || kv > 0)
        {
            Debug.Log("-180");
            //��󉺂̈ʒu��
            pos.localPosition = new Vector3(-330, -180, 0);
           
        }
        //�Ƃ肠�������u���̌���{�^��
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("���͂�����");
            //�t�F�[�h�A�E�g�X�^�[�g
            fade.StartFadeOut();
        }
        //��ʑJ��
        if (fade.IsFadeOutComplete() && !goNextScene)
        {
            if (pos.localPosition.y == -180)
            {
                SceneManager.LoadScene("Tutorial");
                goNextScene = true;
            }
            if (pos.localPosition.y == -360)
            {
                SceneManager.LoadScene("first half");
                goNextScene = true;
            }
        }
    }
}
