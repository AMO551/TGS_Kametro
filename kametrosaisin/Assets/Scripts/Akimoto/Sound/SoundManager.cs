using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get => _instance; }
    static SoundManager _instance;
    [SerializeField]
    List<AudioClip> seList = new List<AudioClip>();
    [SerializeField]
    List<AudioClip> bgmList = new List<AudioClip>();
    // AddComponent ���� AudioSource �̃��X�g
    [SerializeField]
    List<AudioSource> soundSource = new List<AudioSource>();
    private void Awake()
    {
        _instance = this;
    }
    // SE�֘A
    public void Play_SE(int source_num, int se_num)
    {
        soundSource[source_num].PlayOneShot(seList[se_num]);
    }
    // bgm�֘A
    public void Play_bgm(int source_num, int bgm_num)
    {
        soundSource[source_num].PlayOneShot(bgmList[bgm_num]);
    }
}
