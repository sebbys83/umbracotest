using System;
using System.Linq;
using System.Net.Http;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace YoutubeStore.Web.Components.YoutubePlaylist
{
    public class ExtractDetailsFromPlaylistUrl : IComponent
    {
        public void Initialize()
        {
            ContentService.Saving += ContentServiceOnSaving;
        }

        public void Terminate()
        {
            ContentService.Saving -= ContentServiceOnSaving;
        }
        private void ContentServiceOnSaving(IContentService sender, ContentSavingEventArgs e)
        {
            var playlistEntities =
                e.SavedEntities.Where(ent => ent.ContentType.Alias.InvariantEquals(YoutubePlaylistConstants.ContentTypeAlias));

            foreach (var youtubePlaylist in playlistEntities)
            {
                if (!string.IsNullOrEmpty(
                    youtubePlaylist.GetValue<string>(YoutubePlaylistConstants.YoutubePlaylistIdNodeName)))
                {
                    return;
                }

                var url = youtubePlaylist.GetValue<string>(YoutubePlaylistConstants.YoutubePlaylistUrlNodeName);

                Uri playlistUri;
                if (Uri.TryCreate(url, UriKind.Absolute, out playlistUri))
                {
                    var queryStringParameters = playlistUri.ParseQueryString();

                    if (queryStringParameters["list"] != null)
                    {
                        youtubePlaylist.SetValue(YoutubePlaylistConstants.YoutubePlaylistIdNodeName, queryStringParameters["list"]);
                    }
                }
            }
        }
    }
}