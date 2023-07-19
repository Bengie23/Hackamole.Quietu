using System.Text.Json.Serialization;

namespace Hackamole.Quietu.Domain.Entities
{
	public class Principal
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public string KeyId { get; set; }

		[JsonIgnore]
		public string Secret { get; set; }

		public List<Product> Products { get; set; } = new();

		public PrincipalType Type { get; set; }
	}
}

