using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe_Zone : MonoBehaviour
{
    //�Z�[�u���m�F����ϐ�
    public bool Save = false;
    //�������������Ă��邩�m�F����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���������Ă��邩�m�F
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�Z�[�u���ꂽ");
            //�Z�[�u���ꂽ���Ƃ��m�Ftrue�ɂ���
            Save = true;

        }
    }
}
