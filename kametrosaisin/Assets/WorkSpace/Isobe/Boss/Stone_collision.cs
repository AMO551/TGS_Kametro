using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            GameMainContol.Instance.GolemPlayerDamageVer4();
        }
    }
}
