using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDisplay2 : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private GameObject rf_getdisplay;
    [SerializeField]
    private GameObject wg_getdisplay;
    [SerializeField]
    private GameObject ex_getdisplay;
    #endregion
    // Update
    void Update()
    {

        //�����ɕ�΂��擾�������ǂ���������
        if (GameMainContol.Instance.getCrystal)
        {
            //����
            if (GameMainContol.Instance.getReCrystal > 0)
            {
                Instantiate<GameObject>(rf_getdisplay, transform);
            }
            //�d��
            if (GameMainContol.Instance.getGrCrystal > 0)
            {
                Instantiate<GameObject>(wg_getdisplay, transform);
            }
            //����
            if (GameMainContol.Instance.getExCrystal > 0)
            {
                Instantiate<GameObject>(ex_getdisplay, transform);
            }
        }
    }
}
