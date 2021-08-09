using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play_bgm(3, 1);
        GameMainContol.Instance.scenes_contol(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
