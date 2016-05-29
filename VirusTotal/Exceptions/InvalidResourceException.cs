using System;

namespace VirusTotal.Exceptions
{
    public class InvalidResourceException : Exception
    {
        public InvalidResourceException(string message) : base(message) { }
    }
}