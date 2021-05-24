using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期化
/// </summary>
public abstract class Undead : MonoBehaviour
{
    //---public-------------------------------------------------------    
    //インスペクターで設定する

    public float Undead_speed; //速度
    public float gravity; //重力
    public bool move = false;    //継続移動の判定
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask playerLayer;
    //---private------------------------------------------------------
    private int Undead_HP = 2; //enemyのHP
    private int Undead_ATK = 4;//enemyの攻撃力
    private Rigidbody2D rb = null;
    private BoxCollider2D col = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    private float countup = 0.0f; //時間を測る変数
    private float timeLimit = 0.5f;//時間の最大を測る変数
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
        //プレイヤーの座標を呼んでくる
        Vector3 pv = player.transform.position;
        Vector3 ev = transform.position;
        if (pv.x - ev.x <= 3 && -3 >= pv.x - ev.x)
        {
            //経過時間を数える
            countup += Time.deltaTime;
            if (countup >= timeLimit)
            {
                //経過時間を表示する
                Debug.Log("2秒たった");
                //継続移動をtrueにする。
                move = true;
                //時間をリセットする
                countup = 0f;
            }
            if (move == true)
            {

                float p_vX = pv.x - ev.x;
                float p_vY = pv.y - ev.y;

                float vx = 0f;
                float vy = 0f;

                float sp = 1f;

                // 減算した結果がマイナスであればXは減算処理
                if (p_vX < 0)
                {
                    vx = -sp;
                }
                else
                {
                    vx = sp;
                }

                // 減算した結果がマイナスであればYは減算処理
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

        //敵が画面内に入ったタイミングで行動する
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
            //unity側で数値を変えられる    
            rb.velocity = new Vector2(xVector * Undead_speed, -gravity);
        }
        else
        {
            rb.Sleep();
        }
        //周囲1.5内にプレイヤーがいる場合呼び出される
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
                Debug.Log(hitPlayer.gameObject.name + "に攻撃");
                //プレイヤーのHPを呼んでくる
                (Player_HP -= Undead_ATK);

            }
        }
        void OnCollisionEnter2D(Collision2D collision)//衝突したら呼び出される処理
        {
            if (collision.gameObject.tag == "Player")//条件式：衝突したオブジェクトのタグが"Player"の場合
            {
                Debug.Log("プレイヤーはダメージを受けた");
            }
            if (collision.gameObject.tag == "Enemy")//条件式：衝突したオブジェクトのタグが"Enemy"の場合
            {
                rightTleftF = !rightTleftF;
            }
            if (collision.gameObject.tag == "Wall")//条件式：衝突したオブジェクトのタグが"Wall"の場合
            {
                rightTleftF = !rightTleftF;
            }
            if (collision.gameObject.tag == "Block")//条件式：衝突したオブジェクトのタグが"Block"の場合
            {
                Undead_HP -= 1;
                Debug.Log("アンデッドダメージ");
                if (Undead_HP < 0)
                {
                    Debug.Log("アンデッド死亡");
                    Destroy(gameObject, 2f);
                }

            }
        }
    }
}

