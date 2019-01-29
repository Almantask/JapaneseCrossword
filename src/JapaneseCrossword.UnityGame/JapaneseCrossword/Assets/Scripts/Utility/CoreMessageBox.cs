using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    public class CoreMessageBox : MonoBehaviour
    {
        public Text MessageText;
        public Text TitleText;
        public Image Image;
        public Button ButtonConfirm;
        public Button ButtonCancel;

        public void ConvertToOkMessage()
        {
            Destroy(ButtonCancel.gameObject);

            const float middle = 95;
            var rectTransform = ButtonConfirm.GetComponent<RectTransform>();
            var oldAnchorY = rectTransform.anchoredPosition.y;
            rectTransform.anchoredPosition = new Vector3(middle, oldAnchorY);
        }
    }
}
