using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private float explosionTime;
    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;
    public bool blockreversal = false;
    #endregion
    //Awake
    private void Awake() 
    {
        SoundManager.Instance.Play_SE(2, 7);
        //�R���C�_�[2D���擾
        boxCollider = GetComponent<BoxCollider2D>();
        //�X�v���C�g�����_���[�̎擾
        spriteRenderer = GetComponent<SpriteRenderer>();
        //�q�I�u�W�F�N�g���擾
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
    }
    #region �����蔻��,�֐�����
    private void OnCollisionEnter2D(Collision2D other)
    {
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�g���K�[���Ă΂ꂽ");
        if (other.gameObject.tag == "P_A")
        {
            Debug.Log("�v���C���[�A�^�b�N���Ă΂ꂽ");
            OnHitHammer(other);
        }
    }
    protected void OnHitHammer(Collider2D other)
    {
        #region �擾
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
        #endregion
        if (sign<0)
        {
            blockreversal = true;
        }
        //Debug.Log(sign);
        //explosion�̓����蔻��̃I�t�Z�b�g��ύX����
        var offset = boxCollider.offset;
        offset.x = sign;
        explosion.offset = offset;
        //explosion�̃I�u�W�F�N�g��L��������
        explosion.gameObject.SetActive(true);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DelayDestroy(explosionTime));
    }
    #endregion
    //���g�̔j��
    private IEnumerator DelayDestroy(float time)
    {
        Debug.Log("dex");
        yield return new WaitForSeconds(0.8f);
        
        Destroy(gameObject,0.4f);
    }
}

