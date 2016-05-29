using System;

namespace VirusTotal.Exceptions
{
    /// <summary>
    /// Exception that is thrown when the file size exceeds 32 MB.
    /// </summary>
    public class SizeLimitException : Exception
    {
        public SizeLimitException(string message)
            : base(message)
        {
        }
    }
}
