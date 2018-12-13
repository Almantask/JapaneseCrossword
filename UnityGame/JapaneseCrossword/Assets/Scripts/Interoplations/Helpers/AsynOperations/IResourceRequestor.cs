using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assets.Scripts.Helpers.AsyncOperations
{
    public interface IResourceRequestor
    {
        void ProcessLoadedResources(UnityEngine.Object obj);
        bool IsResourcesObtained();
        void ResetState();
    }
}
