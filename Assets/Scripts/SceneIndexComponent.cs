using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum SceneIndex
{
    MainMenu = 0,
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
    Level4 = 4,
    Level5 = 5
}

public class SceneIndexComponent : MonoBehaviour
{
    public SceneIndex sceneIndex;

    public void GoToLevel()
    {
        SceneManager.LoadScene((int)sceneIndex);
    }
}