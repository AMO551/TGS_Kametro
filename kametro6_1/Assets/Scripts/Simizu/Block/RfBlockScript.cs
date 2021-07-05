using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RfBlockScript : MonoBehaviour
{
    [SerializeField]
    private float explosionTime;

    private BoxCollider2D boxCollider;
    private BoxCollider2D explosion;
    private SpriteRenderer spriteRenderer;

    private Animator anime;
    private void Awake()
    {
        //コライダー2Dを取得
        boxCollider = GetComponent<BoxCollider2D>();
        //スプライトレンダラーの取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        //子オブジェクトを取得
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();

        anime = transform.Find("rfanimetion").GetComponent<Animator>();
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //ハンマー攻撃の時
        if (other.gameObject.tag == "Hammer_atk")
        {
            OnHitHammer(other);
        }

        //敵の攻撃の時
        if (other.gameObject.tag == "Enemy_atk") 
        {
            //ブロック(this)を消す
            Destroy(this.gameObject);
        }
        //遠距離
        if(other.gameObject.tag == "Witch_ball")
        {
            anime.SetTrigger("rf");
            StartCoroutine(DelayDestroy(explosionTime));
        }
    }
    protected void OnHitHammer(Collision2D other)
    {
       
        //自分の当たり判定をオフにする
        boxCollider.enabled = false;
        //----explosionの位置を攻撃された方向によって変更する----
        //ハンマーの座標
        var hammer_pos = other.transform.position;
        //自分の座標
        var my_pos = transform.position;
        //x座標の差
        var pos_diff_x = my_pos.x - hammer_pos.x;
        //符号を判定
        var sign = Mathf.Sign(pos_diff_x);
        //explosionの当たり判定のオフセットを変更する
        var offset = boxCollider.offset;
        offset.x = sign;
        explosion.offset = offset;
        //explosionのオブジェクトを有効化する
        explosion.gameObject.SetActive(true);

        //デバッグ用
        //anime.SetTrigger("rf");

        StartCoroutine(DelayDestroy(explosionTime));
    }
    //自身の破壊
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);
    }
}