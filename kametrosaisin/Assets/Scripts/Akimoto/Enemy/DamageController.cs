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
        if (collision.gameObject.tag == "Block_Atk")//�������F�Փ˂����I�u�W�F�N�g�̃^�O��"Block"�̏ꍇ
        {
            witchControl.dame();
        }
    }
}
