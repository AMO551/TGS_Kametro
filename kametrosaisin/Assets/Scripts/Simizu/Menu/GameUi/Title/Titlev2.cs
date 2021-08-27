using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlev2 : MonoBehaviour
{
    bool change = true;
    #region �錾
    //fada�ϐ��̌Ăяo��
    [Header("�t�F�[�h")] public Fade fade;
    //�t�F�C�h��������Ă΂�Ȃ��悤�ɂ��邾�߂̂���
    private bool goNextScene = false;
    //�A�b�v�f�[�g�Ǘ�
    public bool mane = true;
    #endregion
    //Start
    private void Start()
    {
        //�X�e�[�W�ɍs���g���K�[��������
        goNextScene = false;
    }
    //Update
    private void Update()
    {
        if (mane)
        {
            #region ���t���[���Ăяo��
            //recttransform���擾
            RectTransform pos;
            pos = GetComponent<RectTransform>();
            //�f�o�b�O�p key-vertical
            float kv = Input.GetAxis("Vertical");
            #endregion
            //������
            if (/*dpv < 0 || */kv < 0)
            {
                SoundManager.Instance.Play_SE(1, 27);
                //Debug.Log("-360");
                //����̈ʒu��
                pos.localPosition = new Vector3(-330, -360, 0);
             

            }
            //�����
            if (/*dpv > 0 ||*/ kv > 0)
            {
                SoundManager.Instance.Play_SE(1, 27);
                //Debug.Log("-180");
                //��󉺂̈ʒu��
                pos.localPosition = new Vector3(-330, -180, 0);
               

            }
            //�Ƃ肠�������u���̌���{�^��
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.Instance.Play_SE(1, 26);
                //Debug.Log("���͂�����");
                //�t�F�[�h�A�E�g�X�^�[�g
                fade.StartFadeOut();
            }
            //��ʑJ��
            if (fade.IsFadeOutComplete() && !goNextScene)
            {
               
                //��󂪏ゾ�����ꍇTurorial�ɃV�[���؂�ւ�
                if (pos.localPosition.y == -180)
                {
                     GameMainContol.Instance.scenes_contol(1); 
                    StartCoroutine(NextScene());

                    //�V�[���̐؂�ւ�
                    //SceneManager.LoadScene("StoryScene");
                    goNextScene = true; //�V�[����������Ă΂�Ȃ��悤��
                }
                //��󂪉��������ꍇfirst half�ɃV�[���؂�ւ�
                if (pos.localPosition.y == -360)
                {
                    GameMainContol.Instance.scenes_contol(2);
                    StartCoroutine(NextScene());
                    //�V�[���̐؂�ւ�
                    //SceneManager.LoadScene("StoryScene");
                    goNextScene = true; //�V�[����������Ă΂�Ȃ��悤��
                }
            }
        }
    }
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("StoryScene");
    }
}
