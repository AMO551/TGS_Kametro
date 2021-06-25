using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerScript : MonoBehaviour
{
    private bool Jumpflag;
    public KeyControlScript keycontrolscript;
    // Start is called before the first frame update
    void Start()
    {
        Jumpflag = keycontrolscript.jumpflag;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̉E�ړ�
        if(Input.GetKey(KeyCode.RightArrow))
        {
            KeyControlScript.instance.MoveRight();
        }
        // �v���C���[�̍��ړ�
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            KeyControlScript.instance.MoveLeft();
        }
        // �v���C���[�̃W�����v
        if(Input.GetKeyDown(KeyCode.UpArrow) && keycontrolscript.jumpflag == false)
        {
            Debug.Log(Jumpflag);
            KeyControlScript.instance.MoveJump();
        }
        // �ʏ�u���b�N�̐ݒu
        if(Input.GetKeyUp(KeyCode.Space))
        {
            KeyControlScript.instance.BlockInstanllation();
        }
        // �����u���b�N�̐ݒu
        if(Input.GetKeyDown(KeyCode.Space))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
        }
        // �X�L���u���b�N�̐ݒu
        if(Input.GetKeyDown(KeyCode.D))
        {
            KeyControlScript.instance.SkillBlockInstanllation();
        }
        // �X�L���u���b�N�̐؂�ւ�
        if(Input.GetKeyDown(KeyCode.E))
        {
            KeyControlScript.instance.CrystalChangeRight();
        }
    }
}
