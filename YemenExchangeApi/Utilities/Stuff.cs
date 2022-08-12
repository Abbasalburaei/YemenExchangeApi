using System.Runtime.InteropServices;

namespace YemenExchangeApi.Utilities
{
    public static class Stuff
    {
        public static bool IsMatchedSegmentParts(string text , int mandatoryLength = 4 , string pattern = " ")
        {
            if (!string.IsNullOrEmpty(text))
            {
               var segments = text.Split(pattern);
                return (segments.Length == mandatoryLength);
            }
            return false;
        }
    }
}
