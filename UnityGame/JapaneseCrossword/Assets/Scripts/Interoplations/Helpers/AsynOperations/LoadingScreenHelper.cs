using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers.AsyncOperations
{
    public class LoadingScreenController : MonoBehaviour, IStateChanged
    {

        public string sceneNameToPreload = "Desktop";
        bool isLoaded = false;
        public float loadingScreenMinAnimation = 2f;
        bool cancelPreload = false;
        [SerializeField]
        public Animatable anim;

        IEnumerator LoadingAnimation()
        {

            while (!isLoaded)
            {

                yield return null;
            }
        }

        private void Update()
        {
            if (Input.anyKey)
                cancelPreload = true;
        }

        IEnumerator LoadSceneAsync(float minTime, string sceneName)
        {
            AsyncOperation sceneLoadingCall = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            float time = minTime;
            while (!sceneLoadingCall.isDone || time > 0 && !cancelPreload)
            {
                yield return new WaitForSeconds(0.2f);
                time -= 0.2f;
            }
            SceneManager.UnloadSceneAsync(0);
            isLoaded = true;

        }

        private void Start()
        {
            if (anim!= null)
                anim.RunAnimation();
            StartCoroutine(LoadSceneAsync(loadingScreenMinAnimation, sceneNameToPreload));
        }

        public bool IsStageChanged()
        {
            return isLoaded;
        }
    }
}
