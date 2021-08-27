using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class golem : MonoBehaviour
{
    #region �錾
    //---public-------------------------------------------------------    
    public Transform attackPoint;
    public Transform breakPoint;
    public float attackRadius;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public int Golem_HP = 10; //enemy��HP
    public GameObject at;
    public GameObject bt;
    public GameObject ct;
    public GameObject dt;
    public int delay = 0; //Golem_Attack4�p�̕ϐ�
    public bool golem_attack2 = false;
    public bool golem_attack5 = false;
    public bool falling_rocks = false;
    //---private------------------------------------------------------
    [SerializeField]
    crush_range crush_Range;     //�@���ׂ��͈͂��擾
    [SerializeField]
    GameObject Cruch;
    private float crush_time = 0.0f;      //�@���ׂ����Ԃ̊m�F    
    private float crush_timeLimit = 5.0f; //�@���ׂ�����
    private Rigidbody2D rb = null;
    private float countup = 0.0f;       //���Ԃ𑪂�ϐ�
    private float timeLimit = 3.0f;     //���Ԃ̍ő�𑪂�ϐ�
    private bool canmove = false;
    private int randomdice;
    private int dicemax = 3;
    public float Noattacktime = 0.0f;  //���Ԃ𑪂�ϐ�
    private float NoattackLimit = 5.0f; //���Ԃ̍ő�𑪂�ϐ�
    private bool atk_cont = true;
    #endregion
    #region Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = Golem_HP;
        //�V��𗎂Ƃ�
        StartCoroutine("Test");
    }
    #endregion
    #region Update
    void Update()
    {
        //HP��7�������ꍇ
        if (Golem_HP <= 7 && !(golem_attack2))
        {
            atk_cont = false;
            golem_attack2 = true;
            Golem_Attack2();
        }
        //HP��4�������ꍇ
        else if (Golem_HP <= 4 && !(golem_attack5))
        {
            atk_cont = false;
            golem_attack5 = true;
            Golem_Attack5();
        }
        //�@���ׂ��������s���v�Z
        else if (crush_Range.contains)
        {
            crush_time += Time.deltaTime;
            if (crush_time > crush_timeLimit)
            {
                Golem_Attack1();
                crush_time = 0.0f;
                atk_cont = false;
            }
        }
        else
        {
            crush_time = 0.0f;
            atk_cont = true;
        }
        //�����e�̏����v�Z
        if (atk_cont)
        {
            if (delay == Golem_HP)
            {
                Noattacktime += Time.deltaTime;
                if (Noattacktime >= NoattackLimit)
                {

                    Golem_Attack4();
                    atk_cont = false;
                    Noattacktime = 0;
                }
            }
            else
            {
                atk_cont = true;
                delay = Golem_HP;
                Noattacktime = 0;
            }
        }
        else
        {
            delay = Golem_HP;
            Noattacktime = 0;
        }
        //���Η���
        if (falling_rocks)
        {
            falling_rocks = false;
            Golem_Attack3();
            atk_cont = false;
        }

    }
    #endregion
    #region �����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block_Atk")    //�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            Golem_HP -= 1;
            Debug.Log("�S�[�����_���[�W");
            if (Golem_HP < 0)
            {
                Debug.Log("�S�[�������S");
                //Destroy(gameObject, 2f);    //Destructor
                SceneManager.LoadScene("result");

            }

        }
    }
    #endregion
    #region �A�^�b�N����,�֐�����
    void Golem_Attack1() //�@���ׂ�
    {
        Debug.Log("�@���ׂ�");
        GameMainContol.Instance.golem_bool = true;
        // randomdice = (Random.Range(1, 10));
        Instantiate(Cruch, new Vector3(950, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(850, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(750, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(650, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(550, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(450, 700, 10), Quaternion.identity);

        atk_cont = true;
        Noattacktime = 0f;
        randomdice = Random.Range(1, 10);
        if (randomdice <= dicemax)
        {
            falling_rocks = true;
        }
    }
    void Golem_Attack2() //���j��P
    {
        //�U������
        GameMainContol.Instance.golem_bool = true;
        // randomdice = (Random.Range(1, 10));
        Instantiate(Cruch, new Vector3(950, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(850, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(750, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(650, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(550, 700, 10), Quaternion.identity);
        Instantiate(Cruch, new Vector3(450, 700, 10), Quaternion.identity);
        GameMainContol.Instance.addCrystal(2, 1, 3);
        atk_cont = true;
        Noattacktime = 0f;
    }
    void Golem_Attack3() //��Η���
    {
        //�w�肵�����W�Ɋ�΂𗎉�
        var d = Instantiate(dt) as GameObject;
        d.transform.position = new Vector2(-460, 940);
        d.GetComponent<Stone>().rf = true;
        var e = Instantiate(dt) as GameObject;
        e.transform.position = new Vector2(-600, 940);
        e.GetComponent<Stone>().wg = true;
        var f = Instantiate(dt) as GameObject;
        f.transform.position = new Vector2(250, 940);
        f.GetComponent<Stone>().rf = true;
        var g = Instantiate(dt) as GameObject;
        g.transform.position = new Vector2(750, 940);
        g.GetComponent<Stone>().ex = true;
        atk_cont = true;
    }
    void Golem_Attack4() //���j�C
    {

        StartCoroutine("ATK_Time");
        randomdice = Random.Range(1, 10);
        if (randomdice <= dicemax)
        {
            falling_rocks = true;
        }
    }
    void Golem_Attack5()//���j��P
    {
        StartCoroutine("_ATK_Time");
    }

    IEnumerator ATK_Time()
    {
        yield return new WaitForSeconds(1f);
        var c = Instantiate(ct) as GameObject;
        c.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        var a = Instantiate(at) as GameObject;
        a.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        var b = Instantiate(bt) as GameObject;
        b.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        atk_cont = true;

    }
    IEnumerator _ATK_Time()
    {
        yield return new WaitForSeconds(1f);
        var c = Instantiate(ct) as GameObject;
        c.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        var a = Instantiate(at) as GameObject;
        a.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        var b = Instantiate(bt) as GameObject;
        b.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        atk_cont = true;
        GameMainContol.Instance.addCrystal(2, 1, 3);
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        atk_cont = false;
        Golem_Attack3();
    }
    #endregion
}