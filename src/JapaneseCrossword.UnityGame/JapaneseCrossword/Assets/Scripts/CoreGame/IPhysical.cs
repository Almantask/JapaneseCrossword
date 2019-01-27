namespace Assets.Scripts.CoreGame
{
    /// <summary>
    /// Intended to use for object, which should have a configuration on creation/ before creatrion
    /// </summary>
    public interface IPhysical
    {
        object Initialise();
        void BindToLogical(object param, bool isLoad = false);
    }
}