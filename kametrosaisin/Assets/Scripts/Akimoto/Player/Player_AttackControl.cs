using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AttackControl : MonoBehaviour
{
    #region 宣言
    // Rigidbody取得変数
    private Rigidbody2D rb2d;
    private Transform this_transform;
    // オブジェクト移動スピード
    public float addspeed = 6.0f;
    // 攻撃用のフラグ
    bool attacking = false;
    // プレイヤーのプレイヤーの攻撃判定の場所取得変数
    Vector2 player_Attack_Position;
    // プレイヤーの今の座標を取得を取得する為の変数
    private Vector2 now_Player_position;
    // 攻撃範囲
    public float attack_Range = 5;
    // プレイヤーの攻撃クールタイム
    private float plyaer_Attack_Time;
    // Player取得変数
    public GameObject player;
    public KeyControlScript keyControlScript;
    private float direction;
    // 攻撃クールタイム用のフラグ
    private bool attacking_flag = true;
    // 攻撃クールタイム
    public float attacking_cool_time = 1.0f;
    public bool attack_se_flag = false;
    public float attack_se_count = 0;
    #endregion
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        this_transform = this.GetComponent<Transform>();
    }

    void Update()
    {
        if(attacking_flag)
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            if (Input.GetKeyDown("joystick button 1"))
            {
                attacking = true;
                if (attack_se_count == 0)
                {
                    SoundManager.Instance.Play_SE(0, 1);
                    attack_se_count += 1;
                }
            }
        }
        if (attacking)
            Attack();
    }
    //アタック
    private void Attack()
    {
        keyControlScript.player_atk();
        direction = keyControlScript.direction;
        // プレイヤーの今の座標を取得
        now_Player_position = player.transform.position;
        // 自分の最初の場所を記憶
        player_Attack_Position = this.transform.position;
        // 攻撃範囲の設定(+)
        float over_x_position = now_Player_position.x + attack_Range;
        // 攻撃範囲の設定(-)
        float under_x_position = now_Player_position.x - attack_Range;
        // オブジェクトを移動
        this.transform.position += new Vector3(addspeed * direction, 0, 0);
        //Debug.Log(player_Attack_Position);
        // オブジェクトを進み過ぎたら戻す
        if ((over_x_position) <= (this.transform.position.x) || (under_x_position) >= (this.transform.position.x))
        {
            this.transform.position = new Vector2(now_Player_position.x, now_Player_position.y);
            StartCoroutine(Attack_CoolTime());
            attacking = false;
            attacking_flag = false;
        }
        // 一定の時間後に
        IEnumerator Attack_CoolTime()
        {
            yield return new WaitForSeconds(attacking_cool_time);
            attacking_flag = true;
            attack_se_count = 0;
        }
    }
}