using JapaneseCrossword.Rules;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Hints
{
    public class NumberCell:Cell
    {
        public int Number { get; }

        public NumberCell(int row, int col, int number) : base(row, col)
        {
            Number = number;
        }
    }
}