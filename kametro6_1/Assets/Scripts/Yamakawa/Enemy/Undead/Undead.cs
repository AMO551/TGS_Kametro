using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期化
/// </summary>
public class Undead : MonoBehaviour
{
    #region 宣言
    //---public-------------------------------------------------------    
    public float Undead_speed;      //速度
    public float gravity;           //重力
    public bool move = false;       //継続移動の判定
    public Transform attackPoint;   //
    public float attackRadius;      //
    public LayerMask playerLayer;   //
    GameObject Player;              //プレイヤー宣言
    //---private------------------------------------------------------
    [SerializeField]
    private int Undead_HP = 2; //enemyのHP
    //private int Undead_ATK = 4;//enemyの攻撃力
    private Rigidbody2D rb = null;
    private bool rightTleftF = false;
    //private float countup = 0.0f; //時間を測る変数
    //private float timeLimit = 0.5f;//時間の最大を測る変数
    private bool dame = true;
    private float ATK_Time = 0.0f; //時間を測る変数
    private float ATK_timeLimit = 2f;//時間の最大を測る変数
    Animator animator;
    #endregion
    #region Start
    void Start()
    {
        //---protected----------------------------------------------------
        //Debug.Log("TEST　Log");
        rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    #endregion
    #region Update
    private void Update()
    {
        #region 毎フレーム呼び出す
        Vector3 pv = Player.transform.position;
        Vector3 ev = transform.position;
        #endregion
        #region 動く
        //周囲1.5内にプレイヤーがいる場合呼び出される
        if (pv.x - ev.x <= 150 && -150 <= pv.x - ev.x
            && pv.y - ev.y <= 150 && -150 <= pv.y - ev.y)
        {
            //Debug.Log("アタック範囲に入った");
            ATK_Time += Time.deltaTime;
            if (ATK_Time > ATK_timeLimit)
            {
                ATK_Time = 0;
                GameMainContol.Instance.HumanPlayerDamege();
                //アダック
                Attack();
                //アニメーション
                this.animator.SetTrigger("Walk_Stop");
            }
        }
        //プレイヤーの座標を呼んでくる
        else if ((pv.x - ev.x) <= 300 && -300 <= (pv.x - ev.x)
                && pv.y - ev.y <= 150 && -150 <= pv.y - ev.y)
        {
            float p_vX = pv.x - ev.x;
            float vx = 0f;
            float sp = 5f;
            // 減算した結果がマイナスであればXは減算処理
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
        //敵が画面内に入ったタイミングで行動する
        else if ((pv.x - ev.x) <= 1000 && -1000 <= (pv.x - ev.x))
        {
            active();
        }
        //プレイヤーが近くにいない場合止まる
        else
        {
            this.animator.SetTrigger("Walk_Stop");
            rb.Sleep();
        }

        #endregion
    }
    #endregion
    #region 当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block_Atk")    //条件式：衝突したオブジェクトのタグが"Block"の場合
        {
            if (dame)
            {
                Undead_HP -= 1;
                StartCoroutine("dame_time");
                Debug.Log("アンデッドダメージ");

                //データを渡す処理を行う
                SoundManager.Instance.Play_SE(0, 11);
                if (Undead_HP <= 0)
                {
                    Debug.Log("アンデッド死亡");
                    Destroy(gameObject, 0.5f);    //Destructor
                }
            }

        }
        if (collision.gameObject.tag == "Wall")     //条件式：衝突したオブジェクトのタグが"Wall"の場合
        {
            rightTleftF = !rightTleftF; //反転
        }
    }
    void OnCollisionEnter2D(Collision2D collision)//衝突したら呼び出される処理
    {
        if (collision.gameObject.tag == "Undead")    //条件式：衝突したオブジェクトのタグが"Enemy"の場合
        {
            rightTleftF = !rightTleftF; //反転
        }
        if (collision.gameObject.tag == "Block")    //条件式：衝突したオブジェクトのタグが"Block"の場合
        {
            Destroy(collision.gameObject, 1f);    //Destructor


        }
    }
    #endregion
    #region 関数処理
    //アタック
    void Attack()
    {
        SoundManager.Instance.Play_SE(3, 16);
        animator.SetTrigger("IsAttack");
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
        foreach (Collider2D hitPlayer in hitPlayers)
        {
            Debug.Log(hitPlayer.gameObject.name + "に攻撃");
        }
    }
    //歩く
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



