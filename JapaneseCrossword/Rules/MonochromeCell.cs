namespace JapaneseCrossword.Rules
{
    public class MonochromeCell : IMonochrome
    {
        public bool IsFilled { private set; get; }

        public MonochromeCell()
        {
            IsFilled = false;
        }

        public MonochromeCell(bool isFilled)
        {
            IsFilled = false;
        }

        public void InvertColor()
        {
            IsFilled = !IsFilled;
        }
    }
}