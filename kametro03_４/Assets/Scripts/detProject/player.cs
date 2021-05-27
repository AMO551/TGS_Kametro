using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//プレイヤースクリプト
public class player : MonoBehaviour
{
    private float m_waterspeed = 1.0f;　　　　  //
    public PoisonedWater poisonedwater;         //
    public int Player_hp = 10;                  //
    private int Player_damege = 0;              //
    private bool input = false;                 //
    void Start()
    {
        m_waterspeed = poisonedwater.detspeed;//取得できないとバグが出る先生に回答だのむ
        Player_damege = poisonedwater.Player_damege;

    }

    // Update is called once per frame
    void Update()
    {

        if (input == true)
        {

            Player_damege = poisonedwater.Player_damege;
            Player_hp -= Player_damege;
        }
    }
}
