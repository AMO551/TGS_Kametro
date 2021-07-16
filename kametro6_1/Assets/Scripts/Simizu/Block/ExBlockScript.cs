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
        //コライダー2Dを取得
        boxCollider = GetComponent<BoxCollider2D>();
        //スプライトレンダラーの取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        //ハンマー攻撃の時
        if (other.gameObject.tag == "Hammer_atk")
        {
            OnHitHammer(other);
        }
        //ブロック攻撃の時
        else if (other.gameObject.tag == "Block_atk")
        {
            OnHitHammer(other);
        }
        //エネミー攻撃の時
        else if (other.gameObject.tag == "Enemy_atk")
        {
            OnHitHammer(other);
        }
    }
    protected void OnHitHammer(Collision2D other)
    {
        //自分の当たり判定をオフにする
        boxCollider.enabled = false;
        //ここに爆破属性クラス？の呼び出しを書く
        Instantiate<GameObject>(ex_effect, transform);

        anim.SetTrigger("ex");
        StartCoroutine(DelayDestroy(explosionTime));
    }
    //自身の破壊
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
