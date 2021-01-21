using YoutubeStore.Core.Models;

namespace YoutubeStore.Core.Interfaces
{
    public interface IYouTubePlaylistImporter
    {
        YoutubePlaylistItem[] Import(string playlistId);
    }
}