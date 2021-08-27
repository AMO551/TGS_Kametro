using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDisplayControl : MonoBehaviour
{
    #region 宣言
    [SerializeField]
    GameMainContol gameMainContol;
    public bool GrCrystal = false;
    public bool ReCrystal = false;
    public bool ExCrystal = false;
    public GameObject score_object = null;
    #endregion
    //Start
    void Start()
    {
        score_object = this.gameObject;
        gameMainContol = GameObject.Find("GameMainContol").transform.GetComponent<GameMainContol>();
        Text score_text = score_object.GetComponent<Text>();
        //重力
        if (GrCrystal)
        {
            score_text.text = "重量のスキル宝石 ×" + gameMainContol.getGrCrystal;
            gameMainContol.StartGrcrystal();
        
        }
        //反射
        if (ReCrystal)
        {
            score_text.text = "反射のスキル宝石 ×" + gameMainContol.getReCrystal;
            gameMainContol.StartRecrystal();
        }
        //爆発
        if (ExCrystal)
        {
            score_text.text = "爆発のスキル宝石 ×" + gameMainContol.getExCrystal;
            gameMainContol.StartExcrystal();
        }
        StartCoroutine("Texthide");
    }   
    private IEnumerator Texthide()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
