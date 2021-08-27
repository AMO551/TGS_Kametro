using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Destroy : MonoBehaviour
{
    //ブロックの親オブジェクトを呼び出し
    [SerializeField]
    private GameObject Block;

    //ブロックの前破壊処理
    public void Block_Destroy_Contol()
    {
        //ブロックの子供を処理する処理
        foreach (Transform child in Block.transform)
        {
            //今存在するブロックをdestroy
            Destroy(child.gameObject);
        }
    }


}
