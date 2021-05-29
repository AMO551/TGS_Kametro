using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    //pulic-----------------------
    //回復の初期化
    public float recovete = 0;
    //回復の最大値
    public int Max_HP = 10;

    //private--------------------
    //アップデートの初期化（false）
    private bool Updeta = false;
    //プレイヤーの呼び出し

    private int Player_HP = 0;
    //キャラクターのHPを取得


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
                recovete = 1;
                //今あるブロックを消す
                Destroy(gameObject);
                //Debug.Log(recovete);
                //回復したらPlayerのようでrecoveteをOにする
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
            //ダメージを与える関数をtrueにする
            Updeta = true;

        }
    }

}