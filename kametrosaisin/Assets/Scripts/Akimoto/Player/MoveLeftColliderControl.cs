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
    // ‰E•ûŒü‚ÉˆÚ“®‚·‚éÛ‰E‚Ì“–‚½‚è”»’è‚ğ”w–Ê‚ÉŒÅ’è
    public void RightMoveLeftCollider()
    {
        Vector2 position = transform.localPosition;
        position.x = -0.55f;
        transform.localPosition = position;
    }
    // ¶•ûŒü‚ÉˆÚ“®‚·‚éÛ‰E‚Ì“–‚½‚è”»’è‚ğ³–Ê‚ÉŒÅ’è
    public void LeftMoveLeftCollider()
    {
        Vector2 position = transform.localPosition;
        position.x = 0.55f;
        transform.localPosition = position;
    }
}
