using anyamkurvaistenit.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anyamkurvaistenit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetablesController : ControllerBase
    {
        private static List<Vegetables> VegetablesList { get; set; } = new List<Vegetables>();

        [HttpPost]
        public IActionResult Post([FromBody] Vegetables vegetable) {
            VegetablesList.Add(vegetable);
            return Created("OK", vegetable);
        }

        [HttpGet]
        public IEnumerable<Vegetables> Get() {
            return VegetablesList;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var item = VegetablesList.First(x => x.id == id);

            if (item == null) {
                return NotFound();
            }
            return new JsonResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var item = VegetablesList.First(x => x.id == id);
            if (item == null) {
                return NotFound();
            }
            VegetablesList.Remove(item);
            return Ok();
        }
    }
}
