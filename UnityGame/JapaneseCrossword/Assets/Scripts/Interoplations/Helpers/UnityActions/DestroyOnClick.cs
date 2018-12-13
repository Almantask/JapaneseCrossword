using Assets.Scripts.Helpers.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers.UnityActions
{
    public class DestroyOnClick : MonoBehaviour
    {
        float time = 0f;
        public GameObject target;
        private void OnMouseDown()
        {
            StartCoroutine(GeneralHelper.DestroyAfterTime(target, time));
        }
    }
}
