using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    AudioManager audioManager;
    [SerializeField] GameObject lostMenu, wonMenu;
    [SerializeField] SceneIndex nextScene;
    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null && _instance != this) _instance = null;
        _instance = this;
        Time.timeScale = 1;
    }
    void Start()
    {
        audioManager = AudioManager.Instance;
        lostMenu.SetActive(false);
        wonMenu.SetActive(false);
    }

    #region Button Functions
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene((int)SceneIndex.MainMenu);
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene((int)nextScene);
    }
    #endregion

    public void Lost()
    {
        lostMenu.SetActive(true);
        audioManager.PlayLoseAudio();
    }

    public void Won()
    {
        wonMenu.SetActive(true);
        audioManager.PlayWinAudio();
    }

}
