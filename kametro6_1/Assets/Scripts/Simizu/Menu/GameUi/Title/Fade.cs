using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    #region �錾
    [Header("�ŏ�����t�F�[�h�C�����������Ă��邩�ǂ���")] public bool firstFadeInComp;
    private Image img = null;           //�C���[�W���擾
    private int frameCount = 0;         //�t���[���̊m�F
    private float timer = 0.0f;         //�t�F�C�h�^�C�}�[
    private bool fadeIn = false;        //�t�F�C�h�C���ȊO���Ă΂��Ȃ�����
    private bool fadeOut = false;       //�t�F�C�h�A�E�g�ȊO���Ă΂��Ȃ�����
    private bool compFadeIn = false;    //�t�F�C�h�C�������̔���
    private bool compFadeOut = false;   //�t�F�C�h�A�E�g�����̔���
    #endregion
    #region Start
    // Start
    void Start()
    {
        //�C���[�W�̏�����
        img = GetComponent<Image>();
        if (firstFadeInComp)
        {
            FadeInComplete();
        }
        else
        {
            StartFadeIn();
        }
    }
    #endregion
    #region Update
    // Update
    void Update()
    {
        //�v���炵���̂�2�t���[���҂�
        if (frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();
            }
            else if (fadeOut)
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }
    #endregion
    #region �t�F�C�h�C��
    //�t�F�[�h�C�����J�n����
    public void StartFadeIn()
    {
        //fadeIn��fadeOut�ǂ��炩���Ă΂�Ă��Ȃ���
        if (fadeIn || fadeOut)
        {
            //�Ă΂�Ă���ꍇ�������I���
            return;
        }
        //fadeIn���Ă΂ꂽ
        fadeIn = true;
        //�I�i�t�F�C�h�C�����Ă���j
        compFadeIn = false;
        //�t�F�C�h�^�C�}�[�̏�����
        timer = 0.0f;
        //�C���[�W��p�ӂ��ăJ���[�����ɂ���
        img.color = new Color(1, 1, 1, 1);
        //�t�F�C�h�C���̓���
        img.fillAmount = 1;
    }
    //�t�F�[�h�C���������������ǂ���
    public bool IsFadeInComplete()
    {
        return compFadeIn;
    }
    //�t�F�[�h�C��
    private void FadeInUpdate()
    {
        //�t�F�[�h��
        if (timer < 1f)
        {
            //1,1,1,1�͌��̐F���g���Ƃ�����
            img.color = new Color(1, 1, 1, 1 - timer);
            img.fillAmount = 1 - timer;
        }
        //�t�F�[�h����
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }
    //�t�F�C�h�C��������
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        //�����蔻��off
        img.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    #endregion
    #region �t�F�C�h�A�E�g
    //�t�F�[�h�A�E�g���J�n����
    public void StartFadeOut()
    {
        //fadeIn��fadeOut�ǂ��炩���Ă΂�Ă��Ȃ���
        if (fadeIn || fadeOut)
        {
            //�Ă΂�Ă���ꍇ�������I���
            return;
        }
        //fadeOut���Ă΂ꂽ
        fadeOut = true;
        //�I�i�t�F�C�h�A�E�g���Ă���j
        compFadeOut = false;
        //�t�F�C�h�^�C�}�[�̏�����
        timer = 0.0f;
        //�C���[�W��p�ӂ��ăJ���[�����ɂ���
        img.color = new Color(1, 1, 1, 0);
        ///�t�F�C�h�A�E�g�̓���
        img.fillAmount = 1;
    }
    //�t�F�[�h�A�E�g�������������ǂ���
    public bool IsFadeOutComplete()
    {
        return compFadeOut;
    }
    //�t�F�[�h�A�E�g
    private void FadeOutUpdate()
    {
        //�t�F�[�h��
        if (timer < 1f)
        {
            //1,1,1,1�͌��̐F���g���Ƃ�����
            img.color = new Color(1, 1, 1, timer);
            img.fillAmount = timer;
        }
        //�t�F�[�h����
        else
        {
            FadeOutComplete();
        }
        timer += Time.deltaTime;
    }
    //�t�F�C�h�A�E�g������
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 0;
        //�����蔻��off
        img.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;
        compFadeOut = true;
    }
    #endregion
}
