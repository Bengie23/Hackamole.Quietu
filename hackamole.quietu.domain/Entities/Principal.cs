namespace Hackamole.Quietu.Domain.Entities
{
	public class Principal
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string KeyId { get; set; }

		public string Secret { get; set; }

		public List<Product> Products { get; set; } = new();
	}
}

