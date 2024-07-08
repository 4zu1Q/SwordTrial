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
    [SerializeField] private AudioMixer m_audioMixer;

    //それぞれのスライダーを入れるとこです。。
    [SerializeField] private Slider[] m_slider;

    private bool m_isSelect = false;    //連続移動を防ぐフラグ

    public SoundUICursor m_soundCursor;//サウンドのカーソルの取得
    //private 
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
        // ボリュームのセット
        m_slider[(int)SoundType.kMaster].value = mastarVolume;
        m_slider[(int)SoundType.kBGM].value = bgmVolume;
        m_slider[(int)SoundType.kSE].value = seVolume;

    }

    // Update is called once per frame
    void Update()
    {
        SoundVolumeUpdate();

    }

    /// <summary>
    /// サウンドのVolumeの更新処理
    /// </summary>
    private void SoundVolumeUpdate()
    {
        // サウンドの音量を変える処理
        int selectNum = -1;
        Debug.Log(m_slider[(int)SoundType.kSE].value);
        if (m_soundCursor.m_selectItem[(int)SoundType.kMaster])
        {
            selectNum = (int)SoundType.kMaster;
        }
        else if (m_soundCursor.m_selectItem[(int)SoundType.kBGM])
        {
            selectNum = (int)SoundType.kBGM;
        }
        else if (m_soundCursor.m_selectItem[(int)SoundType.kSE])
        {
            selectNum = (int)SoundType.kSE;
        }
        else
        {
            selectNum = -1;
        }
        if (selectNum == -1) { return; }

        //スティックの入力値を格納
        float RightStick = Input.GetAxis("Horizontal");

        //カーソルを下に動かす
        if (RightStick >= 0.5f)
        {
            m_slider[selectNum].value++;

        }
        else if (RightStick <= -0.5f)
        {
            m_slider[selectNum].value--;

        }
        if (selectNum == (int)SoundType.kMaster)
        {
            m_audioMixer.SetFloat("Master", m_slider[selectNum].value);
        }
        else if (selectNum == (int)SoundType.kBGM)
        {
            m_audioMixer.SetFloat("BGM", m_slider[selectNum].value);
        }
        else if (selectNum == (int)SoundType.kSE)
        {
            m_audioMixer.SetFloat("SE", m_slider[selectNum].value);
        }
    }

}
