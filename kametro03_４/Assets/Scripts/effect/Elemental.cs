using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Rigidbody2D rbody;
    private void  Ice(Collision2D other)
    {
        rbody = other.gameObject.GetComponent<Rigidbody2D>();
        rbody.velocity = Vector2.zero;

 
    }
}
