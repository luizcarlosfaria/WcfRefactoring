using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WcfRefactoring.ASPNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : ControllerBase, ICalc
    {
        private readonly ILogger<CalcController> _logger;
        private readonly ICalc calc;

        public CalcController(ILogger<CalcController> logger, ICalc calc)
        {
            _logger = logger;
            this.calc = calc;
        }

        [HttpGet]
        public string HelloWorld() => "Up and Runing";

        [HttpPost]
        public int Sum([FromForm] int part1, [FromForm] int part2)
        {
            return this.calc.Sum(part1, part2);
        }
    }
}
