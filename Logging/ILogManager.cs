using System;

namespace WinService.Logging
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
    }
}