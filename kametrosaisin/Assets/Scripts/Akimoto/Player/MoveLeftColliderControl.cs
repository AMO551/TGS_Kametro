using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftColliderControl : MonoBehaviour
{
    public static MoveLeftColliderControl Instance { get => _instance; }
    static MoveLeftColliderControl _instance;
    void Awake()
    {
        _instance = this;
    }
    // �E�����Ɉړ�����ۉE�̓����蔻���w�ʂɌŒ�
    public void RightMoveLeftCollider()
    {
        Vector2 position = transform.localPosition;
        position.x = -0.55f;
        transform.localPosition = position;
    }
    // �������Ɉړ�����ۉE�̓����蔻��𐳖ʂɌŒ�
    public void LeftMoveLeftCollider()
    {
        Vector2 position = transform.localPosition;
        position.x = 0.55f;
        transform.localPosition = position;
    }
}
