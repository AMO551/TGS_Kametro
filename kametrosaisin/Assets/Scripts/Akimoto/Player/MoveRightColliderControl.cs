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
    // ‰E•ûŒü‚ÉˆÚ“®‚·‚éÛ‰E‚Ì“–‚½‚è”»’è‚ğ³–Ê‚ÉŒÅ’è
    public void RightMoveRightCollider()
    {
        Vector2 position = transform.localPosition;
        position.x = 0.55f;
        transform.localPosition = position;
    }
    // ¶•ûŒü‚ÉˆÚ“®‚·‚éÛ‰E‚Ì“–‚½‚è”»’è‚ğ”w–Ê‚ÉŒÅ’è
    public void LeftMoveRightCollder()
    {
        Vector2 position = transform.localPosition;
        position.x = -0.55f;
        transform.localPosition = position;
    }
}
