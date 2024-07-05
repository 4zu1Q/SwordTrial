using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MonoBehaviour
{
    [Header("サウンドデータ")]
    public AudioClip[] m_soundBGMData;
    public AudioClip[] m_soundSEData;
    private AudioSource m_bgmSource;
    private AudioSource m_seSource;
    public static float m_bgmVol = 0.5f;
    public static float m_seVol = 0.5f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_bgmSource = transform.Find("BGMPlay").GetComponent<AudioSource>();
        m_seSource = transform.Find("SEPlay").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
