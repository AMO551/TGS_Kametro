using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlev2 : MonoBehaviour
{
    bool change = true;
    #region 宣言
    //fada変数の呼び出し
    [Header("フェード")] public Fade fade;
    //フェイドを何回も呼ばれないようにするだめのもの
    private bool goNextScene = false;
    //アップデート管理
    public bool mane = true;
    #endregion
    //Start
    private void Start()
    {
        //ステージに行くトリガーを初期化
        goNextScene = false;
    }
    //Update
    private void Update()
    {
        if (mane)
        {
            #region 毎フレーム呼び出す
            //recttransformを取得
            RectTransform pos;
            pos = GetComponent<RectTransform>();
            //デバッグ用 key-vertical
            float kv = Input.GetAxis("Vertical");
            #endregion
            //下入力
            if (/*dpv < 0 || */kv < 0)
            {
                SoundManager.Instance.Play_SE(1, 27);
                //Debug.Log("-360");
                //矢印上の位置へ
                pos.localPosition = new Vector3(-330, -360, 0);
             

            }
            //上入力
            if (/*dpv > 0 ||*/ kv > 0)
            {
                SoundManager.Instance.Play_SE(1, 27);
                //Debug.Log("-180");
                //矢印下の位置へ
                pos.localPosition = new Vector3(-330, -180, 0);
               

            }
            //とりあえず仮置きの決定ボタン
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.Instance.Play_SE(1, 26);
                //Debug.Log("入力さえた");
                //フェードアウトスタート
                fade.StartFadeOut();
            }
            //画面遷移
            if (fade.IsFadeOutComplete() && !goNextScene)
            {
               
                //矢印が上だった場合Turorialにシーン切り替え
                if (pos.localPosition.y == -180)
                {
                     GameMainContol.Instance.scenes_contol(1); 
                    StartCoroutine(NextScene());

                    //シーンの切り替え
                    //SceneManager.LoadScene("StoryScene");
                    goNextScene = true; //シーンが何回も呼ばれないように
                }
                //矢印が下だった場合first halfにシーン切り替え
                if (pos.localPosition.y == -360)
                {
                    GameMainContol.Instance.scenes_contol(2);
                    StartCoroutine(NextScene());
                    //シーンの切り替え
                    //SceneManager.LoadScene("StoryScene");
                    goNextScene = true; //シーンが何回も呼ばれないように
                }
            }
        }
    }
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("StoryScene");
    }
}
