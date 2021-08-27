using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExBlockScript : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private float explosionTime;

    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;
    private bool EX = false;
    Animator anime;
    #endregion
    private void Awake() 
    {
        //�R���C�_�[2D���擾
        boxCollider = GetComponent<BoxCollider2D>();
        //�X�v���C�g�����_���[�̎擾
        spriteRenderer = GetComponent<SpriteRenderer>();
        //�q�I�u�W�F�N�g���擾
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EX_End");
        anime = transform.Find("Explosion").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EX)
            this.gameObject.GetComponent<Explosion>().enabled = true;
    }
    IEnumerator EX_End()
    {
        yield return new WaitForSeconds(5f);
        EX = true;
        this.gameObject.GetComponent<Explosion>().enabled = true;
        anime.SetTrigger("ex");
        yield return new WaitForSeconds(2f);
        anime.SetTrigger("endex");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "P_A")
        {
            //�����ɃJ�E���g�ǉ�

            OnHitHammer(other);
        }else if (other.gameObject.tag == "Block_atk")
        {
            OnHitHammer(other);
        }
        else if (other.gameObject.tag == "Enemy_atk")
        {
            OnHitHammer(other);
        }
    }
    protected void OnHitHammer(Collider2D other)
    {
        SoundManager.Instance.Play_SE(2, 7);
        //�J���[���ꎞ�ۑ�
        var color = spriteRenderer.color;
        //������
        spriteRenderer.color = new Color(color.r, color.g, color.b, 0f);
        //�����̓����蔻����I�t�ɂ���
        boxCollider.enabled = false;
        //explosion�̃I�u�W�F�N�g��L��������
        explosion.gameObject.SetActive(true);

        StartCoroutine(DelSayDestroy(explosionTime));
    }
    private IEnumerator DelSayDestroy(float time=1f)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
