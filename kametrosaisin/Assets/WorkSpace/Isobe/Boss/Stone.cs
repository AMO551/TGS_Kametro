using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool rf=false;//���ˍz��
    public bool wg=false;//�d�͍z��
    public bool ex=false;//�����z��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rf)
        {
            GameMainContol.Instance.addCrystal(1, 0, 0);
        }
        if (wg)
        {
            GameMainContol.Instance.addCrystal(0, 1, 0);
        }
        if (ex)
        {
            GameMainContol.Instance.addCrystal(0, 0, 1);
        }
        Destroy(gameObject, 0.2f);
    }
}
