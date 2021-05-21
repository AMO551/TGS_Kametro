using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedWater : MonoBehaviour
{
    //�L�����N�^�[�̃f�o�t�̏�����
    public int detspeed = 1;       //�v���C���[�̑��x�̃f�o�t
    public int Player_HP = 10;     //�v���C���[HP�̊m�F
    public int Player_damege = 1;  //�v���C���[�����������Ƃ��̃_���[�W
    public bool damege = false;    //�p���_���[�W�̔���
    //���̃v���C���[HP
    private float countup = 0.0f;�@//���Ԃ𑪂�ϐ�
    private float timeLimit = 2.0f;//���Ԃ̍ő�𑪂�ϐ�
    private bool update = false;   //�v���C���[���������Ă��邩�̕ϐ�

    ///////////////////////////////////////////////////
    GameObject Player2D;           //Player������ϐ�
    player script;                 //�X�N���v�g���Ăяo���ϐ�
    /// //////////////////////////////////////////////
    // �X�^�[�g�ɌĂ΂��֐�
    void Start()
    {
        ///////////////////////////////////////////////////////
        //Player���I�u�W�F�N�g�̖��O����擾���ĕϐ��Ɋi�[����
        Player2D = GameObject.Find("Player");
        //Player�̒��ɂ���X�N���v�g�iPlayer�j���擾���ĕϐ��Ɋi�[����
        script = Player2D.GetComponent<player>();
        ///////////////////////////////////////////////////////
        //�e�X�g���O
        Debug.Log("TEST�@Log");
    }

    // ���t���[�����ƂɌĂ΂��֐�
    void Update()
    {
        //int PlayHP = script.Player_hp;
        //�L�����N�^�[���Ő��ɓ��������𔻒肷��
        if (update == true)
        {
            //�o�ߎ��Ԃ𐔂���
            countup += Time.deltaTime;
            //2�b�𒴂����ꍇ�ɓ���
            if (countup >= timeLimit)
            {
                //�o�ߎ��Ԃ�\������
                Debug.Log("2�b������");
                //�p���_���[�W��true�ɂ���B
                damege = true;
                //���Ԃ����Z�b�g����
                countup = 0.0f;
            }
            //Debug.Log("�_���[�W");
            //�_���[�W��^����
            if (damege == true)
            {
                //�v���C���[�Ƀ_���[�W��^����
                Player_HP -= Player_damege;
                //�_���[�W�����������m�F���O
                Debug.Log(Player_HP);
                //�����_���[�W��false�ɂ���
                damege = false;
            }
        }
    }
    //�����ʉ߂���������
    void OnTriggerEnter2D(Collider2D other2d)
    {
        Debug.Log("��������");
        
        //�v���C���[���������Ă��邩�̔���
        if (other2d.gameObject.CompareTag("Player"))
        {
         
            Debug.Log("�v���C�₪�G�ꂽ");
            //�X�s�[�h�𔼕��ɂ���
            detspeed = 2;
            //�_���[�W��^����֐���true�ɂ���
            update = true;

        }
    }
    //���̒ʉ߂��I�����������
    void OnTriggerExit2D(Collider2D other2d)
    {
        Debug.Log("�o��");
        //�v���C���[���������Ă��邩�̔���
        if (other2d.gameObject.CompareTag("Player"))
        {
            //�X�s�[�h�����ɂ���
            detspeed = 1;
            //�_���[�W��^����֐���false�ɂ���
            update = false;

        }
    }


}
