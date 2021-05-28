using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
   
    public float ore_a = 0;          //鉱石Aの初期化
    public float ore_b = 0;          //鉱石Bの初期化
    public float ore_c = 0;          //鉱石Cの初期化
    public float ore_d = 0;          //鉱石Dの初期化
    private bool Updeta = false;     //アップデートをfalseに初期化
    private bool Ore_A = false;      //鉱石Aのfalseに初期化
    private bool Ore_B = false;      //鉱石Aのfalseに初期化
    private bool Ore_C = false;      //鉱石Aのfalseに初期化
    private bool Ore_D = false;      //鉱石Aのfalseに初期化

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player_HPをアップデートしていく
        if (Updeta == true)
        {
            //鉱石Aが処理されているか見る
            if (Ore_A == true)
            {
                ore_a = 1;　　　//反射鉱石1個与える
                ore_b = 2;      //重力鉱石2個与える
                Ore_A = false;  //A鉱石
            }
            //鉱石Bが処理されているか見る
            if (Ore_B == true)
            {
                ore_a = 2;      //反射鉱石2個与える
                ore_b = 1;      //重力鉱石1個与える
                Ore_B = false;  //B鉱石
            }
            //鉱石Cが処理されているか見る
            if (Ore_C == true)
            {
                ore_a = 1;      //反射鉱石1個与える
                ore_b = 3;      //重力鉱石3個与える
                Ore_C = false;  //C鉱石
            }
            //鉱石Dが処理されているか見る
            if (Ore_D == true)
            {
                ore_a = 3;      //反射鉱石3個与える
                ore_b = 1;      //重力鉱石1個与える
                Ore_D = false;  //D鉱石
            }
            Updeta = false;     //updateのfalseにする
        }
        else
        {
            ore_a = 0;          //Aの鉱石の受け渡しを初期に戻す
            ore_b = 0;          //Bの鉱石の受け渡しを初期に戻す
            ore_c = 0;          //Cの鉱石の受け渡しを初期に戻す
            ore_d = 0;          //Dの鉱石の受け渡しを初期に戻す
        }

    }
    //物が通過したか見る
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        //Debug.Log("物にあたった");
        //プレイヤーが当たっているかの判定
        if (collision2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("プレイヤーを確認");
            //どの鉱石をたたいたのかの判定（A鉱石）
            if (gameObject.CompareTag("Ore_A"))
            {
                //鉱石を消す
                Destroy(gameObject);
                //鉱石Aをtrueにする
                Ore_A = true;
                //Updataをtrueにする
                Updeta = true;
                Debug.Log("Ore_Aを確認");
            }
            //どの鉱石をたたいたのかの判定（B鉱石）
            if (gameObject.CompareTag("Ore_B"))
            {
                //鉱石を消す
                Destroy(gameObject);
                //鉱石Bをtrueにする
                Ore_B = true;
                //Updataをtrueにする
                Updeta = true;
            }
            //どの鉱石をたたいたのかの判定（C鉱石）
            if (gameObject.CompareTag("Ore_C"))
            {
                //鉱石を消す
                Destroy(gameObject);
                //鉱石Cをtrueにする
                Ore_C = true;
                //Updataをtrueにする
                Updeta = true;
            }
            //どの鉱石をたたいたのかの判定（D鉱石）
            if (gameObject.CompareTag("Ore_D"))
            if (gameObject.CompareTag("Ore_D"))
            {
                //鉱石を消す
                Destroy(gameObject);
                //鉱石Dをtrueにする
                Ore_D = true;
                //Updataをtrueにする
                Updeta = true;
            }
        }
    }
}
