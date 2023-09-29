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
    }

    public void SetMusicVolume(System.Single volume)
    {
        musicMixer.SetFloat("Volume", volume);
    }
    public void SetSFXVolume(System.Single volume)
    {
        soundMixer.SetFloat("Volume", volume);
    }

    public void ToggleVignette(bool enabled)
    {
        if (volume.profile.TryGet(out Vignette vignette))
            vignette.active = enabled;
        else return;
    }

    public void ToggleBloom(bool enabled)
    {
        if (volume.profile.TryGet(out Bloom bloom))
            bloom.active = enabled;
        else return;
    }

    public void ToggleLensDistortion(bool enabled)
    {
        if (volume.profile.TryGet(out LensDistortion lensDistortion))
            lensDistortion.active = enabled;
        else return;
    }


}
