//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.10.1
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Youtube Video</summary>
	[PublishedModel("youtubeVideo")]
	public partial class YoutubeVideo : PublishedContentModel, IMetadata, IYoutubeVideoDetails
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		public new const string ModelTypeAlias = "youtubeVideo";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<YoutubeVideo, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public YoutubeVideo(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Keywords: Page keywords (displayed in metadata)
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		[ImplementPropertyType("metadataKeywords")]
		public string MetadataKeywords => global::Umbraco.Web.PublishedModels.Metadata.GetMetadataKeywords(this);

		///<summary>
		/// Title: Page title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		[ImplementPropertyType("metadataTitle")]
		public string MetadataTitle => global::Umbraco.Web.PublishedModels.Metadata.GetMetadataTitle(this);

		///<summary>
		/// Video Id
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		[ImplementPropertyType("youtubeVideoId")]
		public string YoutubeVideoId => global::Umbraco.Web.PublishedModels.YoutubeVideoDetails.GetYoutubeVideoId(this);

		///<summary>
		/// Thumbnail Url
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		[ImplementPropertyType("youtubeVideoThumbnailUrl")]
		public string YoutubeVideoThumbnailUrl => global::Umbraco.Web.PublishedModels.YoutubeVideoDetails.GetYoutubeVideoThumbnailUrl(this);

		///<summary>
		/// Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.10.1")]
		[ImplementPropertyType("youtubeVideoTitle")]
		public string YoutubeVideoTitle => global::Umbraco.Web.PublishedModels.YoutubeVideoDetails.GetYoutubeVideoTitle(this);
	}
}
