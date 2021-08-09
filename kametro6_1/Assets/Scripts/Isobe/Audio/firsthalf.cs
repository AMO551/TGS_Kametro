using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firsthalf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play_bgm(2,1);
        GameMainContol.Instance.scenes_contol(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
