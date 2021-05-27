using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExBlockScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hammer_atk")
        {
            OnHitHammer(other);
        }
        else if (other.gameObject.tag == "Block_atk")
        {
            OnHitHammer(other);
        }
        else if (other.gameObject.tag == "Enemy_atk")
        {
            OnHitHammer(other);
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
        //explosionのオブジェクトを有効化する
        explosion.gameObject.SetActive(true);

        StartCoroutine(DelayDestroy(explosionTime));
    }
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
