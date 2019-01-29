using System;
using System.Collections;
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

            _titles = new Dictionary<MessageType, string>()
            {
                {MessageType.Error, MessageType.Error.ToString()},
                {MessageType.Warning, MessageType.Warning.ToString()},
                {MessageType.Info, MessageType.Info.ToString()}
            };
        }

        public static void Show(string message, MessageType messageType)
        {
            Instance.StartCoroutine(ShowE(message, messageType));
        }

        private static IEnumerator ShowE(string message, MessageType messageType)
        {
            var messageBox = Instantiate(Instance.mainPrefab.transform.gameObject);

            if (messageType == MessageType.Info)
            {
                messageBox.GetComponent<MessageBox>().ConvertToOk();
            }

            var messageLogic = messageBox.GetComponent<MessageBox>();

            messageLogic.Content = message;
            messageLogic.Title = Instance._titles[messageType];

            yield return Instance.StartCoroutine(Instance.LoadMessageImage(messageType));
            messageLogic.Sprite = Instance._sprites[messageType];
        }

        private IEnumerator LoadMessageImage(MessageType type)
        {
            if (Instance._sprites != null && Instance._sprites.ContainsKey(type)) yield break;

            var resName = GetMessageImageName(type);
            var request = Resources.LoadAsync<Sprite>(resName);
            while (!request.isDone)
                yield return null;
            var sprite = request.asset as Sprite;

            if (Instance._sprites == null)
            {
                Instance._sprites = new Dictionary<MessageType, Sprite>();
            }
            Instance._sprites.Add(type, sprite);
        }

        private string GetMessageImageName(MessageType type)
        {
            const string prefix = "Message";
            return $"{prefix}{type.ToString()}";
        }
    }
}
