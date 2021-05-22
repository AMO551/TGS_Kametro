using UnityEngine;

/// <summary>
/// 敵
/// </summary>
public abstract class Enemy : MonoBehaviour
{
    //---public-------------------------------------------------------


    //---private------------------------------------------------------


    //---protected----------------------------------------------------
    /// <summary>
    /// 初期化
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// メイン処理
    /// </summary>
    protected abstract void Main();

    /// <summary>
    /// 描画
    /// </summary>
    protected abstract void Draw();

    /// <summary>
    /// 破棄
    /// </summary>
    protected abstract void Dest();
}