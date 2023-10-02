using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    [Header("Music Tracks")]
    [SerializeField] private AudioClip levelClip;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip winClip;
    [Header("Sound Effects Prefabs")]
    [SerializeField] private GameObject[] flipperSFX;
    [SerializeField] private GameObject eruptionSFX;
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
    
    #region Music Functions
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
    #endregion

    public void PlayFlipperSFX()
    {
        GameObject sfx = Instantiate(flipperSFX[Random.Range(0, flipperSFX.Length)]);
        Destroy(sfx, sfx.GetComponent<AudioSource>().clip.length);
    }
    public void PlayEruptionSFX()
    {
        GameObject sfx = Instantiate(eruptionSFX);
        Destroy(sfx, sfx.GetComponent<AudioSource>().clip.length);
    }
}
