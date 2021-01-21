using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using YoutubeStore.Core.Interfaces;
using YoutubeStore.Core.Models;

namespace YoutubeStore.YoutubeImporter
{
    public class YoutubePlaylistImporter : IYouTubePlaylistImporter
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public YoutubePlaylistImporter(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public YoutubePlaylistItem[] Import(string playlistId)
        {
            var apiKey = _appSettingsProvider.Get("Youtube.ApiKey");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ApplicationException("Unable to get Youtube API Key");
            }

            var result = new List<YoutubePlaylistItem>();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApplicationName = this.GetType().ToString(),
                ApiKey = apiKey
            });

            var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsListRequest.PlaylistId = playlistId;
            playlistItemsListRequest.MaxResults = 20;

            var playlistItemsListResponse = playlistItemsListRequest.Execute();

            foreach (var playlistItem in playlistItemsListResponse.Items) {
                var youtubePlaylistItem = new YoutubePlaylistItem()
                {
                    Id = playlistItem.Snippet.ResourceId.VideoId,
                    Title = playlistItem.Snippet.Title,
                    Description = playlistItem.Snippet.Description,
                    ThumbnailUrl = playlistItem.Snippet.Thumbnails.High.Url,
                };

                result.Add(youtubePlaylistItem);
            }

            return result.ToArray();
        }
    }
}
