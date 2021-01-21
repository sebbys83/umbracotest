using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace YoutubeStore.Web.Components.YoutubePlaylist
{
    public class ImportPlaylistVideosAfterSave : IComponent
    {
        private readonly IYoutubePlaylistContentImporter _youtubePlaylistContentImporter;

        public ImportPlaylistVideosAfterSave(IYoutubePlaylistContentImporter youtubePlaylistContentImporter)
        {
            _youtubePlaylistContentImporter = youtubePlaylistContentImporter;
        }

        public void Initialize()
        {
            ContentService.Saved += ContentServiceOnSaved;
        }

        public void Terminate()
        {
            ContentService.Saved -= ContentServiceOnSaved;
        }

        private void ContentServiceOnSaved(IContentService sender, ContentSavedEventArgs e)
        {
            var playlistEntities =
                e.SavedEntities.Where(ent =>
                    ent.ContentType.Alias.InvariantEquals(YoutubePlaylistConstants.ContentTypeAlias));

            foreach (var youtubePlaylist in playlistEntities)
            {
                var youtubePlaylistId =
                    youtubePlaylist.GetValue<string>(YoutubePlaylistConstants.YoutubePlaylistIdNodeName);

                if (string.IsNullOrEmpty(youtubePlaylistId))
                {
                    return;
                }

                _youtubePlaylistContentImporter.Import(youtubePlaylist.Id, youtubePlaylistId);
            }
        }
    }
}