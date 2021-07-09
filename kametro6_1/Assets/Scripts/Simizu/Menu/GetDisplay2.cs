using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDisplay2 : MonoBehaviour
{
    [SerializeField]
    private GameObject rf_getdisplay;
    [SerializeField]
    private GameObject wg_getdisplay;
    [SerializeField]
    private GameObject ex_getdisplay;

    private bool r = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if内はデバッグしやすい用にキーコード
        //本来は取得したアイテムを判別
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate<GameObject>(rf_getdisplay, transform);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate<GameObject>(wg_getdisplay, transform);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate<GameObject>(ex_getdisplay, transform);
        }

    }
}
