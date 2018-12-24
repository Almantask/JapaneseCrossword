using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    public class CoreMessageBox : MonoBehaviour
    {
        public CoreMessageBox(string message)
        {
            MessageText = transform.GetChild(0).GetComponent<Text>();
            MessageText.text = message;
        }

        public Text MessageText;
        public Text TitleText;
        public Image Image;

        void Start ()
        {
            BindComponents();

        }

        private void BindComponents()
        {
            var popup = transform.GetChild(0);
            var popupWindow = popup.GetChild(0);
        }

    }
}
