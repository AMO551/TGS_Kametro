using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDisplayControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Texthide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Texthide()
    {
        //Debug.Log("�R���[�`��");
        //5�b�\��
        yield return new WaitForSeconds(5.0f);

       
        gameObject.SetActive(false);
    }
}
