using System;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace YoutubeStore.Web.Components.YoutubePlaylist
{
    public class PreventUpdatingPlaylistUrl : IComponent
    {
        public void Initialize()
        {
            ContentService.Saving += ContentServiceOnSaving;
        }

        public void Terminate()
        {
            ContentService.Saving -= ContentServiceOnSaving;
        }

        private void ContentServiceOnSaving(IContentService sender, ContentSavingEventArgs e) {
            var playlistEntities =
                e.SavedEntities.Where(ent => ent.ContentType.Alias.InvariantEquals(YoutubePlaylistConstants.ContentTypeAlias));

            foreach (var youtubePlaylist in playlistEntities)
            {
                var currentPlaylist = sender.GetById(youtubePlaylist.Id);

                if (currentPlaylist == null)
                {
                    continue;
                }

                var currentUrl = currentPlaylist.GetValue<string>(YoutubePlaylistConstants.YoutubePlaylistUrlNodeName);
                var newurl = youtubePlaylist.GetValue<string>(YoutubePlaylistConstants.YoutubePlaylistUrlNodeName);

                if (!currentUrl.Equals(newurl, StringComparison.OrdinalIgnoreCase)) 
                { 
                    youtubePlaylist.SetValue(YoutubePlaylistConstants.YoutubePlaylistUrlNodeName, currentUrl);

                    e.Messages.Add(new EventMessage("Playlist Url", "Once saved, playlist Url cannot be updated. Url was reverted to the original value.", EventMessageType.Warning));
                }
            }
        }
    }
}