using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5Udemy.Business.Implementations;
using RestWithASPNET5Udemy.Model;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNET5Udemy.Controllers
{


    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{Version:apiVersion}")]
    public class BookController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IBookBusiness _bookBusiness;
        public BookController(ILogger<PersonController> logger, IBookBusiness bookbusiness)
        {
            _logger = logger;
            _bookBusiness = bookbusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_bookBusiness.FindByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
