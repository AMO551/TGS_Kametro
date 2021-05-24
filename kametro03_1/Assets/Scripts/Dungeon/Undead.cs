using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
public abstract class Undead : MonoBehaviour
{
    //---public-------------------------------------------------------    
    //�C���X�y�N�^�[�Őݒ肷��

    public float Undead_speed; //���x
    public float gravity; //�d��
    public bool move = false;    //�p���ړ��̔���
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask playerLayer;
    //---private------------------------------------------------------
    private int Undead_HP = 2; //enemy��HP
    private int Undead_ATK = 4;//enemy�̍U����
    private Rigidbody2D rb = null;
    private BoxCollider2D col = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    private float countup = 0.0f; //���Ԃ𑪂�ϐ�
    private float timeLimit = 0.5f;//���Ԃ̍ő�𑪂�ϐ�
                                   //---protected----------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    void Update()
    {
        //�v���C���[�̍��W���Ă�ł���
        Vector3 pv = player.transform.position;
        Vector3 ev = transform.position;
        if (pv.x - ev.x <= 3 && -3 >= pv.x - ev.x)
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

        //�G����ʓ��ɓ������^�C�~���O�ōs������
        else
        if (sr.isVisible)
        {
            int xVector = -1;
            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            //unity���Ő��l��ς�����    
            rb.velocity = new Vector2(xVector * Undead_speed, -gravity);
        }
        else
        {
            rb.Sleep();
        }
        //����1.5���Ƀv���C���[������ꍇ�Ăяo�����
        if (pv.x - ev.x <= 1.5 && -1.5 >= pv.x - ev.x)
        {
            Attack();
        }
        void Attack()
        {
            //animator.SeTrigger("IsAttack");
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
            foreach (Collider2D hitPlayer in hitPlayers)
            {
                Debug.Log(hitPlayer.gameObject.name + "�ɍU��");
                //�v���C���[��HP���Ă�ł���
                (Player_HP -= Undead_ATK);

            }
        }
        void OnCollisionEnter2D(Collision2D collision)//�Փ˂�����Ăяo����鏈��
        {
            if (collision.gameObject.tag == "Player")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Player"�̏ꍇ
            {
                Debug.Log("�v���C���[�̓_���[�W���󂯂�");
            }
            if (collision.gameObject.tag == "Enemy")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Enemy"�̏ꍇ
            {
                rightTleftF = !rightTleftF;
            }
            if (collision.gameObject.tag == "Wall")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Wall"�̏ꍇ
            {
                rightTleftF = !rightTleftF;
            }
            if (collision.gameObject.tag == "Block")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
            {
                Undead_HP -= 1;
                Debug.Log("�A���f�b�h�_���[�W");
                if (Undead_HP < 0)
                {
                    Debug.Log("�A���f�b�h���S");
                    Destroy(gameObject, 2f);
                }

            }
        }
    }
}

