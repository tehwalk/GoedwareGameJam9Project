using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

[System.Serializable]
public class CutsceneSlide
{
    [TextArea(3,10)] public string[] cutsceneLines;
    public Sprite cutsceneImage;
}
public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speechText;
    [SerializeField] private Image cutsceneImage;
    [SerializeField] List<CutsceneSlide> cutsceneSlides;
    [SerializeField] private float typeTime;
    [SerializeField] private float slideTime;
    [SerializeField] private SceneIndex nextScene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (CutsceneSlide slide in cutsceneSlides)
        {
            if (slide.cutsceneImage != null)
            {
                cutsceneImage.sprite = slide.cutsceneImage;
                cutsceneImage.color = Color.white;
            }
            else
            {
                cutsceneImage.sprite = null;
                cutsceneImage.color = Color.clear;
            }
            for (int i = 0; i < slide.cutsceneLines.Length; i++)
            {
                foreach (char c in slide.cutsceneLines[i].ToCharArray())
                {
                    speechText.text += c;
                    yield return new WaitForSeconds(typeTime);
                }
                yield return new WaitForSeconds(slideTime);
                speechText.text += "\n";
            }
            speechText.text = String.Empty;
        }
        GoToNextScene();
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene((int)nextScene);
    }
}
