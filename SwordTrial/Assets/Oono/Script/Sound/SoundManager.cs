using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : SoundBase
{
    public enum SoundType
    {
        kMaster, //BGM
        kBGM, //BGM
        kSE,//SE
        kMaxNum
    }
    //Audioミキサーを入れるとこです
    [SerializeField] public AudioMixer m_audioMixer;

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
   

}
