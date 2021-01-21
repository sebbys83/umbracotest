using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Umbraco.Core.Composing.CompositionExtensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using YoutubeStore.Core.Interfaces;

namespace YoutubeStore.Web.Infrastructure
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        public string Get(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
    }
}