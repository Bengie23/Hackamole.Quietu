using System;
namespace Hackamole.Quietu.Api.Data
{
	public interface IProductRepository
	{
		string GetByProductByCode(string productCode);
	}
}

