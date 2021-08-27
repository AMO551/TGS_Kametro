using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crush_range : MonoBehaviour
{
    //“ü‚Á‚Ä‚¢‚é
    public bool contains = false;
  
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag=="Player")
        {
            contains = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contains = false;
        }
    }
}
