using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using YoutubeStore.Web.Components;
using YoutubeStore.Web.Components.YoutubePlaylist;

namespace YoutubeStore.Web.Infrastructure.Composers
{
    public class PlaylistNodeComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<PreventUpdatingPlaylistUrl>();
            composition.Components().InsertAfter<PreventUpdatingPlaylistUrl, ExtractDetailsFromPlaylistUrl>();
            composition.Components().Append<ImportPlaylistVideosAfterSave>();
        }
    }
}