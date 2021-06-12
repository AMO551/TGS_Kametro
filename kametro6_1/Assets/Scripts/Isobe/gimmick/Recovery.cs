using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    //pulic-----------------------
    //回復の初期化
    public float recovete = 30;
    //回復の最大値
    public int Max_HP = 100;
    //ブロック回復ブール
    public bool block =false;
    //private--------------------
    //アップデートの初期化（false）
    private bool Updeta = false;
    //プレイヤーの呼び出し

    private int Player_HP = 50;
    //キャラクターのHPを取得
    private int huri_HP=0;　//ふり幅を見る


    // Start is called before the first frame update
    void Start()
    {
        //キャラクターのHPをPlayer_HPに初期化する
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerのHPを引っ張ってくる

        //Player_HPをアップデートしていく
        if (Updeta == true)
        {
            //プレイヤーがHPマックスじゃなかった場合
            if (Player_HP <= Max_HP)
            {
                //回復をするする
                recovete = 30;
                Player_HP += 30;
                //今あるブロックを消す
                Destroy(gameObject);
                //Debug.Log(recovete);
                //回復したらPlayerのようでrecoveteをOにする
            }
            //HPのふり幅が１００以上か確認
            if(Player_HP>=Max_HP)
            {
                //ふり幅がいくつか確認
                huri_HP = Max_HP - Player_HP;
                //ふり幅を見てHPを１００に戻す
                Player_HP -= huri_HP;

            }
            //アップデートをfalseにする
            Updeta = false;
        }
        else
        {
            //回復をやめる
            recovete = 0;
            //Debug.Log(recovete);
        }

    }
    //物が通過したか見る
    void OnTriggerEnter2D(Collider2D other2d)
    {
        //プレイヤーが当たっているかの判定
        if (other2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("回復した。");
            //ブロックの回復
            block = true;
            //ダメージを与える関数をtrueにする
            Updeta = true;

        }
    }

}