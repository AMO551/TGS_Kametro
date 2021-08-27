using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
public class Bomber : MonoBehaviour
{
    #region �錾
    //---public-------------------------------------------------------    
    //�C���X�y�N�^�[�Őݒ肷��
    public float Bomber_speed; //���x�̕ϐ�
    public float gravity; //�d�͂̕ϐ�
    public int Bomber_HP = 0;    //enemy��HP
    public bool move = false;    //�p���ړ��̔���
    [SerializeField] GameObject Player;
    //---private------------------------------------------------------
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    private float countup = 0.0f; //���Ԃ𑪂�ϐ�
    private float timeLimit = 0.5f;//���Ԃ̍ő�𑪂�ϐ�
    private Vector3 Pos;
    #endregion
    #region Start
    void Start()
    {
        //---protected----------------------------------------------------
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    #endregion
    #region Update
    void Update()
    {
        #region ���t���[���Ăяo��
        //�v���C���[�̍��W���Ă�ł���
        Vector3 pv = Player.transform.position;
        Vector3 ev = transform.position;
        #endregion
        #region ��������
        //�������n�߂�
        if ((pv.x - ev.x) <= 150 && -150 <= (pv.x - ev.x))
        {
            Bomber_speed = 0;
            Attack();
        }
        //�v���C���[��������
        else if ((pv.x - ev.x) <= 700 && -700 <= (pv.x - ev.x))
        {

            //�o�ߎ��Ԃ𐔂���
            countup += Time.deltaTime;
            //�ړ��o�ߎ���
            if (countup >= timeLimit)
            {
                //�p���ړ���true�ɂ���B
                move = true;
                //���Ԃ����Z�b�g����
                countup = 0f;
            }
            //��������
            if (move == true)
            {
                float p_vX = pv.x - ev.x;
                float vx = 0f;
                float sp = 500f;
                Bomber_speed = 15;
                // ���Z�������ʂ��}�C�i�X�ł����X�͌��Z����
                if (p_vX < 0)
                {
                    vx = -sp;
                    rb.AddForce(new Vector3(-500.0f, 0.0f, 0.0f));
                    rightTleftF = false;
                }
                else
                {
                    vx = sp;
                    rb.AddForce(new Vector3(500.0f, 0.0f, 0.0f));
                    rightTleftF = true;
                }
                active();
            }

        }
        //�����o��
        else if ((pv.x - ev.x) <= 1000 && -1000 <= (pv.x - ev.x)) //�G����ʓ��ɓ������^�C�~���O�ōs������
        {
            Debug.Log("�ړ��J�n");
            active();
        }
        //�~�܂�
        else
        {
            rb.Sleep();
        }
        #endregion
    }
    #endregion
    #region �����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block_Atk")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            Bomber_HP -= 1;
            Debug.Log("�{�}�[�_���[�W");
            if (Bomber_HP <= 0)
            {
                Debug.Log("�{�}�[���S");
                Destroy(gameObject, 2f);    //Destructor
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)//�Փ˂�����Ăяo����鏈��
    {
        if (collision.gameObject.tag == "Undead")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Player"�̏ꍇ
        {
            rightTleftF = !rightTleftF;
        }
        if (collision.gameObject.tag == "Wall")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Wall"�̏ꍇ
        {
            rightTleftF = !rightTleftF;
        }
        if (collision.gameObject.tag == "Block")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            Attack();
        }

    }
    #endregion
    #region �֐�����
    void active()
    {
        float vx = 0f;
        float sp = 5f;
        if (rightTleftF)
        {
            vx = sp;
            transform.localScale = new Vector3(-80, 80, 1);
        }
        else
        {
            vx = -sp;
            transform.localScale = new Vector3(80, 80, 1);
        }
        transform.Translate(vx / 30, 0, 0);
    }
    void Attack()
    {
        //�����ɔ����֌W�̃X�N���v�g�Ԃ�����ŃN�������X



    }
    #endregion
}