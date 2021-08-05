using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RfBlockScript : MonoBehaviour
{
    #region 宣言
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
        //コライダー2Dを取得
        boxCollider = GetComponent<BoxCollider2D>();
        //スプライトレンダラーの取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        //子オブジェクトを取得
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

        //敵の攻撃の時
        if (other.gameObject.tag == "Enemy_atk")
        {
            //近距離
            //ブロック(this)を消す
            Destroy(this.gameObject);
            //遠距離
            //敵の攻撃を反射

        }
        //遠距離
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