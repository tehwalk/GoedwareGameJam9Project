using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum SceneIndex
{
    MainMenu = 0,
    Cutscene1 = 1,
    Level1 = 2,
    Cutscene2= 3,
    Level2 = 4,
    Cutscene3 = 5,
    Level3 = 6,
    Cutscene4 = 7,
    Level4 = 8,
    Cutscene5 = 9,
    Level5 = 10
}

public class SceneIndexComponent : MonoBehaviour
{
    public SceneIndex sceneIndex;

    public void GoToLevel()
    {
        SceneManager.LoadScene((int)sceneIndex);
    }
}