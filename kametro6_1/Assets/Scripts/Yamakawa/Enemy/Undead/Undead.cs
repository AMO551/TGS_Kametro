using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
public class Undead : MonoBehaviour
{
    #region �錾
    //---public-------------------------------------------------------    
    public float Undead_speed;      //���x
    public float gravity;           //�d��
    public bool move = false;       //�p���ړ��̔���
    public Transform attackPoint;   //
    public float attackRadius;      //
    public LayerMask playerLayer;   //
    GameObject Player;              //�v���C���[�錾
    //---private------------------------------------------------------
    [SerializeField]
    private int Undead_HP = 2; //enemy��HP
    //private int Undead_ATK = 4;//enemy�̍U����
    private Rigidbody2D rb = null;
    private bool rightTleftF = false;
    //private float countup = 0.0f; //���Ԃ𑪂�ϐ�
    //private float timeLimit = 0.5f;//���Ԃ̍ő�𑪂�ϐ�
    private bool dame = true;
    private float ATK_Time = 0.0f; //���Ԃ𑪂�ϐ�
    private float ATK_timeLimit = 2f;//���Ԃ̍ő�𑪂�ϐ�
    Animator animator;
    #endregion
    #region Start
    void Start()
    {
        //---protected----------------------------------------------------
        //Debug.Log("TEST�@Log");
        rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    #endregion
    #region Update
    private void Update()
    {
        #region ���t���[���Ăяo��
        Vector3 pv = Player.transform.position;
        Vector3 ev = transform.position;
        #endregion
        #region ����
        //����1.5���Ƀv���C���[������ꍇ�Ăяo�����
        if (pv.x - ev.x <= 150 && -150 <= pv.x - ev.x
            && pv.y - ev.y <= 150 && -150 <= pv.y - ev.y)
        {
            //Debug.Log("�A�^�b�N�͈͂ɓ�����");
            ATK_Time += Time.deltaTime;
            if (ATK_Time > ATK_timeLimit)
            {
                ATK_Time = 0;
                GameMainContol.Instance.HumanPlayerDamege();
                //�A�_�b�N
                Attack();
                //�A�j���[�V����
                this.animator.SetTrigger("Walk_Stop");
            }
        }
        //�v���C���[�̍��W���Ă�ł���
        else if ((pv.x - ev.x) <= 300 && -300 <= (pv.x - ev.x)
                && pv.y - ev.y <= 150 && -150 <= pv.y - ev.y)
        {
            float p_vX = pv.x - ev.x;
            float vx = 0f;
            float sp = 5f;
            // ���Z�������ʂ��}�C�i�X�ł����X�͌��Z����
            if (p_vX < 0)
            {
                vx = -sp;
                rb.AddForce(new Vector3(-100.0f, 0.0f, 0.0f));
                rightTleftF = false;
            }
            else
            {
                vx = sp;
                rb.AddForce(new Vector3(100.0f, 0.0f, 0.0f));
                rightTleftF = true;
            }
            transform.Translate(vx / 30, 0, 0);

            move = false;
            active();
        }
        //�G����ʓ��ɓ������^�C�~���O�ōs������
        else if ((pv.x - ev.x) <= 1000 && -1000 <= (pv.x - ev.x))
        {
            active();
        }
        //�v���C���[���߂��ɂ��Ȃ��ꍇ�~�܂�
        else
        {
            this.animator.SetTrigger("Walk_Stop");
            rb.Sleep();
        }

        #endregion
    }
    #endregion
    #region �����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block_Atk")    //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            if (dame)
            {
                Undead_HP -= 1;
                StartCoroutine("dame_time");
                Debug.Log("�A���f�b�h�_���[�W");

                //�f�[�^��n���������s��
                SoundManager.Instance.Play_SE(0, 11);
                if (Undead_HP <= 0)
                {
                    Debug.Log("�A���f�b�h���S");
                    Destroy(gameObject, 0.5f);    //Destructor
                }
            }

        }
        if (collision.gameObject.tag == "Wall")     //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Wall"�̏ꍇ
        {
            rightTleftF = !rightTleftF; //���]
        }
    }
    void OnCollisionEnter2D(Collision2D collision)//�Փ˂�����Ăяo����鏈��
    {
        if (collision.gameObject.tag == "Undead")    //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Enemy"�̏ꍇ
        {
            rightTleftF = !rightTleftF; //���]
        }
        if (collision.gameObject.tag == "Block")    //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            Destroy(collision.gameObject, 1f);    //Destructor


        }
    }
    #endregion
    #region �֐�����
    //�A�^�b�N
    void Attack()
    {
        SoundManager.Instance.Play_SE(3, 16);
        animator.SetTrigger("IsAttack");
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
        foreach (Collider2D hitPlayer in hitPlayers)
        {
            Debug.Log(hitPlayer.gameObject.name + "�ɍU��");
        }
    }
    //����
    void active()
    {
        this.animator.SetTrigger("Walk_start");
        animator.speed = 1.0f;
        float vx = 0f;
        float sp = 5f;
        if (rightTleftF)
        {
            vx = sp;
            transform.localScale = new Vector3(-100, 120, 1);
        }
        else
        {
            vx = -sp;
            transform.localScale = new Vector3(100, 120, 1);
        }
        transform.Translate(vx / 30, 0, 0);
    }
    //
    IEnumerator dame_time()
    {
        dame = false;
        yield return new WaitForSeconds(1.5f);
        dame = true;
    }
    #endregion
}



