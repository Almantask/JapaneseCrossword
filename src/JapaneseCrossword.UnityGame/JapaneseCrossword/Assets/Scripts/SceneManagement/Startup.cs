using UnityEngine;

namespace Assets.Scripts.SceneManagement
{
    public class Startup : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}