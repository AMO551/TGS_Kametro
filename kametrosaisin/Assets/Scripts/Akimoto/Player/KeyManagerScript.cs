using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeyManagerScript : MonoBehaviour
{
    #region　宣言
    //public-------------------------------
    public BlockColliderScript blockcolliderScript;
    public PlayerColliderControl playerColliderControl;
    public KeyControlScript keyControlScript;
    public SoundManager soundManager;
    public Block_Destroy block_Destroy;
    public GameObject FakeBlock; // 透明ブロックの入れ物
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
        #region 毎フレイム呼び出す物
        playerHP = GameMainContol.Instance.player_HP;
        hori = Input.GetAxis("Horizontal");
        dph = Input.GetAxis("D_Pad_H");
        #endregion
        #region プレイヤーの動き,攻撃
        //攻撃
        if (Input.GetKeyDown("joystick button 1"))
        {
            KeyControlScript.instance.StartAttackMove();
        }
        // テスト
        if(Input.GetKeyDown(KeyCode.G))
        {
            ColorManager.Instance.ChangeColor(0);
        }
        // プレイヤーの左移動
        //if(Input.GetKey(KeyCode.LeftArrow)&&PlayerLeftColliderScript.Instance.playerleftcolliderflag == false)
        if ((hori < 0 || dph < 0 )&& PlayerLeftColliderScript.Instance.playerleftcolliderflag == false)
        {
            MoveLeftColliderControl.Instance.LeftMoveLeftCollider();
            MoveRightColliderControl.Instance.LeftMoveRightCollder();
            KeyControlScript.instance.MoveLeft();
            KeyControlScript.instance.MoveAction();
        }
        // プレイヤーの右移動
        //if (Input.GetKey(KeyCode.RightArrow)&&PlayerRightColliderScript.Instance.playerrightcolliderflag==false)
        else if ((hori > 0 || dph > 0 )&& PlayerRightColliderScript.Instance.playerrightcolliderflag == false)
        {
            MoveLeftColliderControl.Instance.RightMoveLeftCollider();
            MoveRightColliderControl.Instance.RightMoveRightCollider();
            KeyControlScript.instance.MoveRight();
            KeyControlScript.instance.MoveAction();
        }
        //歩いていないとき
        else if (hori == 0 || dph == 0)
        {
            KeyControlScript.instance.MoveStop();
        }
        // プレイヤーのジャンプ
        //if (Input.GetKeyDown(KeyCode.UpArrow)&&PlayerColliderControl.Instance.jumpflag == false)
        if (Input.GetKeyDown("joystick button 0") && PlayerColliderControl.Instance.jumpflag == false)
        {
            KeyControlScript.instance.MoveJump();
        }
        #endregion
        #region     通常ブロック
        // 通常ブロックの設置
        if (Input.GetKeyUp("joystick button 2"))
        {
            tri = Input.GetAxis("L_R_Trigger");
            if (tri > 0)// 設置のキャンセル
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
        // 透明ブロックの設置(通常ブロック)
        if (Input.GetKeyDown("joystick button 2"))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
            blockcolliderScript = FakeBlock.GetComponent<BlockColliderScript>();
            KeyControlScript.instance.BlockFlagReset();
        }
        #endregion
        #region　スキルブロック
        // スキルブロックの設置
        if (Input.GetKeyUp("joystick button 3"))
        {
            tri = Input.GetAxis("L_R_Trigger"); //L_R_Triggerキーの取得
            // 設置のキャンセル
            if (tri > 0)
            {
                KeyControlScript.instance.BlockInsatnallationCancel();
                Debug.Log("L_Trigger");
            }
            else
            {
                KeyControlScript.instance.FakeBlockOut();
                // スキル宝石の計算処理
                if (KeyControlScript.instance.GetCrystalType() == KeyControlScript.Crystal.Reflect)
                {
                    reflectCount = GameMainContol.Instance.reflectcrystalCount;
                    if (reflectCount == 0 || blockcolliderScript.BlockInstallationFlag)
                        return;
                    // スキルブロックの設置処理
                    KeyControlScript.instance.SkillBlockInstanllation();
                    GameMainContol.Instance.PullReflectCrystalCount();
                }
                // スキル宝石の計算処理
                if (KeyControlScript.instance.GetCrystalType() == KeyControlScript.Crystal.Gravity)
                {
                    gravityCount = GameMainContol.Instance.gravitycrystalCount;
                    if (gravityCount == 0 || blockcolliderScript.BlockInstallationFlag)
                        return;
                    // スキルブロックの設置処理
                    KeyControlScript.instance.SkillBlockInstanllation();
                    GameMainContol.Instance.PullGravityCrystalCount();
                }
                // スキル宝石の計算処理
                if (KeyControlScript.instance.GetCrystalType() == KeyControlScript.Crystal.Explosion)
                {
                    explosionCount = GameMainContol.Instance.explosioncrystalCount;
                    if (explosionCount == 0 || blockcolliderScript.BlockInstallationFlag)
                        return;
                    // スキルブロックの設置処理
                    KeyControlScript.instance.SkillBlockInstanllation();
                    GameMainContol.Instance.PullExplosioncrystalCount();
                }
            }
        }
        // 透明ブロックの設置(スキルブロック)
        if (Input.GetKeyDown("joystick button 3"))
        {
            KeyControlScript.instance.FakeBlockInstanllation();
            blockcolliderScript = FakeBlock.GetComponent<BlockColliderScript>();
            KeyControlScript.instance.BlockFlagReset();
        }
        //スキルブロックの切り替え

        if (Input.GetKeyDown("joystick button 5"))
        {
            KeyControlScript.instance.CrystalChangeRight();
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            KeyControlScript.instance.CrystalChangeLeft();
        }

        #endregion
        #region プレイヤーのHP0
        if (GameMainContol.Instance.player_HP <= 0)
        {
            KeyControlScript.instance.LosePlayerControl();
        }
        #endregion
        #region ブロック前破壊処理
        tri = Input.GetAxis("L_R_Trigger");
        // ブロック全破壊
        if (tri < 0)
        {
            Debug.Log("R_Trigger");
            block_Destroy.Block_Destroy_Contol();
        }
        #endregion
    }
}
