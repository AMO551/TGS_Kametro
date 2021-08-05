using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    #region 宣言
    [Header("フェード")] public Fade fade;
    private bool goNextScene = false;
    private float pos_y;
    [SerializeField]
    GameMainContol gameMainContol;
    #endregion
    //Update
    private void Update()
    {
        #region　毎フレーム呼び出す
        //recttransformを取得
        RectTransform pos;
        pos = GetComponent<RectTransform>();
        //デバッグ用 key-vertical
        float kv = Input.GetAxis("Vertical");
        #endregion
        //下入力
        if (kv < 0)
        {
            Debug.Log("-360");
            //矢印上の位置へ
            pos.localPosition = new Vector3(-470, -360, 0);

        }
        //上入力
        if (kv > 0)
        {
            Debug.Log("-180");
            //矢印下の位置へ
            pos.localPosition = new Vector3(-470, -180, 0);

        }
        //とりあえず仮置きの決定ボタン
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("入力さえた");
            //フェードアウトスタート
            fade.StartFadeOut();
        }
        //画面遷移
        if (fade.IsFadeOutComplete() && !goNextScene)
        {
            //-90ifの条件を追加予定
            //ゲームを続ける
            if (pos.localPosition.y == -180)
            {
                //チュートリアル
                if (GameMainContol.Instance.SetScenes() == 1)
                {//ダンジョンの最初から用
                    SceneManager.LoadScene("tutorial");
                    goNextScene = true;
                }
                //ステージ１
                if (GameMainContol.Instance.SetScenes() == 2)
                {//ステージ１から用
                    SceneManager.LoadScene("first half");
                    goNextScene = true;
                }
                //ステージ２
                if (GameMainContol.Instance.SetScenes() == 3)
                { //ステージ２から用
                    SceneManager.LoadScene("second half");
                    goNextScene = true;
                }
                //中間地点
                if (GameMainContol.Instance.SetScenes() == 4)
                {//ボス戦から用
                    SceneManager.LoadScene("Safe Zone");
                    goNextScene = true;
                }
            }
            //タイトルに戻る
            if (pos.localPosition.y == -360)
            {
                SceneManager.LoadScene("title");
                goNextScene = true;
            }
        }
    }
}
