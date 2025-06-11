using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
