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
         obj = new GameObject("Blast");
        obj.gameObject.AddComponent<CircleCollider2D>();
        var radius = circleCollider.radius;
        radius = 2;

        StartCoroutine(DelayDestroy(explosionTime));
    }
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(obj);
    }

 public void anin(Collision2D collision)
    {

        Destroy(collision.gameObject);
    }
}
