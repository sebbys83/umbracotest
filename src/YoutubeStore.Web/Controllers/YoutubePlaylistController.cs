using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using YoutubeStore.Core.Interfaces;
using YoutubeStore.Web.Models;

namespace YoutubeStore.Web.Controllers
{
    public class YoutubePlaylistController : RenderMvcController
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public YoutubePlaylistController(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public override ActionResult Index(ContentModel model) {
            // you are in control here!

            var videoUrlFormat = _appSettingsProvider.Get("Youtube.VideoUrlFormat");

            var videos = model.Content.Children.OrderByDescending(c => c.CreateDate).Select(c => new YoutubeVideoViewModel()
            {
                Title = c.Value<string>("youtubeVideoTitle"),
                ThumbnailUrl = c.Value<string>("youtubeVideoThumbnailUrl"),
                VideoId = c.Value<string>("youtubeVideoId"),
                VideoUrl = string.Format(videoUrlFormat, c.Value<string>("youtubeVideoId"))
            });

            var youtubePlaylist = new YoutubePlaylistViewModel()
            {
                PlaylistId = model.Content.Id,
                YoutubeVideos = videos
            };

            // return a 'model' to the selected template/view for this page.
            return CurrentTemplate(youtubePlaylist);
        }
    }
}