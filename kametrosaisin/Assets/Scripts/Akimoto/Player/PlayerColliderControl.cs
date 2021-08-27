using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderControl : MonoBehaviour
{
    public static PlayerColliderControl Instance { get => _instance; }
    static PlayerColliderControl _instance;
    public bool jumpflag = true;
    private void Awake()
    {
        _instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!(collision.gameObject.CompareTag("Camera"))) // if(collision.gameObject.CompareTag("Ground"))
            jumpflag = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        jumpflag = true;
    }
}
