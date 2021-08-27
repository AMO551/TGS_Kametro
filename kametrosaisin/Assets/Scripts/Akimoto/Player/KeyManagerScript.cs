using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeyManagerScript : MonoBehaviour
{
    #region�@�錾
    //public-------------------------------
    public BlockColliderScript blockcolliderScript;
    public PlayerColliderControl playerColliderControl;
    public KeyControlScript keyControlScript;
    public SoundManager soundManager;
    public Block_Destroy block_Destroy;
    public GameObject FakeBlock; // �����u���b�N�̓��ꕨ
    public string crystalList;
    public float playerHP;
    public float reflectcrystal;
    //private-------------------------------
    private GameObject player;
    private float reflectCount;
    private float gravityCount;
    private float explosionCount;
    private float hori;
    private float tri;
    private float dph;
    #endregion
    // Update is called once per frame
    void Update()
    {
        #region ���t���C���Ăяo����
        playerHP = GameMainContol.Instance.player_HP;
        hori = Input.GetAxis("Horizontal");
        dph = Input.GetAxis("D_Pad_H");
        #endregion
        #region �v���C���[�̓���,�U��
        //�U��
        if (Input.GetKeyDown("joystick button 1"))
        {
            KeyControlScript.instance.StartAttackMove();
        }
        // �e�X�g
        if(Input.GetKeyDown(KeyCode.G))
        {
            ColorManager.Instance.ChangeColor(0);
        }
        // �v���C���[�̍��ړ�
        //if(Input.GetKey(KeyCode.LeftArrow)&&PlayerLeftColliderScript.Instance.playerleftcolliderflag == false)
        if ((hori < 0 || dph < 0 )&& PlayerLeftColliderScript.Instance.playerleftcolliderflag == false)
        {
            MoveLeftColliderControl.Instance.LeftMoveLeftCollider();
            MoveRightColliderControl.Instance.LeftMoveRightCollder();
            KeyControlScript.instance.MoveLeft();
            KeyControlScript.instance.MoveAction();
        }
        // �v���C���[�̉E�ړ�
        //if (Input.GetKey(KeyCode.RightArrow)&&PlayerRightColliderScript.Instance.playerrightcolliderflag==false)
        else if ((hori > 0 || dph > 0 )&& PlayerRightColliderScript.Instance.playerrightcolliderflag == false)
        {
            MoveLeftColliderControl.Instance.RightMoveLeftCollider();
            MoveRightColliderControl.Instance.RightMoveRightCollider();
            KeyControlScript.instance.MoveRight();
            KeyControlScript.instance.MoveAction();
        }
        //�����Ă��Ȃ��Ƃ�
        else if (hori == 0 || dph == 0)
        {
            KeyControlScript.instance.MoveStop();
        }
        // �v���C���[�̃W�����v
        //if (Input.GetKeyDown(KeyCode.UpArrow)&&PlayerColliderControl.Instance.jumpflag == false)
        if (Input.GetKeyDown("joystick button 0") && PlayerColliderControl.Instance.jumpflag == false)
        {
            KeyControlScript.instance.MoveJump();
        }
        #endregion
        #region     �ʏ�u���b�N
        // �ʏ�u���b�N�̐ݒu
        if (Input.GetKeyUp("joystick button 2"))
        {
            tri = Input.GetAxis("L_R_Trigger");
            if (tri > 0)// �ݒu�̃L�����Z��
            {
                KeyControlScript.instance.BlockInsatnallationCancel();
                Debug.Log("L_Trigger");
            }
            else
            {
                KeyControlScript.instance.FakeBlockOut();
                if (blockcolliderScript.BlockInstallationFlag)
                    return;
                KeyControlScript.instance.BlockInstanllation();
            }
        }
        // �����u���b�N�̐ݒu(�ʏ�u���b�N)
        if (Input.GetKeyDown("joystick button 2"))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
            blockcolliderScript = FakeBlock.GetComponent<BlockColliderScript>();
            KeyControlScript.instance.BlockFlagReset();
        }
        #endregion
        #region�@�X�L���u���b�N
        // �X�L���u���b�N�̐ݒu
        if (Input.GetKeyUp("joystick button 3"))
        {
            tri = Input.GetAxis("L_R_Trigger"); //L_R_Trigger�L�[�̎擾
            // �ݒu�̃L�����Z��
            if (tri > 0)
            {
                KeyControlScript.instance.BlockInsatnallationCancel();
                Debug.Log("L_Trigger");
            }
            else
            {
                KeyControlScript.instance.FakeBlockOut();
                // �X�L����΂̌v�Z����
                if (KeyControlScript.instance.GetCrystalType() == KeyControlScript.Crystal.Reflect)
                {
                    reflectCount = GameMainContol.Instance.reflectcrystalCount;
                    if (reflectCount == 0 || blockcolliderScript.BlockInstallationFlag)
                        return;
                    // �X�L���u���b�N�̐ݒu����
                    KeyControlScript.instance.SkillBlockInstanllation();
                    GameMainContol.Instance.PullReflectCrystalCount();
                }
                // �X�L����΂̌v�Z����
                if (KeyControlScript.instance.GetCrystalType() == KeyControlScript.Crystal.Gravity)
                {
                    gravityCount = GameMainContol.Instance.gravitycrystalCount;
                    if (gravityCount == 0 || blockcolliderScript.BlockInstallationFlag)
                        return;
                    // �X�L���u���b�N�̐ݒu����
                    KeyControlScript.instance.SkillBlockInstanllation();
                    GameMainContol.Instance.PullGravityCrystalCount();
                }
                // �X�L����΂̌v�Z����
                if (KeyControlScript.instance.GetCrystalType() == KeyControlScript.Crystal.Explosion)
                {
                    explosionCount = GameMainContol.Instance.explosioncrystalCount;
                    if (explosionCount == 0 || blockcolliderScript.BlockInstallationFlag)
                        return;
                    // �X�L���u���b�N�̐ݒu����
                    KeyControlScript.instance.SkillBlockInstanllation();
                    GameMainContol.Instance.PullExplosioncrystalCount();
                }
            }
        }
        // �����u���b�N�̐ݒu(�X�L���u���b�N)
        if (Input.GetKeyDown("joystick button 3"))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
            blockcolliderScript = FakeBlock.GetComponent<BlockColliderScript>();
            KeyControlScript.instance.BlockFlagReset();
        }
        //�X�L���u���b�N�̐؂�ւ�

        if (Input.GetKeyDown("joystick button 5"))
        {
            KeyControlScript.instance.CrystalChangeRight();
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            KeyControlScript.instance.CrystalChangeLeft();
        }

        #endregion
        #region �v���C���[��HP0
        if (GameMainContol.Instance.player_HP <= 0)
        {
            KeyControlScript.instance.LosePlayerControl();
        }
        #endregion
        #region �u���b�N�O�j�󏈗�
        tri = Input.GetAxis("L_R_Trigger");
        // �u���b�N�S�j��
        if (tri < 0)
        {
            Debug.Log("R_Trigger");
            block_Destroy.Block_Destroy_Contol();
        }
        #endregion
    }
}
