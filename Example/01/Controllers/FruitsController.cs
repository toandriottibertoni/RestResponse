using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _01.Service;
using RestResponse;
namespace _01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        FruitsService _service;
        RestResult _RestResult;
        public FruitsController()
        {
            _service = new FruitsService();
            _RestResult = new RestResult(this);
        }

        [HttpGet("{fruitName}")]
        public IActionResult Get(string fruitName)
        {
            List<Fruit> fruits = new List<Fruit>();
            fruits = _service.Filter(fruitName);
            if(fruits.Count > 0)
                return Ok(fruits);
            else
                return NotFound();
        }
        
        [HttpGet("rest-response/{fruitName}")]
        public IActionResult GetWithRestResponse(string fruitName)
        {
            return _RestResult.Gen(_service.FilterWithResponse(fruitName));
        }
    }
}
