using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource SFX_AudioSource;
    [SerializeField] AudioSource SFX_Walk;

    [Header("SoundEffect_Attack")]
    [SerializeField] AudioClip sword_Sound;
    [SerializeField] AudioClip spear_Sound;
    [SerializeField] AudioClip magicWand_Sound;
    [SerializeField] AudioClip dagger_Sound;
    [SerializeField] AudioClip arrow_Sound;
    [SerializeField] AudioClip wrench_Sound;

    [Header("SoundEffect_Unique")]
    [SerializeField] AudioClip sword_Skill_Sound;
    [SerializeField] AudioClip spear_Skill_Sound;
    [SerializeField] AudioClip magicWand_Skill_Sound;
    [SerializeField] AudioClip dagger_Skill_Sound;
    [SerializeField] AudioClip arrow_Skill_Sound;

    [Header("SoundEffect_Skill")]
    [SerializeField] AudioClip swordSword_Sound;
    [SerializeField] AudioClip swordArrow_Sound;
    [SerializeField] AudioSource swordMagicWand_Sound;
    [SerializeField] AudioClip swordSpear_Sound;
    [SerializeField] AudioClip sworddagger_Sound;
    [SerializeField] AudioClip arrowArrow_Sound;
    [SerializeField] AudioClip arrowMagicWand_Sound;
    [SerializeField] AudioClip arrowSpear_Sound;
    [SerializeField] AudioClip arrowDagger_Sound;
    [SerializeField] AudioClip magicWandMagicwand_Sound;
    [SerializeField] AudioClip magicWandSpear_Sound;
    [SerializeField] AudioClip magicWandDagger_Sound;
    [SerializeField] AudioClip spearSpear_Sound;
    [SerializeField] AudioClip spearDagger_Sound;
    [SerializeField] AudioClip daggerDagger_Sound;


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
    public void walk_Sound_SFX()
    {
        SFX_Walk.enabled = true;
    }
    public void stop_walk_Sound_SFX()
    {
            SFX_Walk.enabled = false;
    }
    public void sword_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(sword_Sound);
    }
    public void spear_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(spear_Sound);
    }
    public void magicWand_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(magicWand_Sound);
    }
    public void dagger_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(dagger_Sound);
    }
    public void arrow_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(arrow_Sound);
    }
    public void wrench_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(wrench_Sound);
    }
    public void sword_Skill_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(sword_Skill_Sound);
    }
    public void spear_Skill_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(spear_Skill_Sound);
    }
    public void magicWand_Skill_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(magicWand_Skill_Sound);
    }
    public void dagger_Skill_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(dagger_Skill_Sound);
    }
    public void arrow_Skill_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(arrow_Skill_Sound);
    }
    public void swordSword_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(swordSword_Sound);
    }
    public void swordArrow_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(swordArrow_Sound);
    }
    public void swordMagicWand_Sound_SFX()
    {
        swordMagicWand_Sound.enabled = true;
    }
    public void stop_swordMagicWand_Sound_SFX()
    {
        swordMagicWand_Sound.enabled = false;
    }
    public void swordSpear_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(swordSpear_Sound);
    }
    public void sworddagger_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(sworddagger_Sound);
    }
    public void arrowArrow_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(arrowArrow_Sound);
    }
    public void arrowMagicWand_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(arrowMagicWand_Sound);
    }
    public void arrowSpear_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(arrowSpear_Sound);
    }
    public void arrowDagger_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(arrowDagger_Sound);
    }
    public void magicWandMagicwand_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(magicWandMagicwand_Sound);
    }
    public void magicWandSpear_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(magicWandSpear_Sound);
    }
    public void magicWandDagger_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(magicWandDagger_Sound);
    }
    public void spearSpear_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(spearSpear_Sound);
    }
    public void spearDagger_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(spearDagger_Sound);
    }
    public void daggerDagger_Sound_SFX()
    {
        SFX_AudioSource.PlayOneShot(daggerDagger_Sound);
    }
}