using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Interoplations.Helpers.AsynOperations
{
    /// <summary>
    /// Loads and processes resource from Resources folder
    /// </summary>
    public class ResourceLoadHelper:Singleton<ResourceLoadHelper>
    {
        /// <summary>
        /// Preloaded resources, to be redeemed by requestors
        /// </summary>
        public static Dictionary<ulong, Object> preloadedResources = new Dictionary<ulong, Object>();
        /// <summary>
        /// Async reousrce load callers, one per item
        /// </summary>
        public static Dictionary<ulong, IResourceRequestor> requestorsQueue = new Dictionary<ulong, IResourceRequestor>();
        /// <summary>
        /// Resource call count
        /// </summary>
        private static ulong callCount = 0;

        /// <summary>
        /// Preloads the resource
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static IEnumerator LoadResourceAsyncE(string path, ulong id)
        {
            ResourceRequest load;
            load = Resources.LoadAsync(path);
                yield return load;
            if (load.asset == null)
            {
                requestorsQueue.Remove(id);
            }
            else
            {
                Object loadedResource = load.asset;
                preloadedResources.Add(id, loadedResource);
                GiveResourceToCaller(id);
            }
        }

        /// <summary>
        /// Async reousrce preload call
        /// </summary>
        /// <param name="path"></param>
        /// <param name="caller"></param>
        public static void LoadResourceAsync(string path, IResourceRequestor caller)
        {
            requestorsQueue.Add(callCount, caller);
            Instance.StartCoroutine(LoadResourceAsyncE(path, callCount));
            callCount++;
        }

        /// <summary>
        /// Gives resource to the caller, frees up resources
        /// </summary>
        /// <param name="id"></param>
        private static void GiveResourceToCaller(ulong id)
        {
            Object resource = preloadedResources[id];
            IResourceRequestor requestor = requestorsQueue[id];
            requestor.ProcessLoadedResources(resource);
            Instance.StartCoroutine(FreeUpResourceE(requestor, id));
        }

        /// <summary>
        /// Frees use resources from callers and preloads, resets caller state
        /// </summary>
        /// <param name="requestor"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static IEnumerator FreeUpResourceE(IResourceRequestor requestor, ulong id)
        {
            while (requestor.IsResourcesObtained())
                yield return null;
            requestor.ResetState();
            preloadedResources.Remove(id);
            requestorsQueue.Remove(id);
        }


    }
}
