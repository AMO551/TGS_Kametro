using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject getdisplay;

    private Text gettext;
    private GameObject reflection;
    private GameObject weight;
    private GameObject explosion;
    private bool test = false;
    private void Awake()
    {
        //gettext = GameObject.Find("GetDisplay").gameObject.GetComponent<Text>();
        //reflection = GameObject.Find("GetDisplay/rf").gameObject;
        //weight = GameObject.Find("GetDisplay/wg").gameObject;
        //explosion = GameObject.Find("GetDisplay/ex").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //�����ɕ�΂��擾�������ǂ���������

        //if���͉��u��
        if(!test)
        {
            //���˕�Ύ擾
            Debug.Log("haitta");
            //test = true;
            Instantiate<GameObject>(getdisplay, transform);
            //reflection.gameObject.SetActive(true);
            //gettext.text = "���˂̃X�L����� �~�P";
            StartCoroutine("Texthide");
        }
        if(!test)
        {
            //�d�ʕ�Ύ擾
            test = true;
            Instantiate<GameObject>(getdisplay, transform);
            //weight.gameObject.SetActive(true);
            //gettext.text = "�d�ʂ̃X�L����� �~�P";
            StartCoroutine("Texthide");
        }
        if(!test)
        {
            //������Ύ擾
            test = true;
            Instantiate<GameObject>(getdisplay, transform);
            explosion.gameObject.SetActive(true);
            gettext.text = "�����̃X�L����� �~�P";
            StartCoroutine("Texthide");
        }
        ////�����
        //if (test)
        //{
        //    //���˕�Ύ擾
        //    //Debug.Log("haitta");
        //    test = true;
        //    Instantiate<GameObject>(getdisplay, transform);
        //    reflection.gameObject.SetActive(true);
        //    gettext.text = "���˂̃X�L����� �~�P";
        //    StartCoroutine("Texthide");
        //}
        //if (test)
        //{
        //    //�d�ʕ�Ύ擾
        //    test = true;
        //    Instantiate<GameObject>(getdisplay, transform);
        //    weight.gameObject.SetActive(true);
        //    gettext.text = "�d�ʂ̃X�L����� �~�P";
        //    StartCoroutine("Texthide");
        //}
        //if (test)
        //{
        //    //������Ύ擾
        //    test = true;
        //    Instantiate<GameObject>(getdisplay, transform);
        //    explosion.gameObject.SetActive(true);
        //    gettext.text = "�����̃X�L����� �~�P";
        //    StartCoroutine("Texthide");
        //}
    }
    private IEnumerator Texthide()
    {
        //Debug.Log("�R���[�`��");
        //5�b�\��
        yield return new WaitForSeconds(5.0f);

        foreach(Transform item in this.transform)
        {
            item.gameObject.SetActive(false);
        }
    }
}
