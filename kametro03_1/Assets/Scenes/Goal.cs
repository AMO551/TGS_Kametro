using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{
    //���ɂ������Ă��邩�̔���
    void OnCollisionEnter2D(Collision2D collision)
    {

        //���ɂ��������Ƃ����̂��̂��v���C���[�����Ȃ�
        if (collision.gameObject.CompareTag("Player"))
        {
            //�S�[���ƃ��O�łł�S
            Debug.Log("GOAL");

        }
    }


}
