using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brittle : MonoBehaviour
{
    //�A�j���[�V�����̎擾
    //�������Ă��邩�̊m�F
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�����u���b�N�͈̔͂ɓ����Ă��邩�̊m�F
        if(collision.gameObject.CompareTag("Player"))
        {
            //����A�j���[�V������ǉ�
            //2�b��ɏ���
            Destroy(gameObject,2);
        }
    }
}
