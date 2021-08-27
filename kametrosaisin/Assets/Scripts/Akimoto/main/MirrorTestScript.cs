using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTestScript : MonoBehaviour
{
    private PhysicsMaterial2D _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = this.gameObject.GetComponent<BoxCollider2D>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(_material);
        }
    }
}
