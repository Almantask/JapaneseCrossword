using Assets.Scripts.Utility;
using JapaneseCrossword.Core;

namespace Assets.Scripts.CoreGame
{
    public class UnityAnnnouncer : IAnnouncer
    {
        public void Show(string text)
        {
            MessageBoxUtil.Show(text, MessageType.Info);
        }
    }
}