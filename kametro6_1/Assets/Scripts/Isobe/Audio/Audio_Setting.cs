using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play_bgm(0, 4);
    }
}
