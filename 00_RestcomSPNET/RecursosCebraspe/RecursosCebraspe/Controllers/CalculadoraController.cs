using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RecursosCebraspe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult Getsum(string firstNumber, string secondNumber)
        {
            if(Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum);
            }

            return BadRequest("Ivalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult Getsub(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub);
            }

            return BadRequest("Ivalid Input");
        }
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public ActionResult Getmult(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult);
            }

            return BadRequest("Ivalid Input");
        }
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult Getdiv(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div);
            }

            return BadRequest("Ivalid Input");
        }
        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public ActionResult Getmed(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(med);
            }

            return BadRequest("Ivalid Input");
        }
        [HttpGet("raiz/{firstNumber}")]
        public ActionResult Getraiz(string firstNumber)
        {
            if (Isnumeric(firstNumber))
            {
                var raiz = ConvertToDecimal(firstNumber);
                return Ok(Math.Sqrt(((double)raiz)));
            }

            return BadRequest("Ivalid Input");
        }
        private bool Isnumeric(string Strnumber)
        {
            double number;
            bool isNumber = double.TryParse(Strnumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }
        private decimal ConvertToDecimal(string Strnumero)
        {
            decimal decimalValue;
            if(Strnumero.Contains("."))
            Strnumero =  Strnumero.Replace(".", ",");

            if (decimal.TryParse(Strnumero, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

       
    }
}
