using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Helpers.Serializers
{
    public interface ISerializer
    {
        /// <summary>
        /// Serializes data from an object to a path.
        /// </summary>
        /// <param name="data"> Data to serialize.</param>
        /// <param name="filePath"> File path to deserialize to.</param>
        void Serialize<T>(T data, string filePath) where T : class;
        /// <summary>
        /// Deserializes data from a file to an object.
        /// </summary>
        /// <param name="filePath"> File path to deserialize from.</param>
        /// <returns> Deserialized object.</returns>
        T Deserialize<T>(string filePath) where T : class;
    }
}
