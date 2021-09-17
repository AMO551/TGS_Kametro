using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    #region éŒ¾
    public int setlife = 10; 
    [SerializeField]
    private GameObject lifeObj;
    [SerializeField]
    private GameObject lifeObjHarf;
    #endregion
    //Start
    void Start()
    {
        SetlifeGauge(setlife);
    }
    // Update
    void Update()
    {
        SetlifeGauge((int)GameMainContol.Instance.player_HP);
    }
    //life
    public void SetlifeGauge(int life)
    {
        Debug.Log(life);
        if(life > 10)
        {
            life = 10;
        }
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < life/2; i++)
        {
            Instantiate<GameObject>(lifeObj, transform);
        }
        if(life%2 == 1)
        {
            Instantiate<GameObject>(lifeObjHarf, transform);
        }
    }
}
