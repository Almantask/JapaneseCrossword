using UnityEngine;

public class MainMenuEventHandler : MonoBehaviour
{
    private Navigator _navigator;

    void Start()
    {
        _navigator = FindObjectOfType<Navigator>();
    }

    public void OpenScene(string scene)
    {
        _navigator.OpenScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
