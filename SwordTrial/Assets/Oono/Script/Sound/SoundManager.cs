using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public enum SoundType
    {
        kMaster, //BGM
        kBGM, //BGM
        kSE,//SE
        kMaxNum
    }

    public enum SoundSEName
    {
        SwordAttack,//剣でのアタック音
        Slash,//スラッシュ
        HitRobot,//ロボをたたく音
        Healing,//回復音
        PlayerDamage,//プレイヤーダメージ音
        CursorMove,//カーソルを動かすときに発生する音
        Decision,//決定
        Cancel,//キャンセル
        kMaxNum
    }
    [Header("サウンドデータ")]
    public AudioClip[] m_soundBGMData;
    public AudioClip[] m_soundSEData;
    private string[] m_soundNameData = new string[(int)SoundType.kMaxNum];
    public static float[] m_soundVolData = new float[(int)SoundType.kMaxNum];
    //Audioミキサーを入れるとこです
    [SerializeField] public AudioMixer m_audioMixer;
    private AudioSource m_bgmSource;
    private AudioSource m_seSource;
    // Start is called before the first frame update
    public  void Start()
    {
        m_soundNameData[(int)SoundType.kMaster] = "Master";
        m_soundNameData[(int)SoundType.kBGM] = "BGM";
        m_soundNameData[(int)SoundType.kSE] = "SE";

        //BGMのデータセット
        m_audioMixer.GetFloat(m_soundNameData[(int)SoundType.kMaster], out float mastarVolume);
        //BGMのデータセット
        m_audioMixer.GetFloat(m_soundNameData[(int)SoundType.kBGM], out float bgmVolume);
        //SEMのデータセット
        m_audioMixer.GetFloat(m_soundNameData[(int)SoundType.kSE], out float seVolume);

        SountVolumeInit();

        m_bgmSource = transform.Find("BGMPlay").GetComponent<AudioSource>();
        m_seSource = transform.Find("SEPlay").GetComponent<AudioSource>();
    }


    /// <summary>
    /// サウンドの音量の変更処理
    /// </summary>
    /// <param name="name">サウンドの名前</param>
    /// <param name="vol">音の大きさ</param>
    public void SetVolume(string name,float vol)
    {
        SetSoundVolume(name, vol);
        m_audioMixer.SetFloat(name, vol);
    }
   public void PlaySoundSE(SoundSEName senum)
    {
        //if (m_seSource.isPlaying) return;
        m_seSource.clip = m_soundSEData[(int)senum];
        m_seSource.Play();
    }
    /// <summary>
    /// サウンドの初期化
    /// </summary>
    private void SountVolumeInit()
    {
        for (int i = 0; i < m_soundVolData.Length; i++)
        {
            m_audioMixer.SetFloat(m_soundNameData[i], m_soundVolData[i]);
        }
    }

    /// <summary>
    /// サウンドの音量調整
    /// </summary>
    /// <param name="name"></param>
    /// <param name="vol"></param>
    private void SetSoundVolume(string name, float vol)
    {
        for(int i = 0; i < m_soundVolData.Length; i++) 
        {
            if (m_soundNameData[i] == name)
            {
                m_soundVolData[i] = vol;
            }
        }
    }


}
