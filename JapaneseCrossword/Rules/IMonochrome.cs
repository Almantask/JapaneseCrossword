namespace JapaneseCrossword.Rules
{
    public interface IMonochrome
    {
        bool IsFilled { get; }
        void InvertColor();
    }
}