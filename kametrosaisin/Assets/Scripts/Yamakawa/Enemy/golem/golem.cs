using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class golem : MonoBehaviour
{
    #region éŒ¾
    //---public-------------------------------------------------------    
    public Transform attackPoint;
    public Transform breakPoint;
    public float attackRadius;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public int Golem_HP = 10; //enemy‚ÌHP
    public GameObject at;
    public GameObject bt;
    public GameObject ct;
    public GameObject dt;
    public int delay = 0; //Golem_Attack4—p‚Ì•Ï”
    public bool golem_attack2 = false;
    public bool golem_attack5 = false;
    public bool falling_rocks = false;
    //---private------------------------------------------------------
    [SerializeField]
    crush_range crush_Range;     //’@‚«’×‚·”ÍˆÍ‚ğæ“¾
    [SerializeField]
    GameObject Cruch;
    private float crush_time = 0.0f;      //’@‚«’×‚·ŠÔ‚ÌŠm”F    
    private float crush_timeLimit = 5.0f; //’@‚«’×‚·ŠÔ
    private Rigidbody2D rb = null;
    private float countup = 0.0f;       //ŠÔ‚ğ‘ª‚é•Ï”
    private float timeLimit = 3.0f;     //ŠÔ‚ÌÅ‘å‚ğ‘ª‚é•Ï”
    private bool canmove = false;
    private int randomdice;
    private int dicemax = 3;
    public float Noattacktime = 0.0f;  //ŠÔ‚ğ‘ª‚é•Ï”
    private float NoattackLimit = 5.0f; //ŠÔ‚ÌÅ‘å‚ğ‘ª‚é•Ï”
    private bool atk_cont = true;
    #endregion
    #region Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = Golem_HP;
        //“Vˆä‚ğ—‚Æ‚·
        StartCoroutine("Test");
    }
    #endregion
    #region Update
    void Update()
    {
        //HP‚ª7‚¾‚Á‚½ê‡
        if (Golem_HP <= 7 && !(golem_attack2))
        {
            atk_cont = false;
            golem_attack2 = true;
            Golem_Attack2();
        }
        //HP‚ª4‚¾‚Á‚½ê‡
        else if (Golem_HP <= 4 && !(golem_attack5))
        {
            atk_cont = false;
            golem_attack5 = true;
            Golem_Attack5();
        }
        //’@‚«’×‚·ˆ—‚ğs‚¤ŒvZ
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
        //”š”­’e‚Ìˆ—ŒvZ
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
        //—Î—‰º
        if (falling_rocks)
        {
            falling_rocks = false;
            Golem_Attack3();
            atk_cont = false;
        }

    }
    #endregion
    #region “–‚½‚è”»’è
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block_Atk")    //ğŒ®FÕ“Ë‚µ‚½ƒIƒuƒWƒFƒNƒg‚Ìƒ^ƒO‚ª"Block"‚Ìê‡
        {
            Golem_HP -= 1;
            Debug.Log("ƒS[ƒŒƒ€ƒ_ƒ[ƒW");
            if (Golem_HP < 0)
            {
                Debug.Log("ƒS[ƒŒƒ€€–S");
                //Destroy(gameObject, 2f);    //Destructor
                SceneManager.LoadScene("result");

            }

        }
    }
    #endregion
    #region ƒAƒ^ƒbƒNˆ—,ŠÖ”ˆ—
    void Golem_Attack1() //’@‚«’×‚·
    {
        Debug.Log("’@‚«’×‚·");
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
    void Golem_Attack2() //°”j‰ó‚P
    {
        //UŒ‚§ŒÀ
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
    void Golem_Attack3() //ŠâÎ—‰º
    {
        //w’è‚µ‚½À•W‚ÉŠâÎ‚ğ—‰º
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
    void Golem_Attack4() //”š”j–C
    {

        StartCoroutine("ATK_Time");
        randomdice = Random.Range(1, 10);
        if (randomdice <= dicemax)
        {
            falling_rocks = true;
        }
    }
    void Golem_Attack5()//°”j‰ó‚P
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