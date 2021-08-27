using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期化
/// </summary>
public class Bomber : MonoBehaviour
{
    #region 宣言
    //---public-------------------------------------------------------    
    //インスペクターで設定する
    public float Bomber_speed; //速度の変数
    public float gravity; //重力の変数
    public int Bomber_HP = 0;    //enemyのHP
    public bool move = false;    //継続移動の判定
    [SerializeField] GameObject Player;
    //---private------------------------------------------------------
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    private float countup = 0.0f; //時間を測る変数
    private float timeLimit = 0.5f;//時間の最大を測る変数
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
        #region 毎フレーム呼び出す
        //プレイヤーの座標を呼んでくる
        Vector3 pv = Player.transform.position;
        Vector3 ev = transform.position;
        #endregion
        #region 動く処理
        //爆発を始める
        if ((pv.x - ev.x) <= 150 && -150 <= (pv.x - ev.x))
        {
            Bomber_speed = 0;
            Attack();
        }
        //プレイヤーを見つけた
        else if ((pv.x - ev.x) <= 700 && -700 <= (pv.x - ev.x))
        {

            //経過時間を数える
            countup += Time.deltaTime;
            //移動経過時間
            if (countup >= timeLimit)
            {
                //継続移動をtrueにする。
                move = true;
                //時間をリセットする
                countup = 0f;
            }
            //動く処理
            if (move == true)
            {
                float p_vX = pv.x - ev.x;
                float vx = 0f;
                float sp = 500f;
                Bomber_speed = 15;
                // 減算した結果がマイナスであればXは減算処理
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
        //動き出す
        else if ((pv.x - ev.x) <= 1000 && -1000 <= (pv.x - ev.x)) //敵が画面内に入ったタイミングで行動する
        {
            Debug.Log("移動開始");
            active();
        }
        //止まる
        else
        {
            rb.Sleep();
        }
        #endregion
    }
    #endregion
    #region 当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block_Atk")//条件式：衝突したオブジェクトのタグが"Block"の場合
        {
            Bomber_HP -= 1;
            Debug.Log("ボマーダメージ");
            if (Bomber_HP <= 0)
            {
                Debug.Log("ボマー死亡");
                Destroy(gameObject, 2f);    //Destructor
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)//衝突したら呼び出される処理
    {
        if (collision.gameObject.tag == "Undead")//条件式：衝突したオブジェクトのタグが"Player"の場合
        {
            rightTleftF = !rightTleftF;
        }
        if (collision.gameObject.tag == "Wall")//条件式：衝突したオブジェクトのタグが"Wall"の場合
        {
            rightTleftF = !rightTleftF;
        }
        if (collision.gameObject.tag == "Block")//条件式：衝突したオブジェクトのタグが"Block"の場合
        {
            Attack();
        }

    }
    #endregion
    #region 関数処理
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
        //ここに爆発関係のスクリプトぶち込んでクレメンス



    }
    #endregion
}