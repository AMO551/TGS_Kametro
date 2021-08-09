using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    WitchControl witchControl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "w_a")
        {
            witchControl.freeze();
        }
        if (collision.gameObject.tag == "Block_Atk")//条件式：衝突したオブジェクトのタグが"Block"の場合
        {
            witchControl.dame();
        }
    }
}
