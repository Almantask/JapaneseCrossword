using UnityEngine;
using UnityEngine.UI;

namespace Assets.Simple_UI.Samples
{
    public class IconPreview : MonoBehaviour {
        public Sprite[] icons;
        GameObject icon;


        // Use this for initialization
        void Awake () {
            for (int i = 0; i < icons.Length; i++) {
                icon = new GameObject ("icon" + i);
                icon.transform.SetParent(this.gameObject.transform);
                icon.AddComponent<RectTransform> ();
                icon.AddComponent<Image> ();
                icon.GetComponent<Image> ().sprite = icons [i];
            }
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
