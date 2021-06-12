using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WgBlockScript : MonoBehaviour
{
    [SerializeField]
    private float explosionTime;

    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;
    private  Rigidbody2D rbody;

    private void Awake()
    {
        //�R���C�_�[2D���擾
        boxCollider = GetComponent<BoxCollider2D>();
        //�X�v���C�g�����_���[�̎擾
        spriteRenderer = GetComponent<SpriteRenderer>();
        //�q�I�u�W�F�N�g���擾
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
        //���W�b�h�{�f�B���擾
        rbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hammer_atk"))
        {
            OnHitHammer(other);
        }

        //�G�̍U���̎�
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy_atk"))
        {
            //�ߋ���
            //�u���b�N(this)������
            Destroy(this.gameObject);
            //������
            //�u���b�N(this)�ƓG�̍U��������
        }
        //���ɓ���������
        if(other.gameObject.tag == "Water")
        {
            rbody.gravityScale = 0;
        }
        //�^���̓G�Ɠ��������ꍇ
        if(other.gameObject.tag == "Enemy")
        {
            //enemy�̍��W
            var enemy_pos = other.transform.position;
            //�u���b�N�̍��W
            var my_pos = transform.position;
            //y���W�̍�
            var pos_diff_y = my_pos.y - enemy_pos.y;
            //�����̔���
            var sign = Mathf.Sign(pos_diff_y);
            //���Ȃ�j��
            if(pos_diff_y > 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
    protected void OnHitHammer(Collision2D other)
    {
        //�J���[���ꎞ�ۑ�
        var color = spriteRenderer.color;
        //������
        spriteRenderer.color = new Color(color.r, color.g, color.b, 0f);
        //�����̓����蔻����I�t�ɂ���
        boxCollider.enabled = false;
        //----explosion�̈ʒu���U�����ꂽ�����ɂ���ĕύX����----
        //�n���}�[�̍��W
        var hammer_pos = other.transform.position;
        //�����̍��W
        var my_pos = transform.position;
        //x���W�̍�
        var pos_diff_x = my_pos.x - hammer_pos.x;
        //�����𔻒�
        var sign = Mathf.Sign(pos_diff_x);
        //explosion�̓����蔻��̃I�t�Z�b�g��ύX����
        var offset = boxCollider.offset;
        offset.x *= sign;
        explosion.offset = offset;
        //explosion�̃I�u�W�F�N�g��L��������
        explosion.gameObject.SetActive(true);

        StartCoroutine(DelayDestroy(explosionTime));
    }
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}