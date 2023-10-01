using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    [SerializeField] private AudioClip levelClip;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip winClip;
    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null && _instance != this) _instance = null;
        _instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayLevelAudio();
    }

    public void PlayLevelAudio()
    {
        audioSource.loop = true;
        audioSource.clip = levelClip;
        audioSource.Play();
    }

    public void PlayWinAudio()
    {
        audioSource.loop = false;
        audioSource.clip = winClip;
        audioSource.Play();
    }

    public void PlayLoseAudio()
    {
        audioSource.loop = false;
        audioSource.clip = loseClip;
        audioSource.Play();
    }


}
