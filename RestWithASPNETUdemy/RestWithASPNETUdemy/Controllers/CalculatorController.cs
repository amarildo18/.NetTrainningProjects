using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
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

        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public ActionResult Soma(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid operation"); 
        }

        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public ActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtracao = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtracao.ToString());
            }
            return BadRequest("Nao foi possivel efetuar a operacao");
        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public ActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var resultado = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(resultado.ToString());
            }
            return BadRequest("Nao foi possivel efetuar a operacao");
        }

        [HttpGet("divisao/{dividendo}/{divisor}")]
        public ActionResult Divisao(string dividendo, string divisor)
        {
            if(IsNumeric(divisor) && IsNumeric(dividendo))
            {
                var resultado = ConvertToDecimal(dividendo) / ConvertToDecimal(divisor);
                return Ok(resultado.ToString());
            }

            return BadRequest("Não foi possível efetuar a operação");
        }

        [HttpGet("raisQuadrada/{valor}")]
        public ActionResult RaizQuadrada(string valor)
        {
            if (IsNumeric(valor))
            {
                var resultado = Math.Sqrt( (double) ConvertToDecimal(valor));
                return Ok(resultado.ToString());
            }

            return BadRequest("Não foi possível concluir a operção");
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumeric = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number
            );

            return isNumeric;
        }
    }
}