using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    //pulic-----------------------
    //�񕜂̏�����
    public float recovete = 30;
    //�񕜂̍ő�l
    public int Max_HP = 100;
    //�u���b�N�񕜃u�[��
    public bool block =false;
    //private--------------------
    //�A�b�v�f�[�g�̏������ifalse�j
    private bool Updeta = false;
    //�v���C���[�̌Ăяo��

    private int Player_HP = 50;
    //�L�����N�^�[��HP���擾
    private int huri_HP=0;�@//�ӂ蕝������


    // Start is called before the first frame update
    void Start()
    {
        //�L�����N�^�[��HP��Player_HP�ɏ���������
    }

    // Update is called once per frame
    void Update()
    {
        //Player��HP�����������Ă���

        //Player_HP���A�b�v�f�[�g���Ă���
        if (Updeta == true)
        {
            //�v���C���[��HP�}�b�N�X����Ȃ������ꍇ
            if (Player_HP <= Max_HP)
            {
                //�񕜂����邷��
                recovete = 30;
                Player_HP += 30;
                //������u���b�N������
                Destroy(gameObject);
                //Debug.Log(recovete);
                //�񕜂�����Player�̂悤��recovete��O�ɂ���
            }
            //HP�̂ӂ蕝���P�O�O�ȏォ�m�F
            if(Player_HP>=Max_HP)
            {
                //�ӂ蕝���������m�F
                huri_HP = Max_HP - Player_HP;
                //�ӂ蕝������HP���P�O�O�ɖ߂�
                Player_HP -= huri_HP;

            }
            //�A�b�v�f�[�g��false�ɂ���
            Updeta = false;
        }
        else
        {
            //�񕜂���߂�
            recovete = 0;
            //Debug.Log(recovete);
        }

    }
    //�����ʉ߂���������
    void OnTriggerEnter2D(Collider2D other2d)
    {
        //�v���C���[���������Ă��邩�̔���
        if (other2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("�񕜂����B");
            //�u���b�N�̉�
            block = true;
            //�_���[�W��^����֐���true�ɂ���
            Updeta = true;

        }
    }

}