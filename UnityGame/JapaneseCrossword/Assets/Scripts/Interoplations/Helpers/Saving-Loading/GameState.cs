using Assets.Scripts.Helpers.Serializers;
using Assets.Scripts.SimulatedApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Helpers.Saving_Loading
{
    public enum SerializationTarget { Settings, GameData};
    [Serializable]
    /// <summary>
    /// Loads and saves game state
    /// </summary>
    class GameState : IOrderMatters
    {
        public string saveFilePath = @"C:\Users\Almantas\Documents/Save1";
        public string settingsFilePath = @"C:\Users\Almantas\Documents/Settings.config";
        public SavedGameData DataToSave { set; get; }
        public Settings Settings { set; get; }

        #region Saveable data in seperate objects
        public AppLauncher[] appIcons;
        #endregion
        /// <summary>
        /// 0- settings serializer, 1- game data serializer
        /// </summary>
        private ISerializer[] serializers;

        public override void Run()
        {
            Debug.Log("GameState");
            SetSerializersDefault();
            StartGame();
        }

        /// <summary>
        /// Sets 2 serializers. By default: 0- Settings, 1- GameData
        /// </summary>
        private void SetSerializersDefault()
        {
            int count = Enum.GetNames(typeof(SerializationTarget)).Length;
            serializers = new ISerializer[count];
            // By default settings are open to external edit, thus XML serializer
            serializers[0] = new XMLSerializer();
            // The other serializable types of data- hard to read
            serializers[1] = new BinarySerializer();
        }

        public void SetSerializer(ISerializer serializer, SerializationTarget target)
        {
            int serializerIndex = (int)target;
            serializers[serializerIndex] = serializer;
        }

        public void StartGame()
        {
            LoadGame();
            LoadSettings();
        }

        public void LoadGame()
        {
            if (File.Exists(saveFilePath))
            {
                SavedGameData data = serializers[0].Deserialize<SavedGameData>(saveFilePath);
                for (int i = 0; i < appIcons.Length; i++)
                {
                    try
                    {
                        appIcons[i].ApplyLoadData(data.appLauncherData[i]);
                    }
                    catch
                    {

                    }
                }
            }
        }

        public void SaveGame()
        {
            SetSaveableGameData();
            serializers[0].Serialize<SavedGameData>(DataToSave ,saveFilePath);
        }

        public void SaveSettings()
        {
            serializers[1].Serialize<Settings>(Settings, settingsFilePath);
        }

        public Settings LoadSettings()
        {
            if (File.Exists(settingsFilePath))
                return serializers[1].Deserialize<Settings>(settingsFilePath);
            else
                return null;
        }

        private void OnDestroy()
        {
            SaveGame();
            SaveSettings();
        }

        public void SetSaveableGameData()
        {
            // Set icons data
            DataToSave = new SavedGameData();
            AppLauncherData[] appData = new AppLauncherData[appIcons.Length];
            for(int i = 0; i < appData.Length; i++)
            {
                appIcons[i].UpdateData();
                appData[i] = appIcons[i].launcherData;
            }
            DataToSave.appLauncherData = appData;
        }
    }
}
