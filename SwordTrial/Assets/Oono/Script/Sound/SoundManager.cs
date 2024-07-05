using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : SoundBase
{
    //Audioミキサーを入れるとこです
    [SerializeField] private AudioMixer audioMixer;

    //それぞれのスライダーを入れるとこです。。
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SESlider;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log(audioMixer);
        //BGM
        audioMixer.GetFloat("BGM", out float bgmVolume);
        //audioMixer.GetFloat("BGM", out float bgmVolume);
        BGMSlider.value = bgmVolume;
        //SE
        audioMixer.GetFloat("SE", out float seVolume);
        SESlider.value = seVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
}
