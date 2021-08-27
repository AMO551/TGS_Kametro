using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get => _instance; }
    static ColorManager _instance;
    // 色を変えたいオブジェクトをリスト化
    [SerializeField]
    List<SpriteRenderer> colorlist = new List<SpriteRenderer>();
    // 入力番号を覚える為の変数
    private int changcolor;
    void Awake()
    {
        _instance = this;
    }
    // 色変更スクリプト(リストの番号を記入)
    public void ChangeColor(int color_num)
    {
        changcolor = color_num;
        StartCoroutine("Cooltime");
    }
    IEnumerator Cooltime()
    {
        // 赤く変更
        colorlist[changcolor].color = new Color(180.0f / 255f, 30.0f / 255f, 25.0f / 255f, 210.0f / 255f);
        yield return new WaitForSeconds(1.0f);
        // もとに戻す
        colorlist[changcolor].color = new Color(255.0f / 255f, 255.0f / 255f, 255.0f / 255f, 255.0f / 255f);
    }
}