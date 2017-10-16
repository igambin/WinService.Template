namespace WinService.Logging.LogModels
{
    public interface ISerializingLogItem<TItem> : ILogItem
    {
        TItem DataItem { get; set; }

    }
}