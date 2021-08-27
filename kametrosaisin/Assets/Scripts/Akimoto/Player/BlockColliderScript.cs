using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColliderScript : MonoBehaviour
{

    public bool BlockInstallationFlag = false;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Block")
            || collision.gameObject.CompareTag("rfBlock")
            || collision.gameObject.CompareTag("wgBlock")
            || collision.gameObject.CompareTag("exBlock")
            || collision.gameObject.CompareTag("Ground"))
        {

            BlockInstallationFlag = true;
            Debug.Log("ƒtƒ‰ƒO" + BlockInstallationFlag);
        }
        else
        {
            Debug.Log(collision.tag);
            BlockInstallationFlag = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Block")
        //    || collision.gameObject.CompareTag("rfBlock")
        //    || collision.gameObject.CompareTag("wgBlock")
        //    || collision.gameObject.CompareTag("exBlock")
        //    || collision.gameObject.CompareTag("Ground"))
        //{ }
        BlockInstallationFlag = false;
    }
}
