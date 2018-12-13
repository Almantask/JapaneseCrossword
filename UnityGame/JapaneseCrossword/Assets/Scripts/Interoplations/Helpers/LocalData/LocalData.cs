using Assets.Scripts.Helpers.SingletonDesign;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
namespace Assets.Scripts.Helpers.LocalData
{
    public class LocalData : Singleton<LocalData>
    {
        #region PlayerPref tags
        const string isAudioOnTag = "isAudioOn";
        #endregion
        #region PlayerPrefs setters/getters
        public bool IsAudioOn
        {
            set
            {
                int stateIndex;
                if (value)
                    stateIndex = 0;
                else
                    stateIndex = 1;
                PlayerPrefs.SetInt(isAudioOnTag, stateIndex);
            }
            get
            {
                return PlayerPrefs.GetInt(isAudioOnTag, 0) == 0;
            }
        }
        #endregion
    }
}
