using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brittle : MonoBehaviour
{
    //アニメーションの取得
    //当たっているかの確認
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //爆発ブロックの範囲に入っているかの確認
        if(collision.gameObject.CompareTag("Player"))
        {
            //壊れるアニメーションを追加
            //2秒後に消滅
            Destroy(gameObject,2);
        }
    }
}
