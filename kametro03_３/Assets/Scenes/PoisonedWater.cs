using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedWater : MonoBehaviour
{
    //キャラクターのデバフの初期化
    public int detspeed = 1;       //プレイヤーの速度のデバフ
    public int Player_HP = 10;     //プレイヤーHPの確認
    public int Player_damege = 1;  //プレイヤーが当たったときのダメージ
    public bool damege = false;    //継続ダメージの判定
    //仮のプレイヤーHP
    private float countup = 0.0f;　//時間を測る変数
    private float timeLimit = 2.0f;//時間の最大を測る変数
    private bool update = false;   //プレイヤーが当たっているかの変数

    ///////////////////////////////////////////////////
    GameObject Player2D;           //Playerを入れる変数
    player script;                 //スクリプトを呼び出す変数
    /// //////////////////////////////////////////////
    // スタートに呼ばれる関数
    void Start()
    {
        ///////////////////////////////////////////////////////
        //Playerをオブジェクトの名前から取得して変数に格納する
        Player2D = GameObject.Find("Player");
        //Playerの中にあるスクリプト（Player）を取得して変数に格納する
        script = Player2D.GetComponent<player>();
        ///////////////////////////////////////////////////////
        //テストログ
        Debug.Log("TEST　Log");
    }

    // 毎フレームごとに呼ばれる関数
    void Update()
    {
        //int PlayHP = script.Player_hp;
        //キャラクターが毒水に入ったかを判定する
        if (update == true)
        {
            //経過時間を数える
            countup += Time.deltaTime;
            //2秒を超えた場合に入る
            if (countup >= timeLimit)
            {
                //経過時間を表示する
                Debug.Log("2秒たった");
                //継続ダメージをtrueにする。
                damege = true;
                //時間をリセットする
                countup = 0.0f;
            }
            //Debug.Log("ダメージ");
            //ダメージを与える
            if (damege == true)
            {
                //プレイヤーにダメージを与える
                Player_HP -= Player_damege;
                //ダメージが入ったか確認ログ
                Debug.Log(Player_HP);
                //持続ダメージをfalseにする
                damege = false;
            }
        }
    }
    //物が通過したか見る
    void OnTriggerEnter2D(Collider2D other2d)
    {
        Debug.Log("当たった");
        
        //プレイヤーが当たっているかの判定
        if (other2d.gameObject.CompareTag("Player"))
        {
         
            Debug.Log("プレイやが触れた");
            //スピードを半分にする
            detspeed = 2;
            //ダメージを与える関数をtrueにする
            update = true;

        }
    }
    //物の通過が終わったか見る
    void OnTriggerExit2D(Collider2D other2d)
    {
        Debug.Log("出た");
        //プレイヤーが当たっているかの判定
        if (other2d.gameObject.CompareTag("Player"))
        {
            //スピードを元にする
            detspeed = 1;
            //ダメージを与える関数をfalseにする
            update = false;

        }
    }


}
