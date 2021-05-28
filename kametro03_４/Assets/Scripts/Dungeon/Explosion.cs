using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float explosionTime;
    private CircleCollider2D circleCollider;
    private void Start()
    {
        var obj = new GameObject("Blast");
        gameObject.AddComponent<CircleCollider2D>();
        var radius = circleCollider.radius;
        radius = 2;

        StartCoroutine(DelayDestroy(explosionTime));
    }
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
