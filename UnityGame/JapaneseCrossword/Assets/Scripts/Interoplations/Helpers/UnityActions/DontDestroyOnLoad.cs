using UnityEngine;
namespace Assets.Scripts.Helpers.UnityActions
{
    /// <summary>
    /// Makes this gameObject static
    /// </summary>
    public class DontDestroyOnLoad : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
