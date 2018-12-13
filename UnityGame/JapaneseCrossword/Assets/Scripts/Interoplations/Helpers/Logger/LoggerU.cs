using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Helpers.LoggerU
{
    public static class LoggerU
    {
        const string errorFilePath = @"C:\Users\Almantas\Documents\Unity Games\Secrets Chat App\Errors.log";

        public static void LogError(string message)
        {
            if (File.Exists(errorFilePath))
            {
                message = DateTime.Now.ToString() + " " + message;
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(errorFilePath, true))
                {
                    Debug.Log(message);
                    file.WriteLine(message, true);
                }
            }
            else
            {
                Debug.Log("Err log file not found..");
            }
        }
    }
}
