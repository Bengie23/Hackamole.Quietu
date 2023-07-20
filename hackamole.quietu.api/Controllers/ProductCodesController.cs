using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackamole.Quietu.Domain.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hackamole.quietu.api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class ProductCodesController : ControllerBase
    {
        private readonly ProductConsumptionQuery productConsumptionQuery;
        private readonly ProductDetailConsumptionQuery productDetailConsumptionQuery;

        public ProductCodesController(  ProductConsumptionQuery productConsumptionQuery,
                                        ProductDetailConsumptionQuery productDetailConsumptionQuery)
        {
            this.productConsumptionQuery = productConsumptionQuery;
            this.productDetailConsumptionQuery = productDetailConsumptionQuery;

            ArgumentNullException.ThrowIfNull(productConsumptionQuery, nameof(productConsumptionQuery));
            ArgumentNullException.ThrowIfNull(productDetailConsumptionQuery, nameof(productDetailConsumptionQuery));
        }

        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            var data = productConsumptionQuery.ExecuteQuery();
            return Ok(data);
        }

        [HttpGet("GetByProductCode")]

        public IActionResult GetByProductCode(string productCode)
        {
            var data = productDetailConsumptionQuery.ExecuteQuery(productCode);
            return Ok(data);
        }
    }
}

