using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class KeyControlScript : MonoBehaviour
{
    #region �錾
    // ���X�g�̐���
    public enum Crystal
    {
        Reflect, 
        Explosion,
        Gravity,
    }
    // Crystal �̎��̉�
    [SerializeField]
    public Crystal crystal = Crystal.Reflect;
    // ������A�^�b�`�ł��Ȃ��悤��
    public static KeyControlScript instance = null;
    // �v���C���[�̑���
    public float speed = 0.0f;
    // �v���C���[�̃W�����v��
    public float flap = 0.0f;
    // �v���C���[���n�ʏォ�ǂ����̃t���O
    public bool jumpflag = false;
    // �v���C���[�̍��̈ʒu������ϐ�
    public Vector2 now_pos;
    //�Ő��ő���x������
    public float debage = 0.0f;
    public Transform player_position;
    // �v���C���[�̌���
    [SerializeField]
    public float direction = 1.0f;
    // Player��Rigidbody���擾���邽�߂̕ϐ�
    Rigidbody2D rb2d;
    // �ʏ�u���b�N�̓��ꕨ
    public GameObject Block;
    // ���˃u���b�N�̓��ꕨ
    public GameObject Reflect_Block;
    // �d�̓u���b�N�̓��ꕨ
    public GameObject Granvity_Block;
    // ���j�u���b�N�̓��ꕨ
    public GameObject Explosion_Block;
    // �v���n�u�̐e�̓��ꕨ
    public Transform CanvasTransform;
    // �u���b�N�̐ݒu�t���O
    public bool blockInstanllationflag = true;
    // �v���C���[�̈ړ��̗͗p�ϐ�
    public float movepawer = 0.0f;

    //BlockColliderScript blockcolliderScript;
    public GameMainContol gameMainContorl;
    //public GameObject previewBlock;
    public bool nowBlockFlag = false;
    [SerializeField]
    public GameObject fakeBlock;
    [SerializeField]
    public Animator animator;
    // �W�����v�̎��Ԃ��v��ׂ̕ϐ�
    public float cooltime;
    public PlayerColliderControl playerColliderControl;
    private Vector2 force;
    private bool _Freeze=true;
   #endregion
    void Awake()
    {
        // Player��Rigidbody���擾
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
    //�e�����Ȃǂ̕ϐ�
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
    // �v���C���[�̉E�ړ�
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
    // �v���C���[�̍��ړ�
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
    // �v���C���[�̃W�����v
    public void MoveJump()
    {
        rb2d.AddForce(Vector2.up * flap,ForceMode2D.Impulse);
        SoundManager.Instance.Play_SE(0, 2);
    }
    // ��΂̐؂�ւ��i���j
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
    // ��΂̐؂�ւ��i�E�j
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
    // �u���b�N�̐ݒu
    public void BlockInstanllation()
    {
        if (blockInstanllationflag)
            return;
        SoundManager.Instance.Play_SE(0, 5);
        fakeBlock.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
        //�ʒu�擾
        var pos = this.gameObject.transform.position;
        //�v���n�u�p��
        var Block_pos = Instantiate(Block, new Vector2(pos.x + 150 * direction, pos.y), Quaternion.identity) as GameObject;
        //�e�q�ݒ�
        Block_pos.transform.parent = CanvasTransform.transform;
        fakeBlock.gameObject.SetActive(false);
    }
    // �����u���b�N�̐ݒu
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
    // �X�L���u���b�N�̐ݒu
    public void SkillBlockInstanllation()
    {
        switch (crystal)
        {
            
            case Crystal.Reflect:
                // �ʒu�擾
                var Reflectpos = this.gameObject.transform.position;
                // �v���n�u�p��+�ݒu
                var ReflectBlock_pos = Instantiate(Reflect_Block, new Vector2(Reflectpos.x + 150 * direction, Reflectpos.y), Quaternion.identity) as GameObject;
                // �e�q�ݒ�
                ReflectBlock_pos.transform.parent = CanvasTransform.transform;
                fakeBlock.gameObject.SetActive(false);
                break;
            case Crystal.Gravity:
                // �ʒu�擾
                var gravitypos = this.gameObject.transform.position;
                // �v���n�u�p��+�ݒu
                var gravityBlock_pos = Instantiate(Granvity_Block, new Vector2(gravitypos.x + 150 * direction, gravitypos.y), Quaternion.identity) as GameObject;
                // �e�q�ݒ�
                gravityBlock_pos.transform.parent = CanvasTransform.transform;
                fakeBlock.gameObject.SetActive(false);
                break;
            case Crystal.Explosion:
                // �ʒu�擾
                var Explosionpos = this.gameObject.transform.position;
                // �v���n�u�p��+�ݒu
                var ExplosionBlock_pos = Instantiate(Explosion_Block, new Vector2(Explosionpos.x + 150 * direction, Explosionpos.y), Quaternion.identity) as GameObject;
                // �e�q�ݒ�
                ExplosionBlock_pos.transform.parent = CanvasTransform.transform;
                fakeBlock.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    // �u���b�N�̐ݒu�L�����Z��
    public void BlockInsatnallationCancel()
    {
        blockInstanllationflag = true;
        fakeBlock.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
       fakeBlock.gameObject.SetActive(false);
    }
    
    // �����u���b�N�̍폜
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
    //�v���C���[�d��
    private void Freeze()
    {
        _Freeze = false;
        rb2d.velocity = Vector2.zero;
        //����s�ɂ���
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;

        StartCoroutine("timer");
    }
    //�A�^�b�N�^�C��
    IEnumerator Atk_timer()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Is_Atk", false);
    }
    //�E�B�b�`�̌ł܂鎞��
    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        _Freeze = true;
    }
}
