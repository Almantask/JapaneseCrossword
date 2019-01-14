namespace Assets.Scripts.Interoplations.Helpers.AsynOperations
{
    public interface IResourceRequestor
    {
        void ProcessLoadedResources(UnityEngine.Object obj);
        bool IsResourcesObtained();
        void ResetState();
    }
}
