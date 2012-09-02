using System;
using System.Collections.Generic;
using FakeItEasy;
using FubuTestingSupport;
using NUnit.Framework;
using Rapptor.Mods.Feathers.Tagging.Api;
using Rapptor.Mods.Feathers.Tagging.Domain;
using Rapptor.Mods.Feathers.Tagging.Domain.Response;

namespace Rapptor.Mods.Feather.Tests.Unit
{
    [TestFixture]
	public class TaggingServiceSpec
    {
	    [Test]
	    public void TaggingServiceCanInsertATag()
	    {
		    //Setup
			var tag = new Tag
				          {
					          PostId = "1"
							  , UserId = "1"
							  , Text = "Tag"
				          };
			var apiCaller = A.Fake<ITaggingApiCaller>();
			A.CallTo(apiCaller).WithReturnType<Tag>().Returns(new Tag
				                                               {
					                                               Id = 1
																   , Text = tag.Text
																   , PostId = tag.PostId
																   , UserId = tag.UserId
																   , TimeStamp = DateTime.Now
				                                               });
			var taggingService = new TaggingService(apiCaller);

			//Execute
			var createdTag = taggingService.AddTag(tag);

			//Verify
			createdTag.ShouldNotBeNull();
			createdTag.Id.ShouldNotBeNull();
			createdTag.TimeStamp.ShouldNotBeNull();

		    //Teardown
	    }

	    [Test]
	    public void TaggingServiceCanDeleteATag()
	    {
			//Setup
			const int tagId = 1;
			var apiCaller = A.Fake<ITaggingApiCaller>();
			var taggingService = new TaggingService(apiCaller);
		    A.CallTo(() => apiCaller.ApiDelete<Tag>(TaggingService.TAGS_ENDPOINT + tagId + "/")).Returns(new Tag {Id = 1});

			//Execute
			var deletedTag = taggingService.DeleteTag(tagId);

			//Verify
			deletedTag.ShouldNotBeNull();

		    //Teardown
	    }

	    [Test]
	    public void TaggingServiceCanGetTagsByPostId()
	    {
		    //Setup
			const string postId = "1";
			var apiCaller = A.Fake<ITaggingApiCaller>();
			var taggingService = new TaggingService(apiCaller);
			A.CallTo(() => apiCaller
				.ApiGet<TagListResponse>(TaggingService.TAGS_ENDPOINT + TaggingService.BY_POST_ENDPOINT + postId + "/"))
					.Returns(new TagListResponse
				            {
					            Tags = new List<Tag> { new Tag { PostId = postId } }
				            });

		    //Execute
		    var tags = taggingService.GetTagsByPostId(postId);

		    //Verify
		    tags.ShouldNotBeNull();
		    tags.ShouldHaveCount(1);
		    foreach (var tag in tags)
		    {
			    tag.PostId.ShouldEqual(postId);
		    }

		    //Teardown
	    }

	    [Test]
	    public void TaggingServiceCanGetTagsByUserId()
	    {
		    //Setup
			const string userId = "1";
			var apiCaller = A.Fake<ITaggingApiCaller>();
			var taggingService = new TaggingService(apiCaller);
			A.CallTo(() => apiCaller
				.ApiGet<TagListResponse>(TaggingService.TAGS_ENDPOINT + TaggingService.BY_USER_ENDPOINT + userId + "/"))
					.Returns(new TagListResponse
				            {
					            Tags = new List<Tag> { new Tag { UserId = userId } }
				            });

		    //Execute
		    var tags = taggingService.GetTagsByUserId(userId);

		    //Verify
		    tags.ShouldNotBeNull();
		    tags.ShouldHaveCount(1);
		    foreach (var tag in tags)
		    {
			    tag.UserId.ShouldEqual(userId);
		    }

		    //Teardown
	    }
    }
}
