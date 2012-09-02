using System.Collections.Generic;
using Rapptor.Mods.Feathers.Tagging.Domain;

namespace Rapptor.Mods.Feathers.Tagging.Api
{
	public class TagListResponse
	{
		public TagListResponse()
		{
			Tags = new List<Tag>();
		}

		public List<Tag> Tags { get; set; }
	}
}