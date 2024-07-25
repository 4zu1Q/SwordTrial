using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    //Audioミキサーを入れるとこです
    [SerializeField] public AudioMixer m_audioMixer;
    private AudioSource m_bgmSource;
    private AudioSource m_seSource;
    // Start is called before the first frame update
    public  void Start()
    {

        //Debug.Log(m_audioMixer);
        //BGMのデータセット
        m_audioMixer.GetFloat("Master", out float mastarVolume);
        //BGMのデータセット
        m_audioMixer.GetFloat("BGM", out float bgmVolume);
        //SEMのデータセット
        m_audioMixer.GetFloat("SE", out float seVolume);

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
        m_audioMixer.SetFloat(name, vol);
    }
   public void PlaySoundSE(SoundSEName senum)
    {
        //if (m_seSource.isPlaying) return;
        m_seSource.clip = m_soundSEData[(int)senum];
        m_seSource.Play();
    }

}
