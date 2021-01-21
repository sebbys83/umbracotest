using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;
using YoutubeStore.Web.Components;
using YoutubeStore.Web.Components.YoutubePlaylist;

namespace YoutubeStore.Web.Controllers
{
    public class PlaylistApiController : UmbracoApiController
    {
        private readonly IContentService _contentService;
        private readonly IYoutubePlaylistContentImporter _youtubePlaylistContentImporter;

        public PlaylistApiController(IContentService contentService, IYoutubePlaylistContentImporter youtubePlaylistContentImporter)
        {
            _contentService = contentService;
            _youtubePlaylistContentImporter = youtubePlaylistContentImporter;
        }

        public bool RefreshPlaylist(int playlistId)
        {
            var youtubePlaylist = _contentService.GetById(playlistId);

            var youtubePlaylistId =
                youtubePlaylist.GetValue<string>(YoutubePlaylistConstants.YoutubePlaylistIdNodeName);

            try
            {
                _youtubePlaylistContentImporter.Import(youtubePlaylist.Id, youtubePlaylistId);
            } catch (Exception e)
            {
                Logger.Error(typeof(PlaylistApiController), $"Unable to refresh Youtube playlist id {youtubePlaylistId}");
                return false;
            }

            return true;
        }
    }
}