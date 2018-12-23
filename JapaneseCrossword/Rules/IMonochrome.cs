namespace JapaneseCrossword.Core.Rules
{
    public interface IMonochrome
    {
        bool IsFilled { get; }
        void InvertColor();
    }
}