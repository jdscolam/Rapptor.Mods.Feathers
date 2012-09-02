using System;

namespace Rapptor.Mods.Feathers.Tagging.Domain
{
	public class Tag
	{
		public int? Id { get; set; }
		public string Text { get; set; }
		public string UserId { get; set; }
		public string PostId { get; set; }
		public DateTime? TimeStamp { get; set; }
	}
}
