using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class WitchAttackControl : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    static bool mir = false;
    private Vector2 lastVelocity;
    private Rigidbody2D rb2D;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        this.rb2D= this.GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        this.lastVelocity = this.rb2D.velocity;
        if(!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "mirror")
        {
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity,collision.contacts[0].normal);
            this.rb2D.velocity = refrectVec;
            mir = true;
            Debug.Log(mir);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            float playerHP = script.player_HP;
            Debug.Log(playerHP);
            Destroy(this.gameObject);
        }
        if((collision.gameObject.CompareTag("witch"))&&(mir == true))
        {
            Debug.Log("Hit");
            collision.gameObject.SetActive(false);
            //Destroy (collision.gameObject);
        }
        else if(!(collision.gameObject.CompareTag("witch")||collision.gameObject.CompareTag("mirror")))
        {
            Destroy(this.gameObject);
        }
    }
}
