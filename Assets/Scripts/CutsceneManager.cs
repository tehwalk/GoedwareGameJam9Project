using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speechText;
    [TextArea(3, 10)]
    [SerializeField] private string[] speechParts;
    [SerializeField] private float typeTime;
    [SerializeField] private SceneIndex nextScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < speechParts.Length; i++)
        {
            foreach (char c in speechParts[i].ToCharArray())
            {
                speechText.text += c;
                yield return new WaitForSeconds(typeTime);
            }
            yield return new WaitForSeconds(typeTime * 2.5f);
            speechText.text += "\n";
        }
        GoToNextScene();
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene((int)nextScene);
    }
}
