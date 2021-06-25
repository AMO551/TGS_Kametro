using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColliderScript : MonoBehaviour
{
    public bool BlockInstallationFlag;
    private void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Box"))
        {

            BlockInstallationFlag = true;
            Debug.Log("ƒtƒ‰ƒO" + BlockInstallationFlag);
        }
        else
        {
            BlockInstallationFlag = false;
        }
    }
}
