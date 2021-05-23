using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AttackControl : MonoBehaviour
{
    
    Rigidbody2D rd; //Rigidbodyオブジェクト
    float attspeed = 6.0f;  //オブジェクト移動スピード
    bool attacking = false; // 攻撃用のフラグ
    //GameObject tagPlayer_Objects; //代入用のゲームオブジェクト配列を用意 
    Vector2 Player_pos; // プレイヤーの場所取得関数
    Vector2 P_A_pos ;   // プレイヤーのプレイヤーの攻撃判定の場所取得関数
    public float A_range = 50;  // 攻撃範囲
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Player_pos = GameObject.Find("Player").transform.position;
        P_A_pos = this.transform.position;
        GameObject.Find("Player").transform.position = new Vector2(Player_pos.x,Player_pos.y);
    }

    void Update()    
    {
        Player_pos = GameObject.Find("Player").transform.position;
        P_A_pos = this.transform.position;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            attacking = true;
        }
        if(attacking)
            Attack();
    }
    private void Attack()
    {   float temp = Player_pos.x + A_range;
        float temp2 = Player_pos.x - A_range;
        transform.localPosition += (new Vector3(attspeed, 0));
        //Debug.Log("temp:" + temp);
        //Debug.Log("bullet" + P_A_pos.x);
        if((temp) < (P_A_pos.x)||(temp2) > (P_A_pos.x))
        {
            // Debug.Log("Hello");
            this.transform.position = new Vector2(Player_pos.x,Player_pos.y);
            attacking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        Destroy(collision.gameObject);    //攻撃オブジェクトの破棄
    }
}
