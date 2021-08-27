using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class AttackControl : MonoBehaviour
{
    #region êÈåæ
    GameObject go;
    public GameObject player;
    static bool mir = false;
    private Vector2 lastVelocity;
    private Rigidbody2D rb2D;
    #endregion
    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("GameMainContol");
        player = GameObject.Find("Player");
        this.rb2D = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb2D.velocity;
        //if (!GetComponent<SpriteRenderer>().isVisible)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.CompareTag("witch")) && (mir == true))
        {
            Debug.Log("Hit");
            collision.gameObject.SetActive(false);
            //Destroy (collision.gameObject);
        }
        else if (!(collision.gameObject.CompareTag("witch") || collision.gameObject.CompareTag("mirror")))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.Play_SE(0, 0);
            GameMainContol.Instance.WitchPlayerDamege();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "mirror")
        {
            Vector2 refrectVec = Vector2.Reflect(new Vector2(lastVelocity.x, lastVelocity.y), lastVelocity);
            this.rb2D.velocity = refrectVec;
            mir = true;
            Debug.Log(mir);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Block")
           || collision.gameObject.CompareTag("wgBlock")
           || collision.gameObject.CompareTag("exBlock"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
       
    }
}
