using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoutubeStore.Web.Models
{
    public class YoutubePlaylistViewModel
    {
        public int PlaylistId { get; set; }
        public IEnumerable<YoutubeVideoViewModel> YoutubeVideos { get; set; }
    }

    public class YoutubeVideoViewModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}