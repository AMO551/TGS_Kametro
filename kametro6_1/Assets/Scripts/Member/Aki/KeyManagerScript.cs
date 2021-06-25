using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerScript : MonoBehaviour
{
    private bool Jumpflag;
    private bool blockflag;
    //public float playerHp;
    public KeyControlScript keycontrolscript;
    //public GameMainContol gamemaincotrol;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Jumpflag = keycontrolscript.jumpflag;
    }

    // Update is called once per frame
    void Update()
    {
        blockflag = keycontrolscript.blockInstanllationflag;
        //playerHp = gamemaincotrol.player_HP;
        // �v���C���[�̉E�ړ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            KeyControlScript.instance.MoveRight();
        }
        // �v���C���[�̍��ړ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            KeyControlScript.instance.MoveLeft();
        }
        // �v���C���[�̃W�����v
        if (Input.GetKeyDown(KeyCode.UpArrow) && keycontrolscript.jumpflag == false)
        {
            Debug.Log(Jumpflag);
            KeyControlScript.instance.MoveJump();
        }
        // �ʏ�u���b�N�̐ݒu
        if (Input.GetKeyUp(KeyCode.Space) && blockflag == false)
        {
            KeyControlScript.instance.BlockInstanllation();
        }
        // �����u���b�N�̐ݒu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Z))
                KeyControlScript.instance.BlockInsatnallationCancel();
        }
        // �X�L���u���b�N�̐ݒu
        if (Input.GetKeyUp(KeyCode.D) && blockflag == false)
        {
            KeyControlScript.instance.SkillBlockInstanllation();
        }
        // �����u���b�N�̐ݒu
        if (Input.GetKeyDown(KeyCode.D))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.Z))
                KeyControlScript.instance.BlockInsatnallationCancel();
        }
        // �X�L���u���b�N�̐؂�ւ�
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyControlScript.instance.CrystalChangeRight();
        }
        /*
        if(playerHp == 0)
        {
            KeyControlScript.instance.PlayerDestroyMove();
        }
        */
    }
}
