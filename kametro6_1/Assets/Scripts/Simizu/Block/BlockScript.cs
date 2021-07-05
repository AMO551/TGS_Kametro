using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private float explosionTime;

    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;

    private Animator anim = null;
    private void Awake() 
    {
        //�R���C�_�[2D���擾
        boxCollider = GetComponent<BoxCollider2D>();
        //�X�v���C�g�����_���[�̎擾
        spriteRenderer = GetComponent<SpriteRenderer>();
        //�q�I�u�W�F�N�g���擾
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
        //
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //�n���}�[�U���̎�
        if (other.gameObject.tag == "Hammer_atk")
        {
            OnHitHammer(other);
        }
  
        //�G�̍U���̎�
        if(other.gameObject.tag == "Enemy_atk")
        {
            //�ߋ���
            //�u���b�N(this)������
            Destroy(this.gameObject);
            //������
            //�u���b�N(this)�ƓG�̍U��������
        }
    }
    protected void OnHitHammer(Collision2D other)
    {

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
        Debug.Log(sign);
        //explosion�̓����蔻��̃I�t�Z�b�g��ύX����
        var offset = boxCollider.offset;
        offset.x = sign;
        explosion.offset = offset;
        //explosion�̃I�u�W�F�N�g��L��������
        explosion.gameObject.SetActive(true);

        //���u��
        //anim.SetTrigger("ex");
        

        StartCoroutine(DelayDestroy(explosionTime));
    }
    //���g�̔j��
    private IEnumerator DelayDestroy(float time)
    {
        Debug.Log("dex");
        yield return new WaitForSeconds(0.8f);
        
        Destroy(gameObject);
    }
}
