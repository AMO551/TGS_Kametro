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
        //Debug.Log("�E�B�b�`�͈̔͂ɓ�������");
        if(collider.gameObject.CompareTag("Player"))
        {
            //Debug.Log("�E�B�b�`�U���J�n");
            InArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
       // Debug.Log("�E�B�b�`�͈̔͂��甲����");
        if (collider.gameObject.CompareTag("Player"))
        {
           // Debug.Log("�E�B�b�`�U���I��");
            InArea = false;
            //animator.SetBool("Attack",false);
        }
    }
}
