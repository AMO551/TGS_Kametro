using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe_Zone : MonoBehaviour
{
    //セーブを確認する変数
    public bool Save = false;
    //何かが当たっているか確認する
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーが当たっているか確認
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("セーブされた");
            //セーブされたことを確認trueにする
            Save = true;

        }
    }
}
