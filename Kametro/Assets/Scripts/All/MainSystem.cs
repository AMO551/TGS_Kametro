using UnityEngine;

/// <summary>
/// ゲームのすべての管理
/// </summary>
public abstract class MainSystem : MonoBehaviour
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
    /// UI以外の描画
    /// </summary>
    protected abstract void Draw();

    /// <summary>
    /// UI描画
    /// </summary>
    protected abstract void UISystem();

    /// <summary>
    /// 破棄
    /// </summary>
    protected abstract void Dest();
}