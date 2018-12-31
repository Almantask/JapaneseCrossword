using Assets.Scripts.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.EventHandlers
{
    public class NavigationEventHandler : MonoBehaviour
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
}
