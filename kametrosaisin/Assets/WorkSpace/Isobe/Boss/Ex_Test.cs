using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_Test : MonoBehaviour
{
    //UŒ‚”ÍˆÍ
    public float Scope = 3f;
    private float time = 0f;
    private float timelimit = 2f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!(time>timelimit))
        {
            this.gameObject.transform.localScale += new Vector3(Scope * Time.deltaTime, Scope * Time.deltaTime, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block"||
            collision.gameObject.tag == "wgBlock"|| 
            collision.gameObject.tag == "rfBlock"||
            collision.gameObject.tag == "exBlock")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Player")
        {
            GameMainContol.Instance.GolemPlayerDamageVer1();
            //Destroy(gameObject);
        }
        

    }
}
