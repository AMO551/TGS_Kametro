using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Destroy : MonoBehaviour
{
    //�u���b�N�̐e�I�u�W�F�N�g���Ăяo��
    [SerializeField]
    private GameObject Block;

    //�u���b�N�̑O�j�󏈗�
    public void Block_Destroy_Contol()
    {
        //�u���b�N�̎q�����������鏈��
        foreach (Transform child in Block.transform)
        {
            //�����݂���u���b�N��destroy
            Destroy(child.gameObject);
        }
    }


}
