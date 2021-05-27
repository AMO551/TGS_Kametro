using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{
    //物にあたっているかの判定
    void OnCollisionEnter2D(Collision2D collision)
    {

        //物にあたったときそのものがプレイヤーかいなか
        if (collision.gameObject.CompareTag("Player"))
        {
            //ゴールとログでですS
            Debug.Log("GOAL");

        }
    }


}
