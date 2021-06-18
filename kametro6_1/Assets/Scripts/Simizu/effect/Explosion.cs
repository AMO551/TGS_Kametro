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
        //�I�u�W�F�N�g����
        obj = new GameObject("Blast");
        //�I�u�W�F�N�g�̓����蔻��𐶐�
        obj.gameObject.AddComponent<CircleCollider2D>();
        //�����蔻��͈̔͂�ݒ�
        var radius = circleCollider.radius;
        radius = 2;

        StartCoroutine(DelayDestroy(explosionTime));
    }
    //��Ő��������I�u�W�F�N�g�̔j��
    private IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(1f);

        Destroy(obj);
    }
    //�������������o������
    public void anin(Collision2D collision)
    {

        Destroy(collision.gameObject);
    }
}
