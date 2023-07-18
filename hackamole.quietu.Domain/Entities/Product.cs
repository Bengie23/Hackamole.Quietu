namespace Hackamole.Quietu.Domain.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }

		public List<Principal> Principals { get; set; } = new();
	}
}

