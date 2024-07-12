using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : SoundBase
{
    public enum SoundType
    {
        kBGM, //BGM
        kSE,//SE
        kMaxNum
    }
    //Audioミキサーを入れるとこです
    [SerializeField] private AudioMixer m_audioMixer;
    [SerializeField] private AudioSource m_soundBGM;
    [SerializeField] private AudioSource m_soundSE;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log(m_audioMixer);
        //BGMのデータセット
        m_audioMixer.GetFloat("Master", out float mastarVolume);
        //BGMのデータセット
        m_audioMixer.GetFloat("BGM", out float bgmVolume);
        //SEMのデータセット
        m_audioMixer.GetFloat("SE", out float seVolume);

        m_soundBGM = gameObject.transform.GetChild((int)SoundType.kBGM).GetComponent<AudioSource>();
        m_soundSE = gameObject.transform.GetChild((int)SoundType.kSE).GetComponent<AudioSource>();

    }

    /// <summary>
    /// サウンドの音量の変更処理
    /// </summary>
    /// <param name="name">サウンドの名前</param>
    /// <param name="vol">音の大きさ</param>
    public void SetVolume(string name,float vol)
    {
        m_audioMixer.SetFloat(name, vol);
    }
   
    public void SoundSEPlay()
    {
        m_soundSE.clip = m_soundSEData[0];
        m_soundSE.Play();
    }

}
