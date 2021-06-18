using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    [Header("�ŏ�����t�F�[�h�C�����������Ă��邩�ǂ���")] public bool firstFadeInComp;

    private Image img = null;
    private int frameCount = 0;
    private float timer = 0.0f;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool compFadeIn = false;
    private bool compFadeOut = false;
    //�t�F�[�h�C�����J�n����
    public void StartFadeIn()
    {
        if(fadeIn || fadeOut)
        {
            return;
        }
        fadeIn = true;
        compFadeIn = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = true;
    }
    //�t�F�[�h�C���������������ǂ���
    public bool IsFadeInComplete()
    {
        return compFadeIn;
    }
    //�t�F�[�h�A�E�g���J�n����
    public void StartFadeOut()
    {
        if (fadeIn || fadeOut)
        {
            return;
        }
        fadeOut = true;
        compFadeOut = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 1;
        img.raycastTarget = true;
    }
    //�t�F�[�h�A�E�g�������������ǂ���
    public bool IsFadeOutComplete()
    {
        return compFadeOut;
    }
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        if(firstFadeInComp)
        {
            FadeInComplete();
        }
        else
        {
            StartFadeIn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�v���炵���̂�2�t���[���҂�
        if(frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();
            }
            else if(fadeOut)
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
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
}
