using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{
    [Header("Post Processing Settings")]
    [SerializeField] Volume volume;

    [Header("Sound Settings")]
    [SerializeField] AudioMixer soundMixer;
    [SerializeField] AudioMixer musicMixer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        SetSavedValues();
    }

    void SetSavedValues()
    {
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        SetSFXVolume(PlayerPrefs.GetFloat("SoundVolume"));
        ToggleVignette(Convert.ToBoolean(PlayerPrefs.GetInt("Vignette")));
        ToggleBloom(Convert.ToBoolean(PlayerPrefs.GetInt("Bloom")));
        ToggleLensDistortion(Convert.ToBoolean(PlayerPrefs.GetInt("LensD")));
    }

    public void SetMusicVolume(System.Single volume)
    {
        musicMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume(System.Single volume)
    {
        soundMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    public void ToggleVignette(bool enabled)
    {
        if (volume.profile.TryGet(out Vignette vignette))
        {
            vignette.active = enabled;
            int vInt = enabled ? 1 : 0;
            PlayerPrefs.SetInt("Vignette", vInt);
        }
        else return;
    }

    public void ToggleBloom(bool enabled)
    {
        if (volume.profile.TryGet(out Bloom bloom))
        {
            bloom.active = enabled;
            int bInt = enabled ? 1 : 0;
            PlayerPrefs.SetInt("Bloom", bInt);
        }
        else return;
    }

    public void ToggleLensDistortion(bool enabled)
    {
        if (volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            lensDistortion.active = enabled;
            int lInt = enabled ? 1 : 0;
            PlayerPrefs.SetInt("LensD", lInt);
        }
        else return;
    }


}
