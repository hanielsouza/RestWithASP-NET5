using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;
        

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secoundNumber}")]
        public IActionResult Sum(string firstNumber,string secoundNumber)
        {
            if(isNumeric(firstNumber) && isNumeric(secoundNumber))
            {
                var sum = ConvertToDecimal(firstNumber)  + ConvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstNumber}/{secoundNumber}")]
        public IActionResult Subtract(string firstNumber, string secoundNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secoundNumber))
            {
                var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secoundNumber);
                return Ok(subtract.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("multi/{firstNumber}/{secoundNumber}")]
        public IActionResult Multiplication(string firstNumber, string secoundNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secoundNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secoundNumber);
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divi/{firstNumber}/{secoundNumber}")]
        public IActionResult Division(string firstNumber, string secoundNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secoundNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secoundNumber);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("average/{firstNumber}/{secoundNumber}")]
        public IActionResult average(string firstNumber, string secoundNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secoundNumber))
            {
                var average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber))/2;
                return Ok(average.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("square/{firstNumber}")]
        public IActionResult square(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                var square = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(square.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number) ;
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber,out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        
    }
}
