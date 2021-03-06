//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PlayerLoop;

public enum Ore_TB
{
    None,
    Ore_A,
    Ore_B,
    Ore_C,
    Ore_D,
    Ore_E,
    Ore_F,
    Ore_G,
    Ore_H,
}

public class Ore : MonoBehaviour
{
   
    public int ore_a = 0;          //鉱石Aの初期化
    public int ore_b = 0;          //鉱石Bの初期化
    public int ore_c = 0;          //鉱石Cの初期化
    private bool Updeta = false;     //アップデートをfalseに初期化
    private bool Updeta_t = false; //鉱石をほかのスクリプトに渡す                           

    public Ore_TB m_type = Ore_TB.None;
    // Update is called once per frame

    public void Start()
    {

    }
    void Update()
    {
        if (Updeta_t)
        {
            if (Updeta == true)
            {
                ore_a = 0;          //鉱石Aの初期化
                ore_b = 0;          //鉱石Bの初期化
                ore_c = 0;          //鉱石Cの初期化

                //データを渡す処理を行う
                SoundManager.Instance.Play_SE(0, 18);
                //デストロイ処理
                Destroy(gameObject);
            }

        }
        else
        {
            //Player_HPをアップデートしていく
            if (Updeta == true)
            {
                Ore_processing();
            }
        }
    }
    void Ore_processing()
    {
        Ore ore = this.gameObject.GetComponent<Ore>();
        switch (ore.m_type)
        {
            //鉱石Aが処理されているか見る
            case Ore_TB.Ore_A:
                ore_a = 1;   //反射鉱石1個与える
                ore_b = 2;      //重力鉱石2個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Bが処理されているか見る
            case Ore_TB.Ore_B:
                ore_a = 2;      //反射鉱石2個与える
                ore_b = 1;      //重力鉱石1個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Cが処理されているか見る
            case Ore_TB.Ore_C:
                ore_a = 1;      //反射鉱石1個与える
                ore_b = 3;      //重力鉱石3個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Dが処理されているか見る
            case Ore_TB.Ore_D:
                ore_a = 3;      //反射鉱石3個与える
                ore_b = 1;      //重力鉱石1個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Eが処理されているか見る
            case Ore_TB.Ore_E:
                ore_a = 1;   //反射鉱石1個与える
                ore_b = 1;      //重力鉱石1個与える
                ore_c = 2;      //爆発鉱石2個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Fが処理されているか見る
            case Ore_TB.Ore_F:
                ore_a = 1;      //反射鉱石1個与える
                ore_b = 0;      //重力鉱石0個与える
                ore_c = 3;      //爆発鉱石3個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Gが処理されているか見る
            case Ore_TB.Ore_G:
                ore_a = 1;      //反射鉱石1個与える
                ore_b = 2;      //重力鉱石2個与える
                ore_c = 1;      //爆発鉱石1個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
            //鉱石Hが処理されているか見る
            case Ore_TB.Ore_H:
                ore_a = 2;      //反射鉱石2個与える
                ore_b = 0;      //重力鉱石0個与える
                ore_c = 2;      //爆発鉱石2個与える
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //処理に移動
                break;
        }
    }


    //物が通過したか見る
    void OnTriggerEnter2D(Collider2D collision2d)
    {
        //Debug.Log("鉱石ドロップ");
        //Debug.Log("物にあたったa");
        //プレイヤーが当たっているかの判定
        if (collision2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("プレイヤーを確認");
            Updeta = true;
        }
    }
}
