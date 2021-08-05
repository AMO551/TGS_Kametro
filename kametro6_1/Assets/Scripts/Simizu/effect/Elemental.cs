using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    private Rigidbody2D rbody;
    private void  Ice(Collision2D other)
    {
        rbody = other.gameObject.GetComponent<Rigidbody2D>();
        rbody.velocity = Vector2.zero;

 
    }
}
