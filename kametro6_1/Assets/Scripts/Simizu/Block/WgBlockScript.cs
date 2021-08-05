using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WgBlockScript : MonoBehaviour
{
    #region 宣言
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
        if (other.gameObject.tag == "ground")
        {
            SoundManager.Instance.Play_SE(2, 9);
            anime.SetTrigger("wg");
            Invoke("AnimeEnd", 0.8f);
        }
       

        //敵の攻撃の時
        if (other.gameObject.tag == "Enemy_atk")
        {
            //近距離
            //ブロック(this)を消す
            Destroy(this.gameObject);
            //遠距離
            //ブロック(this)と敵の攻撃を消す
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
    private void AnimeEnd()
    {
        Debug.Log("animeowari");
        anime.SetTrigger("wg");
    }
}
