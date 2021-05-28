using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float flap = 1000f;
    public float scroll = 5f;
    public float player_HP = 10;
    public Transform pouch; 
    public GameObject Block;
    public GameObject exBlock;
    public GameObject rfBlock;
    public GameObject wgBlock;
    private GameObject Player;
    private Vector2 Player_pos;

    private int S_B = 0;
    //rivate GameType m_game = GameType.m_game;
    bool jump = false;
    float attspeed = 6.0f;
    float direction = 0f;
    Rigidbody2D rb2d;
    Rigidbody2D rd;
    
    void Start()
    {
        Player_pos = GetComponent<Transform>().position;
        rb2d = GetComponent<Rigidbody2D>();
        rd = GetComponent<Rigidbody2D>();
    }

    // 物理演算をしたい場合はFixedUpdateを使うのが一般的
    void Update()
    {
        rd = GetComponent<Rigidbody2D>();
        // rb2d = GetComponent<Rigidbody2D>();
        Vector2 scale = transform.localScale;
       if(Input.GetKey(KeyCode.RightArrow))
        { 
            rb2d.MovePosition(new Vector3(transform.localPosition.x + speed, rd.position.y, 0)) ;
            //transform.Translate(speed, 0, 0);
            scale.x = 100;
            direction = 1f;
        }
       else if(Input.GetKey(KeyCode.LeftArrow))
       {
            rb2d.MovePosition(new Vector3(transform.localPosition.x - speed,rd.position.y, 0));
            //     transform.Translate(-speed, 0, 0);
            scale.x = -100;
            direction = -1f;
        }
       else
       {
           direction = 0f;
       }
        transform.localScale = scale;
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var Box_pos = new Vector2(Player.transform.position.x + 10,0);
            var BlockIn = Instantiate(Block) as GameObject; //プレハブの作成
            BlockIn.transform.position = Box_pos;
        }
        */
        if (Input.GetKeyDown(KeyCode.I))
        {
            S_B -= 1;
            if(S_B==-1)
            {
                S_B = 2;
            }

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            S_B += 1;
            if(S_B==2)
            {
                S_B = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch(S_B)
            {
                case 0:
                    //位置取得
                    var pos_EX = this.gameObject.transform.position;
                    //プレハブ用意
                    var exBlock_pos = Instantiate(exBlock) as GameObject;
                    //親子設定
                    exBlock_pos.transform.SetParent(pouch);
                    //座標に250プラス
                    exBlock_pos.transform.position = new Vector2(pos_EX.x + 150, pos_EX.y);
                    break;
                case 1:
                    //位置取得
                    var pos_RF = this.gameObject.transform.position;
                    //プレハブ用意
                    var rfBlock_pos = Instantiate(rfBlock) as GameObject;
                    //親子設定
                    rfBlock_pos.transform.SetParent(pouch);
                    //座標に250プラス
                    rfBlock_pos.transform.position = new Vector2(pos_RF.x + 150, pos_RF.y);
                    break;
                case 2:
                    //位置取得
                    var pos_WG = this.gameObject.transform.position;
                    //プレハブ用意
                    var wgBlock_pos = Instantiate(wgBlock) as GameObject;
                    //親子設定
                    wgBlock_pos.transform.SetParent(pouch);
                    //座標に250プラス
                    wgBlock_pos.transform.position = new Vector2(pos_WG.x + 150, pos_WG.y);
                    break;
                default:
                    break;

            }
            
            ////位置取得
            //var pos = this.gameObject.transform.position;
            ////プレハブ用意
            //var Block_pos = Instantiate(Block) as GameObject;
            ////親子設定
            //Block_pos.transform.SetParent(pouch);
            ////座標に250プラス
            //Block_pos.transform.position = new Vector2(pos.x + 150, pos.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
       {
           //位置取得
           var pos = this.gameObject.transform.position;
           //プレハブ用意
           var Block_pos = Instantiate(Block) as GameObject;
           //親子設定
           Block_pos.transform.SetParent(pouch);
           //座標に250プラス
           Block_pos.transform.position = new Vector2(pos.x + 150, pos.y);
       }
       if(Input.GetKeyDown(KeyCode.LeftShift))
       {
           rb2d.velocity = new Vector2(attspeed,0);
           
       }
       //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        //ジャンプ判定
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && jump == false)
        {
            //Debug.Log("NODA");
            rb2d.AddForce(Vector2.up * flap,ForceMode2D.Impulse);
            jump = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("mirror"))
        {
            
            jump = false;
        }
    }
}
// クラス継承