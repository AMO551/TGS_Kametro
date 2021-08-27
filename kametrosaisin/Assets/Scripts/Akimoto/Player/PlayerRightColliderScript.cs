using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRightColliderScript : MonoBehaviour
{
    public static PlayerRightColliderScript Instance { get => _instance; }
    static PlayerRightColliderScript _instance;
    // �E�̓����蔻����Ƃ�ׂ̃t���O
    public bool playerrightcolliderflag = false;
    void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        playerrightcolliderflag = false;
    }
    // �E�̓����蔻���Ground���G�ꂽ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (!(collision.gameObject.CompareTag("Camera")))
            playerrightcolliderflag = true;
    }
    // �E�̓����蔻�肪Ground�𗣂�����
    private void OnTriggerExit2D(Collider2D collision)
    {
        
            playerrightcolliderflag = false;
    }
}
