using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    #region �錾
    [Header("�t�F�[�h")] public Fade fade;
    private bool goNextScene = false;
    private float pos_y;
    [SerializeField]
    GameMainContol gameMainContol;
    #endregion
    //Update
    private void Update()
    {
        #region�@���t���[���Ăяo��
        //recttransform���擾
        RectTransform pos;
        pos = GetComponent<RectTransform>();
        //�f�o�b�O�p key-vertical
        float kv = Input.GetAxis("Vertical");
        #endregion
        //������
        if (kv < 0)
        {
            Debug.Log("-360");
            //����̈ʒu��
            pos.localPosition = new Vector3(-470, -360, 0);

        }
        //�����
        if (kv > 0)
        {
            Debug.Log("-180");
            //��󉺂̈ʒu��
            pos.localPosition = new Vector3(-470, -180, 0);

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
            //�Q�[���𑱂���
            if (pos.localPosition.y == -180)
            {
                //�`���[�g���A��
                if (GameMainContol.Instance.SetScenes() == 1)
                {//�_���W�����̍ŏ�����p
                    SceneManager.LoadScene("tutorial");
                    goNextScene = true;
                }
                //�X�e�[�W�P
                if (GameMainContol.Instance.SetScenes() == 2)
                {//�X�e�[�W�P����p
                    SceneManager.LoadScene("first half");
                    goNextScene = true;
                }
                //�X�e�[�W�Q
                if (GameMainContol.Instance.SetScenes() == 3)
                { //�X�e�[�W�Q����p
                    SceneManager.LoadScene("second half");
                    goNextScene = true;
                }
                //���Ԓn�_
                if (GameMainContol.Instance.SetScenes() == 4)
                {//�{�X�킩��p
                    SceneManager.LoadScene("Safe Zone");
                    goNextScene = true;
                }
            }
            //�^�C�g���ɖ߂�
            if (pos.localPosition.y == -360)
            {
                SceneManager.LoadScene("title");
                goNextScene = true;
            }
        }
    }
}
