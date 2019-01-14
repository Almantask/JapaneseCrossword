using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interoplations.Helpers.UI
{
    public class ObjectAlignerWithText : MonoBehaviour
    {

        public int optimalPositionCharIndex = 4;
        public float spacePerChar = 0.2f;

        public void AlignWithText(TextMesh text)
        {
            int spaces = text.text.Length;
            transform.position -= spacePerChar * new Vector3(1, 0, 0);
        }

        public void AlignWithText(Text text)
        {
            int spaces = text.text.Length;
            transform.position -= spacePerChar * new Vector3(1, 0, 0);
        }
    }
}
