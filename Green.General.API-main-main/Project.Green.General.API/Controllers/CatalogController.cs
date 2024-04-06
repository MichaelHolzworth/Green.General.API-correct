using Microsoft.AspNetCore.Mvc;
using Project.Green.General.Domain.Catalog;

namespace Project.Green.General.Api.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class CatalogController: ControllerBase {
        [HttpGet]

        public IActionResult GetItems(){

            return Ok("Hello World!");

        }
    }
}