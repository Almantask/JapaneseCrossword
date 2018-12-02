using System;

namespace GridGenerator
{
    public class StatsNotSetException : Exception
    {
        public StatsNotSetException(string message):base(message)
        {
        }
    }
}