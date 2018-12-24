using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class MessageBoxUtil: Singleton<MessageBoxUtil>
    {
        private MessageBox mainPrefab;
        private Dictionary<MessageType, Sprite> _sprites;
        private Dictionary<MessageType, string> _titles;

        void Awake()
        {
            mainPrefab = Resources.Load<GameObject>("MessageBox").GetComponent<MessageBox>();
        }

        public static void Show(string message, MessageType messageType)
        {
            var messageBox = Instantiate(Instance.mainPrefab.transform.gameObject);
            var messageLogic = messageBox.GetComponent<MessageBox>();

            messageLogic.Content = message;
            messageLogic.Title = Instance._titles[messageType];
            messageLogic.Sprite = Instance._sprites[messageType];
        }
    }
}
