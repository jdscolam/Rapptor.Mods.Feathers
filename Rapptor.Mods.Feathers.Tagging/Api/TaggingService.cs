using System;
using System.Collections.Generic;
using Rapptor.Mods.Feathers.Tagging.Domain;
using Rapptor.Mods.Feathers.Tagging.Domain.Response;

namespace Rapptor.Mods.Feathers.Tagging.Api
{
	public class TaggingService
	{
		public const string TAGS_ENDPOINT = "tags/";
		public const string BY_POST_ENDPOINT = "by-post/";
		public const string BY_USER_ENDPOINT = "by-user/";

		private readonly ITaggingApiCaller _apiCaller;

		public TaggingService(ITaggingApiCaller apiCaller)
		{
			_apiCaller = apiCaller;
		}

		public Tag AddTag(Tag tag)
		{
			var addedTag = _apiCaller.ApiPost<Tag, Tag>(TAGS_ENDPOINT, tag);

			return addedTag;
		}

		public Tag DeleteTag(int? tagId)
		{
			if(!tagId.HasValue)
				throw new ArgumentException("Cannot Delete Tag, no value given for tagId!");
			
			var tagIdCallString = tagId + "/";
			var tag = _apiCaller.ApiDelete<Tag>(TAGS_ENDPOINT + tagIdCallString);

			return tag;
		}

		public List<Tag> GetTagsByPostId(string postId)
		{
			var postIdCallString = postId + "/";
			var tagList = _apiCaller.ApiGet<TagListResponse>(TAGS_ENDPOINT + BY_POST_ENDPOINT + postIdCallString);

			return tagList.Tags;
		}

		public List<Tag> GetTagsByUserId(string userId)
		{
			var userIdCallString = userId + "/";
			var tagList = _apiCaller.ApiGet<TagListResponse>(TAGS_ENDPOINT + BY_USER_ENDPOINT + userIdCallString);

			return tagList.Tags;
		}
	}
}