using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    BlockScript BlockReversal;
    // Start is called before the first frame update
    //public void block()
    //{
    //    animator = this.gameObject.GetComponent<Animator>();
    //    animator.SetTrigger("block");
    //    Debug.Log("block");
    //}
    //ブロックの破壊アニメーション
    private void Start()
    {
        if(BlockReversal.blockreversal)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.localPosition = new Vector3(-1.25f, 0.0f, 0.0f);
        }
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetTrigger("block");
        Debug.Log("block");
        //this.transform.position = new Vector3(this.transform.position.x - 10, this.transform.position.y, this.transform.position.z);
    }

}
