using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCilck()
    {
        Debug.Log("�I��");
        //�Q�[���I��
        //Unity�G�f�B�^�i�J�����j�ŃQ�[�������s���Ă���ꍇ
        UnityEditor.EditorApplication.isPlaying = false;
        
        //�X�^���h�A�����Ŏ��s���Ă���ꍇ
        Application.Quit();
    }
}
