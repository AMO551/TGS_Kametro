using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class golem : MonoBehaviour
{
    #region �錾
    //---public-------------------------------------------------------    
    public Transform attackPoint;
    public Transform breakPoint;
    public float attackRadius;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public int Golem_HP = 30; //enemy��HP
    public GameObject at;
    public GameObject bt;
    public GameObject ct;
    public GameObject dt;
    public int delay = 0; //Golem_Attack4�p�̕ϐ�
    //---private------------------------------------------------------
    private Rigidbody2D rb = null;
    private float countup = 0.0f;       //���Ԃ𑪂�ϐ�
    private float timeLimit = 3.0f;     //���Ԃ̍ő�𑪂�ϐ�
    private bool canmove = false;
    private int randomdice;
    private int dicemax = 3;
    private float Noattacktime = 0.0f;  //���Ԃ𑪂�ϐ�
    private float NoattackLimit = 5.0f; //���Ԃ̍ő�𑪂�ϐ�
    private bool atk_cont = true;
    #endregion
    #region Start
    void Start()
    {
        //�e�X�g���O
        //Debug.Log("TEST�@Log");
        //---protected-----=----------------------------------------------
        rb = GetComponent<Rigidbody2D>();
        delay = Golem_HP;
    }
    #endregion
    #region Update
    void Update()
    {
        if (atk_cont)
        {
            atk_cont = false;
            if (delay == Golem_HP)
            {
                Noattacktime += Time.deltaTime;
                if (Noattacktime >= NoattackLimit)
                {
                    Golem_Attack4();
                    Noattacktime = 0;
                }
            }
            else
            {
                delay = Golem_HP;
                Noattacktime = 0;
            }
            if (countup >= 3.0f)
            {
                countup += Time.deltaTime;
            }
            if (countup >= timeLimit)
            {
                canmove = true;
            }
            if (canmove == true)
            {
                Golem_Attack3();
                Destroy(dt, 10f);
            }
            if (randomdice <= dicemax)
            {
                Golem_Attack3();
                randomdice = 10;
                Destroy(dt, 10f);
            }

            if (Golem_HP <= 20)
            {
                Golem_Attack2();
            }

            if (Golem_HP <= 10)
            {
                Golem_Attack5();
            }
            StartCoroutine("ATK_Time");
        }

    }
    #endregion
    #region �����蔻��
    void OnCollisionEnter2D(Collision2D collision)  //�Փ˂�����Ăяo����鏈��
    {
        if (collision.gameObject.tag == "range")    //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"range"�̏ꍇ
        {
            Golem_Attack1();
        }
        if (collision.gameObject.tag == "Block")    //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            Golem_HP -= 1;
            Debug.Log("�S�[�����_���[�W");
            if (Golem_HP < 0)
            {
                Debug.Log("�S�[�������S");
                Destroy(gameObject, 2f);    //Destructor
            }

        }
    }
    #endregion
    #region �A�^�b�N����,�֐�����
    void Golem_Attack1() //�@���ׂ�
    {
        //animator.SeTrigger("IsAttack");
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
        foreach (Collider2D hitPlayer in hitPlayers)
        {
            Debug.Log(hitPlayer.gameObject.name + "�ɍU��");
            //�v���C���[��HP���Ă�ł���
            //script.Player_hp -= 2;
            randomdice = (Random.Range(1, 10));
        }
    }
    void Golem_Attack2() //���j��P
    {   //�@���ׂ��̋����Ɠ���
        Collider2D[] hittiles = Physics2D.OverlapCircleAll(breakPoint.position, attackRadius, groundLayer);
        foreach (Collider2D hittile in hittiles)
        {
            var destroy = GameObject.FindGameObjectsWithTag("ground");
            foreach (var destroys in destroy)
            {
                Destroy(destroys);
                Debug.Log(hittile.gameObject.name + "��j��");
            }

            Debug.Log(hittile.gameObject.name + "�ɍU��");
            //�v���C���[��HP���Ă�ł���
            //script.Player_hp -= 2;
        }
    }
    void Golem_Attack3() //��Η���
    {
        //�w�肵�����W�Ɋ�΂𗎉�
        var d = Instantiate(dt) as GameObject;
        d.transform.position = new Vector2(-460, 940);

        var e = Instantiate(dt) as GameObject;
        e.transform.position = new Vector2(-600, 940);

        var f = Instantiate(dt) as GameObject;
        e.transform.position = new Vector2(250, 940);

        var g = Instantiate(dt) as GameObject;
        g.transform.position = new Vector2(750, 940);
    }
    void Golem_Attack4() //���j�C
    {
        //GameObject obj = (GameObject)Resources.Load("tama");
        var a = Instantiate(at) as GameObject;
        a.transform.position = this.gameObject.transform.position;

        var b = Instantiate(bt) as GameObject;
        b.transform.position = this.gameObject.transform.position;

        var c = Instantiate(ct) as GameObject;
        c.transform.position = this.gameObject.transform.position;
        //c.transform.SetParent(this.transform);

        randomdice = (Random.Range(1, 10));
        Debug.Log(randomdice);
    }
    void Golem_Attack5()
    {
        Golem_Attack4();
    }
    IEnumerator ATK_Time()
    {
        yield return new WaitForSeconds(5f);
        atk_cont = true;
    }
    #endregion
}

