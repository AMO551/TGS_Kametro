using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation_Explanation : MonoBehaviour
{
    [SerializeField]
    GameObject OperationExplanation;
    //�N���b�N������
    private bool Click=false;
    private void Update()
    {
        if(Click)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                //������\��
                OperationExplanation.SetActive(false);
                Click = false;
            }
        }
    }
    public void OnClick()
    {
        //������\��
        OperationExplanation.SetActive(true);
        Click = true;
    }
}
