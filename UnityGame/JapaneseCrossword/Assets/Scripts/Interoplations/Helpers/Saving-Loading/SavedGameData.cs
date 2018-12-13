using Assets.Scripts.SimulatedApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Helpers.General;
using UnityEngine;
using System.Xml.Serialization;

namespace Assets.Scripts.Helpers.Saving_Loading
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("SavedGameData")]
    public class SavedGameData
    {
        [XmlArray("appLauncherData")]
        [XmlArrayItem("appLauncherData", typeof(AppLauncherData))]
        public AppLauncherData[] appLauncherData;
        public void Print()
        {
            Debug.Log("--------------Icons---------------");
            foreach(AppLauncherData iconData in appLauncherData)
            {
                iconData.Print();
            }
        }

    }
}
