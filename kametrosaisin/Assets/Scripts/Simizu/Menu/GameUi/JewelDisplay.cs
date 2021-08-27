using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelDisplay : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private GameMainContol gameMainContol;
    private GameObject reflection;
    private GameObject weight;
    private GameObject explosion;
    private Text rfText;
    private Text wgText;
    private Text exText;
    private float judge = 0;
    private RectTransform rfrectTransform;
    private RectTransform wgrectTransform;
    private RectTransform exrectTransform;

    #endregion
    //Awake
    private void Awake()
    {
        reflection = transform.Find("reflection").gameObject;
        weight = transform.Find("weight").gameObject;
        explosion = transform.Find("explosion").gameObject;
        rfText = transform.Find("reflection/rfText").gameObject.GetComponent<Text>();
        wgText = transform.Find("weight/wgText").gameObject.GetComponent<Text>();
        exText = transform.Find("explosion/exText").gameObject.GetComponent<Text>();

        rfrectTransform = transform.Find("reflection").GetComponent<RectTransform>();
        wgrectTransform = transform.Find("weight").GetComponent<RectTransform>();
        exrectTransform = transform.Find("explosion").GetComponent<RectTransform>();
    }
    //Update
    void Update()
    {
        //rf
        if (judge == 0)
        {
            //���̎擾
            rfText.text = string.Format("{0}", gameMainContol.reflectcrystalCount);
            exText.text = string.Format("{0}", gameMainContol.explosioncrystalCount);
            wgText.text = string.Format("{0}", gameMainContol.gravitycrystalCount);
            //�e�傫���A�ʒu�̕ύX
            rfrectTransform.localScale = new Vector3(1, 1);
            rfrectTransform.localPosition = new Vector3(0, 0);
            wgrectTransform.localScale = new Vector3(0.5f, 0.5f);
            wgrectTransform.localPosition = new Vector3(90, -14);
            exrectTransform.localScale = new Vector3(0.5f, 0.5f);
            exrectTransform.localPosition = new Vector3(-90, -14);
        }
        //ex
        else if (judge == 1)
        {
            //���̎擾
            rfText.text = string.Format("{0}", gameMainContol.reflectcrystalCount);
            exText.text = string.Format("{0}", gameMainContol.explosioncrystalCount);
            wgText.text = string.Format("{0}", gameMainContol.gravitycrystalCount);
            //�e�傫���A�ʒu�̕ύX
            exrectTransform.localScale = new Vector3(1, 1);
            exrectTransform.localPosition = new Vector3(0, 0);
            rfrectTransform.localScale = new Vector3(0.5f, 0.5f);
            rfrectTransform.localPosition = new Vector3(90, -14);
            wgrectTransform.localScale = new Vector3(0.5f, 0.5f);
            wgrectTransform.localPosition = new Vector3(-90, -14);

        }
        //wg
        else if (judge == 2)
        {
            //���̎擾
            rfText.text = string.Format("{0}", gameMainContol.reflectcrystalCount);
            exText.text = string.Format("{0}", gameMainContol.explosioncrystalCount);
            wgText.text = string.Format("{0}", gameMainContol.gravitycrystalCount);
            //�e�傫���A�ʒu�̕ύX
            wgrectTransform.localScale = new Vector3(1, 1);
            wgrectTransform.localPosition = new Vector3(0, 0);
            exrectTransform.localScale = new Vector3(0.5f, 0.5f);
            exrectTransform.localPosition = new Vector3(90, -14);
            rfrectTransform.localScale = new Vector3(0.5f, 0.5f);
            rfrectTransform.localPosition = new Vector3(-90, -14);
        }
        //--��ΐ؂�ւ�--
        //L
        if (Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //rf��
            if(judge == 0)
            {
                judge = 1;
            }
            //ex��
            else if (judge == 1)
            {
                judge = 2;
            }
            //wg��
            else if(judge == 2)
            {
                judge = 0;
            }
        }
        //R
        if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //rf��
            if(judge == 0)
            {
                judge = 2;
            }
            //wg��
            else if (judge == 2)
            {
                judge = 1;
            }
            //ex��
            else if (judge == 1)
            {
                judge = 0;
            }
        }
    }
}
