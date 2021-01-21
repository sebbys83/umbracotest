using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeStore.Core.Models
{
    public class YoutubePlaylistItem
    {
        public string Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
