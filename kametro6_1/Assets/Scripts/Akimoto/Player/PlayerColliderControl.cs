using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderControl : MonoBehaviour
{
    public bool jumpflag;
    private void Awake()
    {
        jumpflag = true; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("mirror"))
        //{
            //if(cooltime<5.0f)
            jumpflag = false;
            //Debug.Log(jumpflag);
        //}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       // if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("mirror"))
      //  {
            jumpflag = true;
            //Debug.Log(jumpflag);
       // }
    }
}
