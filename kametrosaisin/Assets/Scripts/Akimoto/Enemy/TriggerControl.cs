using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    public bool InArea = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("ウィッチの範囲に当たった");
        if(collider.gameObject.CompareTag("Player"))
        {
            //Debug.Log("ウィッチ攻撃開始");
            InArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
       // Debug.Log("ウィッチの範囲から抜けた");
        if (collider.gameObject.CompareTag("Player"))
        {
           // Debug.Log("ウィッチ攻撃終了");
            InArea = false;
            //animator.SetBool("Attack",false);
        }
    }
}
