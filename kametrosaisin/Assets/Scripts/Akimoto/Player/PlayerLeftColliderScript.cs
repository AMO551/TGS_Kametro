using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftColliderScript : MonoBehaviour
{
    public static PlayerLeftColliderScript Instance { get => _instance; }
    static PlayerLeftColliderScript _instance;
    // ���̓����蔻����Ƃ�ׂ̃t���O
    public bool playerleftcolliderflag = false;
    void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        playerleftcolliderflag = false;
    }
    // ���̓����蔻���Ground���G�ꂽ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.CompareTag("Camera")))
            playerleftcolliderflag = true;
    }
    // ���̓����蔻�肪Ground�𗣂�����
    private void OnTriggerExit2D(Collider2D collision)
    {
       
            playerleftcolliderflag = false;
    }
}
