using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Composing;
using YoutubeStore.Core.Interfaces;
using YoutubeStore.Web.Components;
using YoutubeStore.YoutubeImporter;

namespace YoutubeStore.Web.Infrastructure.Composers
{
    public class ComponentsRegistration : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register(typeof(IAppSettingsProvider), typeof(AppSettingsProvider), Lifetime.Request);
            composition.Register(typeof(IYoutubePlaylistContentImporter), typeof(YoutubePlaylistContentImporter), Lifetime.Request);
            composition.Register(typeof(IYouTubePlaylistImporter), typeof(YoutubePlaylistImporter), Lifetime.Request);
        }
    }
}