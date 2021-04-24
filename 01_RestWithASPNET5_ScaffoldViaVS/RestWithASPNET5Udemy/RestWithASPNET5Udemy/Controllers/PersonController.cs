using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Business;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{Version:apiVersion}")]//pega a rota e junta com o valor parametrizado no anotation [ApiVersion("1")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;


        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusines)
        {
            _logger = logger;
            _personBusiness = personBusines;
        }

        [HttpGet]
        [ProducesResponseType((200),Type =typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {

            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {

            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }


        [HttpDelete("{id}")]
        //Customização do swagger
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
             _personBusiness.Delete(id);
            return NoContent();
        }


        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


    }
}
