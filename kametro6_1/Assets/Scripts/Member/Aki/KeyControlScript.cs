using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControlScript : MonoBehaviour
{
    // ���X�g�̐���
    enum Crystal
    {
        Normal,
        Reflect,
        Gravity,
        Explosion,
    }
    // Crystal �̎��̉�
    [SerializeField]
    Crystal crystal = Crystal.Normal;
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
    // �u���b�N�̃t���O
    private bool blockFlag = false;
    // �����u���b�N�̃t���O
    private bool FakeblockFlag = false;
    //
    public float debage = 0.0f;
    // �v���C���[�̌���
    [SerializeField]
    private float direction = 1.0f;
    // Player��Rigidbody���擾���邽�߂̕ϐ�
    Rigidbody2D rb2d;
    // �ʏ�u���b�N�̓��ꕨ
    public GameObject Block;
    // �����u���b�N�̓��ꕨ
    public GameObject FakeBlock;
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
    Vector2 scale;
    BlockColliderScript blockcolliderScript;
    public GameObject previewBlock;
    void Awake()
    {
        // Player��Rigidbody���擾
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
    // �v���C���[�̉E�ړ�
    public void MoveRight()
    {
        Vector2 scale = transform.localScale;
        rb2d.AddForce(new Vector3(speed - debage, 0, 0));
        scale.x = 100;
        direction = 1f;
        transform.localScale = scale;
    }
    // �v���C���[�̍��ړ�
    public void MoveLeft()
    {
        Vector2 scale = transform.localScale;
        rb2d.AddForce(new Vector3(-speed + debage, 0, 0));
        scale.x = -100;
        direction = -1f;
        transform.localScale = scale;
    }
    // �v���C���[�̃W�����v
    public void MoveJump()
    {
        if (jumpflag)
            return;
        rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
        jumpflag = true;
    }
    // ��΂̐؂�ւ�
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
    // �u���b�N�̐ݒu
    public void BlockInstanllation()
    {
        // �����u���b�N�̍폜
        Destroy(previewBlock);
        if (blockcolliderScript.BlockInstallationFlag == true)
            return;
        //�ʒu�擾
        var pos = this.gameObject.transform.position;
        //�v���n�u�p��
        var Block_pos = Instantiate(Block, new Vector2(pos.x + 150 * direction, pos.y), Quaternion.identity) as GameObject;
        //�e�q�ݒ�
        Block_pos.transform.parent = CanvasTransform.transform;
    }
    // �����u���b�N�̐ݒu
    public void FakeBlockInstanllation()
    {
        blockInstanllationflag = false;
        // �ʒu�擾
        now_pos = this.gameObject.transform.position;
        // �v���n�u�p��
        previewBlock = Instantiate(FakeBlock, new Vector2(now_pos.x + 150 * direction, now_pos.y), Quaternion.identity) as GameObject;
        blockcolliderScript = previewBlock.GetComponent<BlockColliderScript>();
        // �e�q�֌W
        previewBlock.transform.parent = this.transform;
    }
    // �X�L���u���b�N�̐ݒu
    public void SkillBlockInstanllation()
    {
        switch (crystal){
            case Crystal.Reflect:
                // �����u���b�N�̍폜
                Destroy(previewBlock);
                if (blockcolliderScript.BlockInstallationFlag == true)
                    return;
                // �ʒu�擾
                var Reflectpos = this.gameObject.transform.position;
                // �v���n�u�p��+�ݒu
                var ReflectBlock_pos = Instantiate(Reflect_Block, new Vector2(Reflectpos.x + 150 * direction, Reflectpos.y), Quaternion.identity) as GameObject;
                // �e�q�ݒ�
                ReflectBlock_pos.transform.parent = CanvasTransform.transform;
                GameMainContol.Instance.PullCrystalCount();
                break;
            case Crystal.Gravity:
                // �����u���b�N�̍폜
                Destroy(previewBlock);
                if (blockcolliderScript.BlockInstallationFlag == true)
                    return;
                // �ʒu�擾
                var gravitypos = this.gameObject.transform.position;
                // �v���n�u�p��+�ݒu
                var gravityBlock_pos = Instantiate(Granvity_Block, new Vector2(gravitypos.x + 150 * direction, gravitypos.y), Quaternion.identity) as GameObject;
                // �e�q�ݒ�
                gravityBlock_pos.transform.parent = CanvasTransform.transform;
                break;
            case Crystal.Explosion:
                // �����u���b�N�̍폜
                Destroy(previewBlock);
                if (blockcolliderScript.BlockInstallationFlag == true)
                    return;
                // �ʒu�擾
                var Explosionpos = this.gameObject.transform.position;
                // �v���n�u�p��+�ݒu
                var ExplosionBlock_pos = Instantiate(Explosion_Block, new Vector2(Explosionpos.x + 150 * direction, Explosionpos.y), Quaternion.identity) as GameObject;
                // �e�q�ݒ�
                ExplosionBlock_pos.transform.parent = CanvasTransform.transform;
                break;
            default:
                break;
        }
    }
    // �u���b�N�̐ݒu�L�����Z��
    public void BlockInsatnallationCancel()
    {
        Destroy(previewBlock);
        blockInstanllationflag = true;
    }
    // �v�G�C���[�������鏈��
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
