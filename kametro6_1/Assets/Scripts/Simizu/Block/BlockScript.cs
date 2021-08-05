using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    #region 宣言
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
        //コライダー2Dを取得
        boxCollider = GetComponent<BoxCollider2D>();
        //スプライトレンダラーの取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        //子オブジェクトを取得
        explosion = transform.Find("Explosion").GetComponent<BoxCollider2D>();
    }
    #region 当たり判定,関数処理
    private void OnCollisionEnter2D(Collision2D other)
    {
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("トリガーが呼ばれた");
        if (other.gameObject.tag == "P_A")
        {
            Debug.Log("プレイヤーアタックが呼ばれた");
            OnHitHammer(other);
        }
    }
    protected void OnHitHammer(Collider2D other)
    {
        #region 取得
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
        #endregion
        if (sign<0)
        {
            blockreversal = true;
        }
        //Debug.Log(sign);
        //explosionの当たり判定のオフセットを変更する
        var offset = boxCollider.offset;
        offset.x = sign;
        explosion.offset = offset;
        //explosionのオブジェクトを有効化する
        explosion.gameObject.SetActive(true);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DelayDestroy(explosionTime));
    }
    #endregion
    //自身の破壊
    private IEnumerator DelayDestroy(float time)
    {
        Debug.Log("dex");
        yield return new WaitForSeconds(0.8f);
        
        Destroy(gameObject,0.4f);
    }
}

