namespace YoutubeStore.Core.Interfaces
{
    public interface IAppSettingsProvider
    {
        string Get(string key);
    }
}