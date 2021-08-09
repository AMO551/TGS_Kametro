using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation_Explanation : MonoBehaviour
{
    [SerializeField]
    GameObject OperationExplanation;
    //クリックしたか
    private bool Click=false;
    private void Update()
    {
        if(Click)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                //説明を表示
                OperationExplanation.SetActive(false);
                Click = false;
            }
        }
    }
    public void OnClick()
    {
        //説明を表示
        OperationExplanation.SetActive(true);
        Click = true;
    }
}
