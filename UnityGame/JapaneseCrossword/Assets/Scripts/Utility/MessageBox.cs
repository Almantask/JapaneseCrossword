using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class MessageBox:MonoBehaviour
    {
        [SerializeField]
        private CoreMessageBox Core;

        public string Title
        {
            set { Core.TitleText.text = value; }
            get { return Core.TitleText.text; }
        }

        public string Content
        {
            set { Core.MessageText.text = value; }
            get { return Core.MessageText.text; }
        }

        public Sprite Sprite
        {
            set { Core.Image.sprite = value; }
        }

        public void BindComponents()
        {
            Core.BindComponents();
        }

    }
}
