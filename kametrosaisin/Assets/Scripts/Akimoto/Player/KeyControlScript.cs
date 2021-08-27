using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class KeyControlScript : MonoBehaviour
{
    #region 宣言
    // リストの生成
    public enum Crystal
    {
        Reflect, 
        Explosion,
        Gravity,
    }
    // Crystal の実体化
    [SerializeField]
    public Crystal crystal = Crystal.Reflect;
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
    //毒水で足を遅くする
    public float debage = 0.0f;
    public Transform player_position;
    // プレイヤーの向き
    [SerializeField]
    public float direction = 1.0f;
    // PlayerのRigidbodyを取得するための変数
    Rigidbody2D rb2d;
    // 通常ブロックの入れ物
    public GameObject Block;
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
    // プレイヤーの移動の力用変数
    public float movepawer = 0.0f;

    //BlockColliderScript blockcolliderScript;
    public GameMainContol gameMainContorl;
    //public GameObject previewBlock;
    public bool nowBlockFlag = false;
    [SerializeField]
    public GameObject fakeBlock;
    [SerializeField]
    public Animator animator;
    // ジャンプの時間を計る為の変数
    public float cooltime;
    public PlayerColliderControl playerColliderControl;
    private Vector2 force;
    private bool _Freeze=true;
   #endregion
    void Awake()
    {
        // PlayerのRigidbodyを取得
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player_position = this.transform;
    }
    // Start
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update
    void Update()
    {

        if (gameMainContorl.PlayerFreeze)
        {
            Freeze();
        }
    }
    ////////////////////////////////////////////////////////
    //各動きなどの変数
    public void MoveAction()
    {
        animator.SetBool("Is_Run", true);
    }
    public void MoveStop()
    {
        //jumpflag = playerColliderControl.jumpflag;
        if (playerColliderControl.jumpflag)
            return;
        if (rb2d.velocity.x != 0)
        {
            StartCoroutine("Cooltime");
        }
        animator.SetBool("Is_Run", false);
    }
    IEnumerator Cooltime()
    {
        yield return new WaitForSeconds(0.25f);
        rb2d.velocity *= Vector2.up;
    }
    // プレイヤーの右移動
    public void MoveRight()
    {
        Vector2 scale = transform.localScale;
        scale.x = 100;
        direction = 1f;
        transform.localScale = scale;
        if (rb2d.velocity.x > 300.0 - debage)
            return;
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + movepawer * direction, 
                                                         this.gameObject.transform.position.y);
    }
    // プレイヤーの左移動
    public void MoveLeft()
    {
        Vector2 scale = transform.localScale;
        scale.x = -100;
        direction = -1f;
        transform.localScale = scale;
        if (rb2d.velocity.x < -300.0 + debage)
            return;
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + movepawer * direction, 
                                                         this.gameObject.transform.position.y);
    }
    // プレイヤーのジャンプ
    public void MoveJump()
    {
        rb2d.AddForce(Vector2.up * flap,ForceMode2D.Impulse);
        SoundManager.Instance.Play_SE(0, 2);
    }
    // 宝石の切り替え（左）
    public void CrystalChangeRight()
    {
        SoundManager.Instance.Play_SE(0, 3);
        switch (crystal)
        { 
            case Crystal.Reflect:
                crystal = Crystal.Gravity;

                break;
            case Crystal.Explosion:
                crystal = Crystal.Reflect;
                break;
            case Crystal.Gravity:
                crystal = Crystal.Explosion;

                break;
            default:
                break;
        }
    }
    // 宝石の切り替え（右）
    public void CrystalChangeLeft()
    {
        SoundManager.Instance.Play_SE(0, 3);
        switch (crystal)
        {
            case Crystal.Reflect:
                crystal = Crystal.Explosion;
                break;
            case Crystal.Gravity:
                crystal = Crystal.Reflect;
                break;
            case Crystal.Explosion:
                crystal = Crystal.Gravity;
                break;
            default:
                break;
        }
    }
    // ブロックの設置
    public void BlockInstanllation()
    {
        if (blockInstanllationflag)
            return;
        SoundManager.Instance.Play_SE(0, 5);
        fakeBlock.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
        //位置取得
        var pos = this.gameObject.transform.position;
        //プレハブ用意
        var Block_pos = Instantiate(Block, new Vector2(pos.x + 150 * direction, pos.y), Quaternion.identity) as GameObject;
        //親子設定
        Block_pos.transform.parent = CanvasTransform.transform;
        fakeBlock.gameObject.SetActive(false);
    }
    // 透明ブロックの設置
    public void FakeBlockInstanllation()
    {
        fakeBlock.gameObject.SetActive(true);
        fakeBlock.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 0.0f, 150.0f);
    }
    //public bool GetColliderScript()
    //{
    //    return nowBlockFlag;
    //}

    //public void SetColliderScript(bool flag)
    //{
    //    nowBlockFlag = flag;
    //}
    // スキルブロックの設置
    public void SkillBlockInstanllation()
    {
        switch (crystal)
        {
            
            case Crystal.Reflect:
                // 位置取得
                var Reflectpos = this.gameObject.transform.position;
                // プレハブ用意+設置
                var ReflectBlock_pos = Instantiate(Reflect_Block, new Vector2(Reflectpos.x + 150 * direction, Reflectpos.y), Quaternion.identity) as GameObject;
                // 親子設定
                ReflectBlock_pos.transform.parent = CanvasTransform.transform;
                fakeBlock.gameObject.SetActive(false);
                break;
            case Crystal.Gravity:
                // 位置取得
                var gravitypos = this.gameObject.transform.position;
                // プレハブ用意+設置
                var gravityBlock_pos = Instantiate(Granvity_Block, new Vector2(gravitypos.x + 150 * direction, gravitypos.y), Quaternion.identity) as GameObject;
                // 親子設定
                gravityBlock_pos.transform.parent = CanvasTransform.transform;
                fakeBlock.gameObject.SetActive(false);
                break;
            case Crystal.Explosion:
                // 位置取得
                var Explosionpos = this.gameObject.transform.position;
                // プレハブ用意+設置
                var ExplosionBlock_pos = Instantiate(Explosion_Block, new Vector2(Explosionpos.x + 150 * direction, Explosionpos.y), Quaternion.identity) as GameObject;
                // 親子設定
                ExplosionBlock_pos.transform.parent = CanvasTransform.transform;
                fakeBlock.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    // ブロックの設置キャンセル
    public void BlockInsatnallationCancel()
    {
        blockInstanllationflag = true;
        fakeBlock.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
       fakeBlock.gameObject.SetActive(false);
    }
    
    // 透明ブロックの削除
    public void FakeBlockOut()
    {
        fakeBlock.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
        //fakeBlock.gameObject.SetActive(false);
    }
    public void BlockFlagReset()
    {
        blockInstanllationflag = false;
    }
    public Crystal GetCrystalType()
    {
        return crystal;
    }
    public void LosePlayerControl()
    {
        XInputDotNetPure.GamePad.SetVibration(0, 0, 0);
        SceneManager.LoadScene("gameover");
    }
    public void StartAttackMove()
    {
        StartCoroutine("Animation_Cool_Time");
    }
    IEnumerator Animation_Cool_Time()
    {
        yield return new WaitForSeconds(3.0f);
    }
    public void player_atk()
    {
        animator.SetBool("Is_Atk", true);
        StartCoroutine("Atk_timer");
    }
    //プレイヤー硬直
    private void Freeze()
    {
        _Freeze = false;
        rb2d.velocity = Vector2.zero;
        //操作不可にする
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;

        StartCoroutine("timer");
    }
    //アタックタイム
    IEnumerator Atk_timer()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Is_Atk", false);
    }
    //ウィッチの固まる時間
    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        _Freeze = true;
    }
}
