using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    public class CoreMessageBox : MonoBehaviour
    {

        public Text MessageText;
        public Text TitleText;
        public Image Image;

        void Start ()
        {
            BindComponents();
        }

        public void BindComponents()
        {
            var popup = transform.GetChild(0);
            var popupWindow = popup.GetChild(0);
            
            const string imageHolderName = "MessageTypeImage";
            Image = popupWindow.Find(imageHolderName).GetComponent<Image>();

            const string titleHolderName = "Text_WindowTitle";
            TitleText = popupWindow.Find(titleHolderName).GetComponent<Text>();

            const string textContainerHolderName = "Panel_Content";
            var textContainerHodler = popupWindow.Find(textContainerHolderName);
            const string textDescriptionHolderName = "Text_Description";
            MessageText = textContainerHodler.Find(textDescriptionHolderName).GetComponent<Text>();

        }

    }
}
