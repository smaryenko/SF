using System;
namespace SF.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RelativeUrlAttribute : Attribute
    {
        public RelativeUrlAttribute(string relativeUrl)
        {
            RelativeUrl = relativeUrl;
        }

        public string RelativeUrl { get; private set; }
    }
}
