using System.Collections.Generic;

namespace Rapptor.Mods.Feathers.Tagging.Domain.Response
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