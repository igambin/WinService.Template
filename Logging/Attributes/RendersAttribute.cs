using System;

namespace WinService.Logging.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RendersAttribute : Attribute
    {
        public RendersAttribute(Type type)
        {
            RendersType = type;
        }

        public Type RendersType { get; }
    }
}
