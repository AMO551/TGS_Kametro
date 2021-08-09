using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region 宣言
    [SerializeField]
    private float explosionTime;
    private CircleCollider2D circleCollider;
    public GameObject obj;
    #endregion
    //スタート
    private void Start()
    {
        //オブジェクト生
        obj = new GameObject("Blast");
        //オブジェクトの当たり判定を生成
        obj.gameObject.AddComponent<CircleCollider2D>();
        //当たり判定の範囲を設定
       /// var radius = circleCollider.radius;
        //radius = 2;

        StartCoroutine(DelayDestroy(explosionTime));
    }
    //上で生成したオブジェクトの破壊
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }
    //自分が書いた覚え無し
    public void anin(Collision2D collision)
    {

        Destroy(collision.gameObject);
    }
}
