using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
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
            Debug.Log("-290");
            //����̈ʒu��
            pos.localPosition = new Vector3(-470, -290, 0);

        }
        //�����
        if (dpv > 0 || kv > 0)
        {
            Debug.Log("-90");
            //��󉺂̈ʒu��
            pos.localPosition = new Vector3(-470, -90, 0);

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
            //-90if�̏�����ǉ��\��
            if (pos.localPosition.y == -90)
            {
                //�_���W�����̍ŏ�����p
                SceneManager.LoadScene("tutorial");
                goNextScene = true;
            }
            if (pos.localPosition.y == -90)
            {
                //�X�e�[�W�P����p
                SceneManager.LoadScene("first half");
                goNextScene = true;
            }
            if (pos.localPosition.y == -90)
            {
                //�X�e�[�W�Q����p
                SceneManager.LoadScene("second half");
                goNextScene = true;
            }
            if (pos.localPosition.y == -90)
            {
               //�{�X�킩��p
                SceneManager.LoadScene("bos half");
                goNextScene = true;
            }
            if (pos.localPosition.y == -290)
            {
                SceneManager.LoadScene("title");
                goNextScene = true;
            }
        }
    }
}
