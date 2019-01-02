namespace Assets.Scripts.CoreGame
{
    internal interface ITile
    {
        Tile Initialise();
        void SetProperties(object param, bool isLoad = false);
    }
}