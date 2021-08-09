using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    #region 宣言
    [Header("最初からフェードインが完了しているかどうか")] public bool firstFadeInComp;
    private Image img = null;           //イメージを取得
    private int frameCount = 0;         //フレームの確認
    private float timer = 0.0f;         //フェイドタイマー
    private bool fadeIn = false;        //フェイドイン以外を呼ばせないもの
    private bool fadeOut = false;       //フェイドアウト以外を呼ばせないもの
    private bool compFadeIn = false;    //フェイドイン中かの判定
    private bool compFadeOut = false;   //フェイドアウト中かの判定
    #endregion
    #region Start
    // Start
    void Start()
    {
        //イメージの初期化
        img = GetComponent<Image>();
        if (firstFadeInComp)
        {
            FadeInComplete();
        }
        else
        {
            StartFadeIn();
        }
    }
    #endregion
    #region Update
    // Update
    void Update()
    {
        //思いらしいので2フレーム待つ
        if (frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();
            }
            else if (fadeOut)
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }
    #endregion
    #region フェイドイン
    //フェードインを開始する
    public void StartFadeIn()
    {
        //fadeInかfadeOutどちらかが呼ばれていないか
        if (fadeIn || fadeOut)
        {
            //呼ばれている場合処理を終わる
            return;
        }
        //fadeInが呼ばれた
        fadeIn = true;
        //！（フェイドインしている）
        compFadeIn = false;
        //フェイドタイマーの初期化
        timer = 0.0f;
        //イメージを用意してカラーを黒にする
        img.color = new Color(1, 1, 1, 1);
        //フェイドインの動き
        img.fillAmount = 1;
    }
    //フェードインが完了したかどうか
    public bool IsFadeInComplete()
    {
        return compFadeIn;
    }
    //フェードイン
    private void FadeInUpdate()
    {
        //フェード中
        if (timer < 1f)
        {
            //1,1,1,1は元の色を使うという意
            img.color = new Color(1, 1, 1, 1 - timer);
            img.fillAmount = 1 - timer;
        }
        //フェード完了
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }
    //フェイドイン初期化
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        //当たり判定off
        img.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    #endregion
    #region フェイドアウト
    //フェードアウトを開始する
    public void StartFadeOut()
    {
        //fadeInかfadeOutどちらかが呼ばれていないか
        if (fadeIn || fadeOut)
        {
            //呼ばれている場合処理を終わる
            return;
        }
        //fadeOutが呼ばれた
        fadeOut = true;
        //！（フェイドアウトしている）
        compFadeOut = false;
        //フェイドタイマーの初期化
        timer = 0.0f;
        //イメージを用意してカラーを黒にする
        img.color = new Color(1, 1, 1, 0);
        ///フェイドアウトの動き
        img.fillAmount = 1;
    }
    //フェードアウトが完了したかどうか
    public bool IsFadeOutComplete()
    {
        return compFadeOut;
    }
    //フェードアウト
    private void FadeOutUpdate()
    {
        //フェード中
        if (timer < 1f)
        {
            //1,1,1,1は元の色を使うという意
            img.color = new Color(1, 1, 1, timer);
            img.fillAmount = timer;
        }
        //フェード完了
        else
        {
            FadeOutComplete();
        }
        timer += Time.deltaTime;
    }
    //フェイドアウト初期化
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 0;
        //当たり判定off
        img.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;
        compFadeOut = true;
    }
    #endregion
}
