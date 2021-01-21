using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using YoutubeStore.Core.Interfaces;
using YoutubeStore.Web.Components.YoutubePlaylist;

namespace YoutubeStore.Web.Components
{
    public interface IYoutubePlaylistContentImporter
    {
        void Import(int playlistNodeId, string youtubePlaylistId);
    }

    public class YoutubePlaylistContentImporter : IYoutubePlaylistContentImporter
    {
        private readonly IYouTubePlaylistImporter _youTubePlaylistImporter;
        private readonly IContentService _contentService;

        public YoutubePlaylistContentImporter(IYouTubePlaylistImporter youTubePlaylistImporter, IContentService contentService)
        {
            _youTubePlaylistImporter = youTubePlaylistImporter;
            _contentService = contentService;
        }

        public void Import(int playlistNodeId, string youtubePlaylistId)
        {
            if (playlistNodeId <= 0 || string.IsNullOrEmpty(youtubePlaylistId))
            {
                return;
            }

            var playlistNode = _contentService.GetById(playlistNodeId);
            if (playlistNode == null)
            {
                return;
            }

            long totalChildren;
            var existingVideoIds = _contentService.GetPagedChildren(playlistNodeId, 0, 100, out totalChildren).Select(c => c.GetValue<string>(YoutubeVideoConstants.YoutubeVideoIdPropertyAlias)).ToArray();

            var playlistItems = _youTubePlaylistImporter.Import(youtubePlaylistId);

            foreach (var youtubePlaylistItem in playlistItems)
            {
                if (existingVideoIds.Contains(youtubePlaylistItem.Id))
                {
                    continue;
                }

                var newYoutubeVideoContentItem = _contentService.Create($"Video - {youtubePlaylistItem.Id}", playlistNodeId,
                    YoutubeVideoConstants.ContentTypeAlias);

                newYoutubeVideoContentItem.SetValue(YoutubeVideoConstants.YoutubeVideoIdPropertyAlias, youtubePlaylistItem.Id);
                newYoutubeVideoContentItem.SetValue(YoutubeVideoConstants.YoutubeVideoThumbnailUrlPropertyAlias, youtubePlaylistItem.ThumbnailUrl);
                newYoutubeVideoContentItem.SetValue(YoutubeVideoConstants.YoutubeVideoTitlePropertyAlias, youtubePlaylistItem.Title);

                _contentService.SaveAndPublish(newYoutubeVideoContentItem);
            }
        }
    }
}