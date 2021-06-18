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

    private void Awake() 
    {
        //コライダー2Dを取得
        boxCollider = GetComponent<BoxCollider2D>();
        //スプライトレンダラーの取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        //子オブジェクトを取得
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //ハンマー攻撃の時
        if (other.gameObject.tag == "Hammer_atk")
        {
            OnHitHammer(other);
        }
  
        //敵の攻撃の時
        if(other.gameObject.tag == "Enemy_atk")
        {
            //近距離
            //ブロック(this)を消す
            Destroy(this.gameObject);
            //遠距離
            //ブロック(this)と敵の攻撃を消す
        }
    }
    protected void OnHitHammer(Collision2D other)
    {
        //カラーを一時保存
        var color = spriteRenderer.color;
        //透明化
        spriteRenderer.color = new Color(color.r, color.g, color.b, 0f);
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
        offset.x *= sign;
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
}
