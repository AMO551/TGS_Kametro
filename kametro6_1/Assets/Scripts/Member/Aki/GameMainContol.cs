using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainContol : MonoBehaviour
{
    public static GameMainContol Instance { get => _instance; }
    static GameMainContol _instance;
    // vC[ΜHP
    public float player_HP = 100;
    // GlM[ΜATK
    public float enemy_ATK = 10;
    // zΞΜΒ
    public float crystalCount = 0;
    // ρςΜl 
    public float healingNUM = 10;

    void Awake()
    {
        _instance = this;
    }
    public void PlayerDamege()
    {
        player_HP -= enemy_ATK;
    }
    public void PlayerHeal()
    {
        player_HP += healingNUM;
    }
    public void AddCrystalCount()
    {
        crystalCount++;
    }
    public void PullCrystalCount()
    {
        crystalCount--;
        Debug.Log(crystalCount);
    }
}