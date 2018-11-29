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
            IsFilled = isFilled;
        }

        public void InvertColor()
        {
            IsFilled = !IsFilled;
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
    }
}