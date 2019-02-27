using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets
{
    [RequireComponent(typeof(RectTransform))]
    public class DragableOnMouseHold : MonoBehaviour
    {
        private RectTransform _rec;
        private Vector2 _offset = Vector2.zero;

        private void Awake()
        {
            _rec = GetComponent<RectTransform>();
        }

        public void Drag()
        {
            Vector2 current;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rec,Input.mousePosition - (Vector3)_rec.anchoredPosition, Camera.main, out current);

            // Figure out how to move by an offset
            _rec.position = _rec.TransformPoint(current + _offset);
            
        }
    }
}
