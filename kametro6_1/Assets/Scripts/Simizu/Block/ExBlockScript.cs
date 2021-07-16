using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExBlockScript : MonoBehaviour
{
    [SerializeField]
    private float explosionTime;
    [SerializeField]
    private GameObject ex_effect;

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

        anim = GetComponent<Animator>();
    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        //�n���}�[�U���̎�
        if (other.gameObject.tag == "Hammer_atk")
        {
            OnHitHammer(other);
        }
        //�u���b�N�U���̎�
        else if (other.gameObject.tag == "Block_atk")
        {
            OnHitHammer(other);
        }
        //�G�l�~�[�U���̎�
        else if (other.gameObject.tag == "Enemy_atk")
        {
            OnHitHammer(other);
        }
    }
    protected void OnHitHammer(Collision2D other)
    {
        //�����̓����蔻����I�t�ɂ���
        boxCollider.enabled = false;
        //�����ɔ��j�����N���X�H�̌Ăяo��������
        Instantiate<GameObject>(ex_effect, transform);

        anim.SetTrigger("ex");
        StartCoroutine(DelayDestroy(explosionTime));
    }
    //���g�̔j��
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
