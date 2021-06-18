using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public Rigidbody2D rbody;
 
    public void Flost(Collision2D other)
    {
        //rbody‚ğæ“¾
        rbody = this.gameObject.GetComponent<Rigidbody2D>();
        if (rbody != null)
        {
            //‘¬“x‚ğƒ[ƒ
            rbody.velocity = Vector2.zero;
            //‘€ì•s‰Â‚É‚·‚é
            rbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }
}
