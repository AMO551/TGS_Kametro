using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Atk : MonoBehaviour
{
    GameObject golem;
    private void Start()
    {
        golem = GameObject.Find("Golem");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
            GameMainContol.Instance.GolemPlayerDamageVer3();
        }
        else if (collision.gameObject.tag == "Block"||
            collision.gameObject.tag == "rfBlock" ||
            collision.gameObject.tag == "wgBlock" ||
            collision.gameObject.tag == "exBlock" )
        {
            Destroy(collision.gameObject);
        }else if(golem.GetComponent<golem>().golem_attack2&& collision.gameObject == GameObject.Find("scaffold_2"))
        {
                Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
