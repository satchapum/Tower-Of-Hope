using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [Header("SoundEffect_Attact + Walk")]
    [SerializeField] public AudioClip walk_Sound;
    [SerializeField] public AudioClip sword_Sound;
    [SerializeField] public AudioClip magicWand_Sound;
    [SerializeField] public AudioClip dagger_Sound;
    [SerializeField] public AudioClip arrow_Sound;
    [SerializeField] public AudioClip wrench_Sound;

    [Header("SoundEffect_Skill")]
    [SerializeField] public AudioClip swordSword_Sound;
    [SerializeField] public AudioClip sworArrow_Sound;
    [SerializeField] public AudioClip swordMagicWand_Sound;
    [SerializeField] public AudioClip swordSpear_Sound;
    [SerializeField] public AudioClip sworddagger_Sound;
    [SerializeField] public AudioClip arrowArrow_Sound;
    [SerializeField] public AudioClip arrowMagicWand_Sound;
    [SerializeField] public AudioClip arrowSpear_Sound;
    [SerializeField] public AudioClip arrowDagger_Sound;
    [SerializeField] public AudioClip magicWandMagicwand_Sound;
    [SerializeField] public AudioClip magicWandSpear_Sound;
    [SerializeField] public AudioClip magicWandDagger_Sound;
    [SerializeField] public AudioClip spearSpear_Sound;
    [SerializeField] public AudioClip spearDagger_Sound;
    [SerializeField] public AudioClip daggerDagger_Sound;


    [Header("Setting")]
    [SerializeField] AudioMixer mixer;

    public const string MASTER_KEY = "masterVolume";
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";
    private void Awake()
    {
        LoadVolume();
    }
    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat (SFX_KEY, 1f);
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);

        mixer.SetFloat(VolumeSetting.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSetting.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
        mixer.SetFloat(VolumeSetting.MIXER_MASTER, Mathf.Log10(masterVolume) * 20);
    }
}