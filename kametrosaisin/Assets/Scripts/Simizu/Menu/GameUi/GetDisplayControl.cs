using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDisplayControl : MonoBehaviour
{
    #region �錾
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
        //�d��
        if (GrCrystal)
        {
            score_text.text = "�d�ʂ̃X�L����� �~" + gameMainContol.getGrCrystal;
            gameMainContol.StartGrcrystal();
        
        }
        //����
        if (ReCrystal)
        {
            score_text.text = "���˂̃X�L����� �~" + gameMainContol.getReCrystal;
            gameMainContol.StartRecrystal();
        }
        //����
        if (ExCrystal)
        {
            score_text.text = "�����̃X�L����� �~" + gameMainContol.getExCrystal;
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
