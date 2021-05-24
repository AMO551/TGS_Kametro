using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
public abstract class Bomber: MonoBehaviour
{
    //---public-------------------------------------------------------    
    //�C���X�y�N�^�[�Őݒ肷��
    public int Bomber_HP = 0; //enemy��HP
    public bool move = false;    //�p���ړ��̔���
                                 //---private------------------------------------------------------
    private Rigidbody2D rb = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private float countup = 0.0f; //���Ԃ𑪂�ϐ�
    private float timeLimit = 0.5f;//���Ԃ̍ő�𑪂�ϐ�
                                   //---protected----------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    void Update()
    {
        Vector3 pv = player.transform.position;
        Vector3 ev = transform.position;
        if (pv.x - ev.x <= 7 && -7 >= pv.x - ev.x)
        {
            //�o�ߎ��Ԃ𐔂���
            countup += Time.deltaTime;
            if (countup >= timeLimit)
            {
                //�o�ߎ��Ԃ�\������
                Debug.Log("2�b������");
                //�p���ړ���true�ɂ���B
                move = true;
                //���Ԃ����Z�b�g����
                countup = 0f;
            }
            if (move == true)
            {

                float p_vX = pv.x - ev.x;
                float p_vY = pv.y - ev.y;

                float vx = 0f;
                float vy = 0f;

                float sp = 1f;

                // ���Z�������ʂ��}�C�i�X�ł����X�͌��Z����
                if (p_vX < 0)
                {
                    vx = -sp;
                }
                else
                {
                    vx = sp;
                }

                // ���Z�������ʂ��}�C�i�X�ł����Y�͌��Z����
                if (p_vY < 0)
                {
                    vy = -sp;
                }
                else
                {
                    vy = sp;
                }

                transform.Translate(vx / 30, vy / 30, 0);

                move = false;
            }

        }
        void OnCollisionEnter2D(Collision2D collision)//�Փ˂�����Ăяo����鏈��
        {
            if (collision.gameObject.tag == "Player")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Player"�̏ꍇ
            {
                Debug.Log("�v���C���[�̓_���[�W���󂯂�");
            }
            if (collision.gameObject.tag == "Enemy")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Player"�̏ꍇ
            {
                rightTleftF = !rightTleftF;
            }
            if (collision.gameObject.tag == "Wall")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Wall"�̏ꍇ
            {
                rightTleftF = !rightTleftF;
            }
            if (collision.gameObject.tag == "Block")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
            {
                Bomber_HP -= 1;
                Debug.Log("�{�}�[�_���[�W");
                if (Bomber_HP < 0)
                {
                    Debug.Log("�{�}�[���S");
                    Destroy(gameObject, 2f);
                }

            }
        }
    }
}

