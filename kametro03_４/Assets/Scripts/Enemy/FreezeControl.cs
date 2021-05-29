using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeControl : MonoBehaviour
{
    public PlayerControl witch_a;
    public float FreezeTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("w_a"))
        {
            witch_a = witch_a.GetComponent<PlayerControl>();
            witch_a.enabled = false;
            Invoke("Restart",FreezeTime);
        }
    }
    void Restart()
    {
        witch_a.enabled = true;
    }
}
