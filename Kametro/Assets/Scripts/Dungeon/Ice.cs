using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public Rigidbody2D rbody;
 
    public void Flost(Collision2D other)
    {

        rbody = this.gameObject.GetComponent<Rigidbody2D>();
        if (rbody != null)
        {
            rbody.velocity = Vector2.zero;
            rbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }
}
