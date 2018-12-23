namespace JapaneseCrossword.Core.Hints
{
    public class NumberCell
    {
        public int Number { get; }

        public NumberCell(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            if (Number == 0)
                return "";
            return Number.ToString();

        }
    }
}