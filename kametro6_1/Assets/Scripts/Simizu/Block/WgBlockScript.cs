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
    private Animator anime;

    private void Awake()
    {
        //コライダー2Dを取得
        boxCollider = GetComponent<BoxCollider2D>();
        //スプライトレンダラーの取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        //子オブジェクトを取得
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
        //リジッドボディを取得
        rbody = GetComponent<Rigidbody2D>();

        anime = transform.Find("wganimetion").GetComponent<Animator>();
    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        //地面に落ちた時
        if(other.gameObject.tag == "ground")
        {
            anime.SetTrigger("wg");
            Invoke("AnimeEnd", 0.8f);
        }
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
        //水に当たった時
        if(other.gameObject.tag == "Water")
        {
            rbody.gravityScale = 0;
        }
        //真下の敵と当たった場合
        if(other.gameObject.tag == "Enemy")
        {
            //enemyの座標
            var enemy_pos = other.transform.position;
            //ブロックの座標
            var my_pos = transform.position;
            //y座標の差
            var pos_diff_y = my_pos.y - enemy_pos.y;
            //符号の判定
            var sign = Mathf.Sign(pos_diff_y);
            //正なら破壊
            if(pos_diff_y > 0)
            {
                Destroy(other.gameObject);
            }
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

        StartCoroutine(DelayDestroy(explosionTime));
    }
    //自身の破壊
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
    private void AnimeEnd()
    {
        Debug.Log("animeowari");
        anime.SetTrigger("wg");
    }
}
