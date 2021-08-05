using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WgBlockScript : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private float explosionTime;

    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;
    private  Rigidbody2D rbody;
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
        //���W�b�h�{�f�B���擾
        rbody = GetComponent<Rigidbody2D>();

        anime = transform.Find("wganimetion").GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //�n�ʂɗ�������
        if (other.gameObject.tag == "ground")
        {
            SoundManager.Instance.Play_SE(2, 9);
            anime.SetTrigger("wg");
            Invoke("AnimeEnd", 0.8f);
        }
       

        //�G�̍U���̎�
        if (other.gameObject.tag == "Enemy_atk")
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
    private void AnimeEnd()
    {
        Debug.Log("animeowari");
        anime.SetTrigger("wg");
    }
}
