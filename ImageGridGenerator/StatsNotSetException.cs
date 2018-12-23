using System;

namespace ImageProcessing
{
    public class StatsNotSetException : Exception
    {
        public StatsNotSetException(string message):base(message)
        {
        }
    }
}