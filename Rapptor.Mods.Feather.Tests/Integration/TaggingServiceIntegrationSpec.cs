using System.Collections.Generic;
using FubuTestingSupport;
using NUnit.Framework;
using Rapptor.Mods.Feathers.Tagging.Api;
using Rapptor.Mods.Feathers.Tagging.Api.ApiCaller;
using Rapptor.Mods.Feathers.Tagging.Domain;

namespace Rapptor.Mods.Feather.Tests.Integration
{
	[TestFixture]
	public class TaggingServiceIntegrationSpec
	{
		//private const string API_BASE = @"http://localhost:5331/";
		private const string API_BASE = @"http://rapptormods.azurewebsites.net/";

		[Test]
		public void TaggingServiceCanAddATag()
		{
			//Setup
			var tag = new Tag
				          {
					          PostId = "1"
							  , UserId = "2"
							  , Text = "Test Tag"
				          };
			var taggingApiCaller = new RestSharpTaggingApiCaller(API_BASE);
			var taggingService = new TaggingService(taggingApiCaller);

			//Execute
			var createdTag = taggingService.AddTag(tag);

			//Verify
			createdTag.ShouldNotBeNull();
			createdTag.Id.ShouldNotBeNull();
			createdTag.PostId.ShouldNotBeNull();
			createdTag.PostId.ShouldEqual(tag.PostId);
			createdTag.UserId.ShouldNotBeNull();
			createdTag.UserId.ShouldEqual(tag.UserId);
			createdTag.Text.ShouldNotBeNull();
			createdTag.Text.ShouldEqual(tag.Text);
			createdTag.TimeStamp.ShouldNotBeNull();
			
			//Teardown
			taggingService.DeleteTag(createdTag.Id);
		}

		[Test]
		public void TaggingServiceCanDeleteATag()
		{
			//Setup
			var tag = new Tag
				          {
					          PostId = "1"
							  , UserId = "2"
							  , Text = "Test Tag"
				          };
			var taggingApiCaller = new RestSharpTaggingApiCaller(API_BASE);
			var taggingService = new TaggingService(taggingApiCaller);

			//Execute
			var createdTag = taggingService.AddTag(tag);
			createdTag.Id.ShouldNotBeNull();
			
			var deletedTag = taggingService.DeleteTag(createdTag.Id);
			
			//Verify
			deletedTag.ShouldNotBeNull();
			deletedTag.Id.ShouldNotBeNull();
			deletedTag.PostId.ShouldNotBeNull();
			deletedTag.PostId.ShouldEqual(createdTag.PostId);
			deletedTag.UserId.ShouldNotBeNull();
			deletedTag.UserId.ShouldEqual(createdTag.UserId);
			deletedTag.Text.ShouldNotBeNull();
			deletedTag.Text.ShouldEqual(createdTag.Text);
			deletedTag.TimeStamp.ShouldNotBeNull();
			
			//Teardown
		}

		[Test]
		public void TaggingServiceCanGetTagsByPostId()
		{
			//Setup
			const string postId = "777";
			var tag1 = new Tag
				          {
					          PostId = postId
							  , UserId = "1"
							  , Text = "Tag"
				          };
			var tag2 = new Tag
				          {
					          PostId = postId
							  , UserId = "2"
							  , Text = "Tag2"
						  };
			var taggingApiCaller = new RestSharpTaggingApiCaller(API_BASE);
			var taggingService = new TaggingService(taggingApiCaller);

			//Execute
			tag1 = taggingService.AddTag(tag1);
			tag2 = taggingService.AddTag(tag2);

			var tagsByPost = taggingService.GetTagsByPostId(postId);

			//Verify
			tagsByPost.ShouldNotBeNull();
			tagsByPost.ShouldHaveCount(2);
			tagsByPost.Each(x => x.PostId.ShouldEqual(postId));
			

			//Teardown
			taggingService.DeleteTag(tag1.Id);
			taggingService.DeleteTag(tag2.Id);
		}

		[Test]
		public void TaggingServiceCanGetTagsByUserId()
		{
			//Setup
			const string userId = "7";
			var tag1 = new Tag
				          {
					          PostId = "5"
							  , UserId = userId
							  , Text = "Tag"
				          };
			var tag2 = new Tag
				          {
					          PostId = "2"
							  , UserId = userId
							  , Text = "Tag2"
						  };
			var taggingApiCaller = new RestSharpTaggingApiCaller(API_BASE);
			var taggingService = new TaggingService(taggingApiCaller);

			//Execute
			tag1 = taggingService.AddTag(tag1);
			tag2 = taggingService.AddTag(tag2);

			var tagsByPost = taggingService.GetTagsByUserId(userId);

			//Verify
			tagsByPost.ShouldNotBeNull();
			tagsByPost.ShouldHaveCount(2);
			tagsByPost.Each(x => x.UserId.ShouldEqual(userId));
			

			//Teardown
			taggingService.DeleteTag(tag1.Id);
			taggingService.DeleteTag(tag2.Id);
		}
	}
}
