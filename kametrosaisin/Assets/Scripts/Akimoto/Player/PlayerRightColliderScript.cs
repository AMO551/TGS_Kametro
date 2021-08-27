using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRightColliderScript : MonoBehaviour
{
    public static PlayerRightColliderScript Instance { get => _instance; }
    static PlayerRightColliderScript _instance;
    // 右の当たり判定をとる為のフラグ
    public bool playerrightcolliderflag = false;
    void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        playerrightcolliderflag = false;
    }
    // 右の当たり判定にGroundが触れたら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (!(collision.gameObject.CompareTag("Camera")))
            playerrightcolliderflag = true;
    }
    // 右の当たり判定がGroundを離したら
    private void OnTriggerExit2D(Collider2D collision)
    {
        
            playerrightcolliderflag = false;
    }
}
