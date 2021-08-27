using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    #region êÈåæ
    public Rigidbody2D rb = null;
    public float x;
    public float y;
    #endregion
    //Start
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
    //Update
    void Update()
    {
        
    }
}
