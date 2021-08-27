using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameMainContol.Instance.TNTPlayerDamege();
        }
        if (collision.gameObject.tag == "Enemy" ||
            collision.gameObject.tag == "witch")
        {
            Destroy(collision.gameObject);
        }
    }
}
