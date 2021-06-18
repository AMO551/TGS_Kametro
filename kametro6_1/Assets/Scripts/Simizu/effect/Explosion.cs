using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float explosionTime;
    private CircleCollider2D circleCollider;
    public GameObject obj;
    private void Start()
    {
        //オブジェクト生成
        obj = new GameObject("Blast");
        //オブジェクトの当たり判定を生成
        obj.gameObject.AddComponent<CircleCollider2D>();
        //当たり判定の範囲を設定
        var radius = circleCollider.radius;
        radius = 2;

        StartCoroutine(DelayDestroy(explosionTime));
    }
    //上で生成したオブジェクトの破壊
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(obj);
    }
    //自分が書いた覚え無し
    public void anin(Collision2D collision)
    {

        Destroy(collision.gameObject);
    }
}
