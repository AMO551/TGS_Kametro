using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class siyuukai : MonoBehaviour
{

    [Header("�t�F�[�h")] public Fade fade;
    private bool goNextScene = false;
    private float pos_y;
    [SerializeField]
    GameMainContol gameMainContol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //recttransform���擾
        RectTransform pos;
        pos = GetComponent<RectTransform>();
        //D-Pad-vertical
        // float dpv = Input.GetAxis("Pad_Vertical");
        //�f�o�b�O�p key-vertical
        float kv = Input.GetAxis("Vertical");

        //�Ƃ肠�������u���̌���{�^��
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("���͂�����");
            //�t�F�[�h�A�E�g�X�^�[�g
            fade.StartFadeOut();
        }
        if (fade.IsFadeOutComplete() && !goNextScene)
        {
            if (pos.localPosition.y == -360)
            {
                SceneManager.LoadScene("title");
                goNextScene = true;
            }
        }
    }
        
}
