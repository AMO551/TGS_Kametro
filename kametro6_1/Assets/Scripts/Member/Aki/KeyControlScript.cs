using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControlScript : MonoBehaviour
{
    // リストの生成
    enum Crystal
    {
        Normal,
        Reflect,
        Gravity,
        Explosion,
    }
    // Crystal の実体化
    [SerializeField]
    Crystal crystal = Crystal.Normal;
    // 一つしかアタッチできないように
    public static KeyControlScript instance = null;
    // プレイヤーの速さ
    public float speed = 0.0f;
    // プレイヤーのジャンプ力
    public float flap = 0.0f;
    // プレイヤーが地面上かどうかのフラグ
    public bool jumpflag = false;
    // プレイヤーの今の位置を入れる変数
    public Vector2 now_pos;
    // ブロックのフラグ
    private bool blockFlag = false;
    // 透明ブロックのフラグ
    private bool FakeblockFlag = false;
    //
    public float debage = 0.0f;
    // プレイヤーの向き
    [SerializeField]
    private float direction = 1.0f;
    // PlayerのRigidbodyを取得するための変数
    Rigidbody2D rb2d;
    // 通常ブロックの入れ物
    public GameObject Block;
    // 透明ブロックの入れ物
    public GameObject FakeBlock;
    // 反射ブロックの入れ物
    public GameObject Reflect_Block;
    // 重力ブロックの入れ物
    public GameObject Granvity_Block;
    // 爆破ブロックの入れ物
    public GameObject Explosion_Block;
    // プレハブの親の入れ物
    public Transform CanvasTransform;
    // ブロックの設置フラグ
    public bool blockInstanllationflag = true;
    Vector2 scale;
    BlockColliderScript blockcolliderScript;
    public GameObject previewBlock;
    void Awake()
    {
        // PlayerのRigidbodyを取得
        rb2d = GetComponent<Rigidbody2D>();
        blockcolliderScript = FakeBlock.GetComponent<BlockColliderScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // プレイヤーの右移動
    public void MoveRight()
    {
        Vector2 scale = transform.localScale;
        rb2d.AddForce(new Vector3(speed - debage, 0, 0));
        scale.x = 100;
        direction = 1f;
        transform.localScale = scale;
    }
    // プレイヤーの左移動
    public void MoveLeft()
    {
        Vector2 scale = transform.localScale;
        rb2d.AddForce(new Vector3(-speed + debage, 0, 0));
        scale.x = -100;
        direction = -1f;
        transform.localScale = scale;
    }
    // プレイヤーのジャンプ
    public void MoveJump()
    {
        if (jumpflag)
            return;
        rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
        jumpflag = true;
    }
    // 宝石の切り替え
    public void CrystalChangeRight()
    {
        switch(crystal){
            case Crystal.Normal:
                crystal = Crystal.Reflect;
                break;
            case Crystal.Reflect:
                crystal = Crystal.Gravity;
                break;
            case Crystal.Gravity:
                crystal = Crystal.Explosion;
                break;
            case Crystal.Explosion:
                crystal = Crystal.Normal;
                break;
            default:
                break;
        }
    }
    // ブロックの設置
    public void BlockInstanllation()
    {
        // 透明ブロックの削除
        Destroy(previewBlock);
        if (blockcolliderScript.BlockInstallationFlag == true)
            return;
        //位置取得
        var pos = this.gameObject.transform.position;
        //プレハブ用意
        var Block_pos = Instantiate(Block, new Vector2(pos.x + 150 * direction, pos.y), Quaternion.identity) as GameObject;
        //親子設定
        Block_pos.transform.parent = CanvasTransform.transform;
    }
    // 透明ブロックの設置
    public void FakeBlockInstanllation()
    {
        blockInstanllationflag = false;
        // 位置取得
        now_pos = this.gameObject.transform.position;
        // プレハブ用意
        previewBlock = Instantiate(FakeBlock, new Vector2(now_pos.x + 150 * direction, now_pos.y), Quaternion.identity) as GameObject;
        blockcolliderScript = previewBlock.GetComponent<BlockColliderScript>();
        // 親子関係
        previewBlock.transform.parent = this.transform;
    }
    // スキルブロックの設置
    public void SkillBlockInstanllation()
    {
        switch (crystal){
            case Crystal.Reflect:
                // 透明ブロックの削除
                Destroy(previewBlock);
                if (blockcolliderScript.BlockInstallationFlag == true)
                    return;
                // 位置取得
                var Reflectpos = this.gameObject.transform.position;
                // プレハブ用意+設置
                var ReflectBlock_pos = Instantiate(Reflect_Block, new Vector2(Reflectpos.x + 150 * direction, Reflectpos.y), Quaternion.identity) as GameObject;
                // 親子設定
                ReflectBlock_pos.transform.parent = CanvasTransform.transform;
                GameMainContol.Instance.PullCrystalCount();
                break;
            case Crystal.Gravity:
                // 透明ブロックの削除
                Destroy(previewBlock);
                if (blockcolliderScript.BlockInstallationFlag == true)
                    return;
                // 位置取得
                var gravitypos = this.gameObject.transform.position;
                // プレハブ用意+設置
                var gravityBlock_pos = Instantiate(Granvity_Block, new Vector2(gravitypos.x + 150 * direction, gravitypos.y), Quaternion.identity) as GameObject;
                // 親子設定
                gravityBlock_pos.transform.parent = CanvasTransform.transform;
                break;
            case Crystal.Explosion:
                // 透明ブロックの削除
                Destroy(previewBlock);
                if (blockcolliderScript.BlockInstallationFlag == true)
                    return;
                // 位置取得
                var Explosionpos = this.gameObject.transform.position;
                // プレハブ用意+設置
                var ExplosionBlock_pos = Instantiate(Explosion_Block, new Vector2(Explosionpos.x + 150 * direction, Explosionpos.y), Quaternion.identity) as GameObject;
                // 親子設定
                ExplosionBlock_pos.transform.parent = CanvasTransform.transform;
                break;
            default:
                break;
        }
    }
    // ブロックの設置キャンセル
    public void BlockInsatnallationCancel()
    {
        Destroy(previewBlock);
        blockInstanllationflag = true;
    }
    // プエイヤーが消える処理
    /*
    public void PlayerDestroyMove()
    {
        Destroy(this);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("mirror"))
        {
            jumpflag = false;
        }
    }
}
