using System;

namespace JapaneseCrossword.Core.Rules
{
    public interface IMonochrome<T> where T: ColorChangedEventArgs
    {
        EventHandler<T> ColorChanged { set; get; }
        bool IsFilled { get; }
        void InvertColor();
    }

    public class ColorChangedEventArgs:EventArgs
    {
        public bool IsFilled { get; }

        public ColorChangedEventArgs(bool isFilled)
        {
            IsFilled = isFilled;
        }
    }
}