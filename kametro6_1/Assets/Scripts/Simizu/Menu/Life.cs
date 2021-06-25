using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetlifeGauge(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    private GameObject lifeObj;
    [SerializeField]
    private GameObject lifeObjHarf;

    public void SetlifeGauge(int life)
    {
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
