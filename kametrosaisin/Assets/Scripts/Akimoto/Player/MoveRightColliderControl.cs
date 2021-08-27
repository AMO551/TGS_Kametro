using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightColliderControl : MonoBehaviour
{
    public static MoveRightColliderControl Instance { get => _instance; }
    static MoveRightColliderControl _instance;
    void Awake()
    {
        _instance = this;
    }
    // �E�����Ɉړ�����ۉE�̓����蔻��𐳖ʂɌŒ�
    public void RightMoveRightCollider()
    {
        Vector2 position = transform.localPosition;
        position.x = 0.55f;
        transform.localPosition = position;
    }
    // �������Ɉړ�����ۉE�̓����蔻���w�ʂɌŒ�
    public void LeftMoveRightCollder()
    {
        Vector2 position = transform.localPosition;
        position.x = -0.55f;
        transform.localPosition = position;
    }
}
