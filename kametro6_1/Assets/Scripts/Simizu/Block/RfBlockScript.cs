using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RfBlockScript : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private float explosionTime;

    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    public float gravitPower = 0;
    private Animator anime;
    #endregion
    private void Awake()
    {
        //�R���C�_�[2D���擾
        boxCollider = GetComponent<BoxCollider2D>();
        //�X�v���C�g�����_���[�̎擾
        spriteRenderer = GetComponent<SpriteRenderer>();
        //�q�I�u�W�F�N�g���擾
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
        rb2d = this.GetComponent<Rigidbody2D>();
        //anime = transform.Find("rfanimetion").GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        rb2d.gravityScale = gravitPower;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        //�G�̍U���̎�
        if (other.gameObject.tag == "Enemy_atk")
        {
            //�ߋ���
            //�u���b�N(this)������
            Destroy(this.gameObject);
            //������
            //�G�̍U���𔽎�

        }
        //������
        if (other.gameObject.tag == "Witch_ball")
        {
            anime.SetTrigger("rf");
            StartCoroutine(DelayDestroy(explosionTime));
        }
    }
    private IEnumerator DelayDestroy(float time=2f)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject,2f);
    }
}