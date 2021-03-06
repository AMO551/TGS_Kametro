using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDisplay2 : MonoBehaviour
{
    #region 宣言
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

        //ここに宝石を取得したかどうかを書く
        if (GameMainContol.Instance.getCrystal)
        {
            //反射
            if (GameMainContol.Instance.getReCrystal > 0)
            {
                Instantiate<GameObject>(rf_getdisplay, transform);
            }
            //重力
            if (GameMainContol.Instance.getGrCrystal > 0)
            {
                Instantiate<GameObject>(wg_getdisplay, transform);
            }
            //爆発
            if (GameMainContol.Instance.getExCrystal > 0)
            {
                Instantiate<GameObject>(ex_getdisplay, transform);
            }
        }
    }
}
