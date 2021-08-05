using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class PoisonedWater : MonoBehaviour
{
  
    //�L�����N�^�[�̃f�o�t�̏�����
    public int detspeed = 1;       //�v���C���[�̑��x�̃f�o�t
    public int Player_HP = 10;     //�v���C���[HP�̊m�F
    public int Player_damege = 1;  //�v���C���[�����������Ƃ��̃_���[�W
    public bool damege = false;    //�p���_���[�W�̔���
    //���̃v���C���[HP
    private float countup = 0.0f;�@//���Ԃ𑪂�ϐ�
    private float timeLimit = 1.0f;//���Ԃ̍ő�𑪂�ϐ�
    private bool update = false;   //�v���C���[���������Ă��邩�̕ϐ�
    private bool start_dame = false;
    
    ///////////////////////////////////////////////////
    GameObject Player2D;           //Player������ϐ�
    //player script;                 //�X�N���v�g���Ăяo���ϐ�
    //PlayerControl Player;          //PlayerControl���擾
    Rigidbody2D rd;                //Rigidbody2D���擾
    /// //////////////////////////////////////////////
    // �X�^�[�g�ɌĂ΂��֐�
    void Start()
    {
        ///////////////////////////////////////////////////////
        //Player���I�u�W�F�N�g�̖��O����擾���ĕϐ��Ɋi�[����
        Player2D= GameObject.Find("Player");
        //Player�̒��ɂ���X�N���v�g�iPlayer�j���擾���ĕϐ��Ɋi�[����
        //Player = Player2D.GetComponent<PlayerControl>();
        //rd = Player2D.GetComponent<Rigidbody2D>();
        ///////////////////////////////////////////////////////
        //�e�X�g���O
        //Debug.Log("TEST�@Log");
    }

    // ���t���[�����ƂɌĂ΂��֐�
    void Update()
    {
        if(start_dame)
        {
            GameMainContol.Instance.Poison_Atk();
            start_dame = false;
        }
        //�L�����N�^�[���Ő��ɓ��������𔻒肷��
        if (update == true)
        {
            //�o�ߎ��Ԃ𐔂���
            countup += Time.deltaTime;
            //2�b�𒴂����ꍇ�ɓ���
            if (countup >= timeLimit)
            {
                StartCoroutine("Test");
                
                //�o�ߎ��Ԃ�\������
                //Debug.Log("2�b������");
                //�p���_���[�W��true�ɂ���B
                damege = true;
                //���Ԃ����Z�b�g����
                countup = 0.0f;
            }
            //Debug.Log("�_���[�W");
            //�_���[�W��^����
            if (damege == true)
            {
                
                GameMainContol.Instance.Poison_Atk();
                //�v���C���[�Ƀ_���[�W��^����
                Player_HP -= Player_damege;
                //�_���[�W�����������m�F���O
                //Debug.Log(Player_HP);
                //�����_���[�W��false�ɂ���
                damege = false;
            }
        }
    }
    //�����ʉ߂���������
    void OnTriggerEnter2D(Collider2D other2d)
    {
        //Debug.Log("��������");
        
        //�v���C���[���������Ă��邩�̔���
        if (other2d.gameObject.CompareTag("Player"))
        {
           // Player.debage = 500;
            Debug.Log("�v���C�₪�G�ꂽ");
            //�X�s�[�h�𔼕��ɂ���
            detspeed = 2;
            //�_���[�W��^����֐���true�ɂ���
            update = true;
            start_dame = true;
        }
    }
    //���̒ʉ߂��I�����������
    void OnTriggerExit2D(Collider2D other2d)
    {
       // Debug.Log("�o��");
        //�v���C���[���������Ă��邩�̔���
        if (other2d.gameObject.CompareTag("Player"))
        {
            //Player.debage = 1;
            //�X�s�[�h�����ɂ���
            detspeed = 1;
            //�_���[�W��^����֐���false�ɂ���
            update = false;

        } 
        //if (other2d.gameObject.CompareTag("Block")
        //    || other2d.gameObject.CompareTag("rfBlock")
        //    || other2d.gameObject.CompareTag("exBlock"))
        //{
        //    Debug.Log("�u���b�N");
        //    Destroy(other2d.gameObject);
         
        //}
    }
    
    
   IEnumerator Test()
    {
        XInputDotNetPure.GamePad.SetVibration(0, 0.1f, 0.1f);
        yield return new WaitForSeconds(0.5f);
        XInputDotNetPure.GamePad.SetVibration(0, 0, 0);
    }
  
}
