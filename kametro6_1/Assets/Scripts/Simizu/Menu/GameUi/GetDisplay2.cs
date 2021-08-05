using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDisplay2 : MonoBehaviour
{
    #region éŒ¾
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

        //‚±‚±‚É•óÎ‚ğæ“¾‚µ‚½‚©‚Ç‚¤‚©‚ğ‘‚­
        if (GameMainContol.Instance.getCrystal)
        {
            //”½Ë
            if (GameMainContol.Instance.getReCrystal > 0)
            {
                Instantiate<GameObject>(rf_getdisplay, transform);
            }
            //d—Í
            if (GameMainContol.Instance.getGrCrystal > 0)
            {
                Instantiate<GameObject>(wg_getdisplay, transform);
            }
            //”š”­
            if (GameMainContol.Instance.getExCrystal > 0)
            {
                Instantiate<GameObject>(ex_getdisplay, transform);
            }
        }
    }
}
