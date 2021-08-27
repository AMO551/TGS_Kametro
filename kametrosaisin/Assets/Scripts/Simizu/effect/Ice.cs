using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    GameObject gamemain_Obj;
    GameMainContol gameMainContol;
    //Start
    private void Start()
    {
        gamemain_Obj =GameObject.Find("GameMainContol");
        gameMainContol = gamemain_Obj.GetComponent<GameMainContol>();
    }
    //�����蔻��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameMainContol.Player_Freeze();
        }
    }
}
