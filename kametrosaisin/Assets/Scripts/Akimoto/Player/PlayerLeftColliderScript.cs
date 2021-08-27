using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftColliderScript : MonoBehaviour
{
    public static PlayerLeftColliderScript Instance { get => _instance; }
    static PlayerLeftColliderScript _instance;
    // ¶‚Ì“–‚½‚è”»’è‚ğ‚Æ‚éˆ×‚Ìƒtƒ‰ƒO
    public bool playerleftcolliderflag = false;
    void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        playerleftcolliderflag = false;
    }
    // ¶‚Ì“–‚½‚è”»’è‚ÉGround‚ªG‚ê‚½‚ç
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.CompareTag("Camera")))
            playerleftcolliderflag = true;
    }
    // ¶‚Ì“–‚½‚è”»’è‚ªGround‚ğ—£‚µ‚½‚ç
    private void OnTriggerExit2D(Collider2D collision)
    {
       
            playerleftcolliderflag = false;
    }
}
