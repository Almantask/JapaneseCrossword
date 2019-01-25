using System;

namespace JapaneseCrossword.Core.Rules
{
    public class MonochromeCell : IMonochrome<ColorChangedEventArgs>
    {
        public EventHandler<ColorChangedEventArgs> ColorChanged { set; get; }

        public bool IsFilled { private set; get; }

        public MonochromeCell()
        {
            IsFilled = false;
        }

        public MonochromeCell(bool isFilled)
        {
            IsFilled = isFilled;
        }

        public void InvertColor()
        {
            IsFilled = !IsFilled;
            ColorChanged?.Invoke(this, new ColorChangedEventArgs(IsFilled));
        }

        public override bool Equals(object obj)
        {
            var mono = obj as MonochromeCell;
            if (obj != null)
            {
                return mono.IsFilled == IsFilled;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return IsFilled? 1:0;
        }

        public override string ToString()
        {
            return IsFilled ? "Black" : "White";
        }
    }
}