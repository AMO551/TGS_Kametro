using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainContol : MonoBehaviour
{
    #region 宣言
    public static GameMainContol Instance { get => _instance; }
    static GameMainContol _instance;
    // プレイヤーのHP
    public float player_HP = 10;
    // エネミーのATK
    public float tNT_ATK = 4;
    // エネミーのATK
    public float witch_ATK = 3;
    // エネミーのATK
    public float human_ATK = 2;
    // エネミーのATK
    public float golem_ATK_No1 = 4;
    // エネミーのATK
    public float golem_ATK_No2 = 3;
    // エネミーのATK
    public float golem_ATK_No3 = 2;
    //毒ダメージ
    public float Poison_ATK = 1;
    // 鉱石の個数
    public float reflectcrystalCount = 5;
    public float gravitycrystalCount = 0;
    public float explosioncrystalCount = 0;
    // 回復薬の値 
    public float healingNUM = 10;
    public float blockmeta = 100;
    public float pullmeta = 0;
    //シーンの管理
    [SerializeField]
    static private int scenes = 1;
    //鉱石取得の確認
    public bool getCrystal=false;
    public int getReCrystal = 0;
    public int getGrCrystal = 0;
    public int getExCrystal = 0;
    //Playerfreeze(硬直)
    public bool PlayerFreeze = false;

    // 時間
    public float time;
    // GameOverした回数
    public float gameOverCount = 0;
    public int SetScenes()
    {
        return scenes;
    }
    #endregion
    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        //Debug.Log(scenes);
    }
    // 爆発によるダメージ計算
    public void TNTPlayerDamege()
    {
        player_HP -= tNT_ATK;
    }
    // ウィッチによるダメージ計算
    public void WitchPlayerDamege()
    {
        player_HP -= witch_ATK;
        SoundManager.Instance.Play_SE(0,0);
    }
    // アンデットによるダメージ計算
    public void HumanPlayerDamege()
    {
        player_HP -= human_ATK;
        SoundManager.Instance.Play_SE(0, 0);
    }
    // ゴーレムによるダメージ計算1
    public void GolemPlayerDamageVer1()
    {
        player_HP -= golem_ATK_No1;
       SoundManager.Instance.Play_SE(0, 0);
    }
    // ゴーレムによるダメージ計算1
    public void GolemPlayerDamageVer2()
    {
        player_HP -= golem_ATK_No2;
        SoundManager.Instance.Play_SE(0, 0);
    }
    // ゴーレムによるダメージ計算1
    public void GolemPlayerDamageVer3()
    {
        player_HP -= golem_ATK_No3;
        SoundManager.Instance.Play_SE(0, 0);
    }
    //毒水に当たったときのダメージ計算
    public void Poison_Atk()
    {
        SoundManager.Instance.Play_SE(0, 19);
        player_HP -= Poison_ATK;
    }
    public void StartRecrystal()
    {
        getReCrystal = 0;
    }
    public void StartGrcrystal()
    {
        getGrCrystal = 0;
    }
    public void StartExcrystal()
    {
        getExCrystal = 0;
    }
    public void addCrystal(int Re, int Gr, int Ex)
    {
       SoundManager.Instance.Play_SE(0, 5);
        getReCrystal = Re;
        getGrCrystal = Gr;
        getExCrystal = Ex;
        getCrystal = true;
        for (int i = 0; i < Re; i++)
        {
            AddReflectCrystalCount();
            
            
        }
        for (int i = 0; i < Gr; i++)
        {
            AddGravityCrystalCount();
            
        }
        for (int i = 0; i < Ex; i++)
        {
          
            AddExplosioncrystalCount();
        }
    }
    public void AddReflectCrystalCount()
    {
        reflectcrystalCount += 1;
    }
    public void AddGravityCrystalCount()
    {
        gravitycrystalCount += 1;
    }
    public void AddExplosioncrystalCount()
    {
        explosioncrystalCount += 1;
    }
    public void PullReflectCrystalCount()
    {
        reflectcrystalCount -= 1;
    }
    public void PullGravityCrystalCount()
    {
        gravitycrystalCount -= 1;
    }
    public void PullExplosioncrystalCount()
    {
        explosioncrystalCount -= 1;
    }
    // ゲージを回復する処理
    public void BlockHealmeta(float healmeta)
    {
        blockmeta += healmeta;
    }
    // ゲージを減らす処理
    public void PullBlockmeta()
    {
        blockmeta -= pullmeta;
    }
    public void TimeStart()
    {
        time += Time.deltaTime;
    }
    public void AddGameOverCount()
    {
        gameOverCount += 1;
    }
    //シーンの管理
    public void scenes_contol(int num)
    {
        scenes = num;
    }
    public int setscenes()
    {
        return scenes;
    }
    //playerの体が動かなくなる
    public　void Player_Freeze()
    {
        SoundManager.Instance.Play_SE(0, 13);
        PlayerFreeze = true;
        StartCoroutine("Freeze");
    }
    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(0.1f);
        SoundManager.Instance.Play_SE(0, 14);
        PlayerFreeze =false;
    }
}