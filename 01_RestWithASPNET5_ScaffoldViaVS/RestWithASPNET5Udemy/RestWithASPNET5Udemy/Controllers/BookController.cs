using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5Udemy.Business.Implementations;
using RestWithASPNET5Udemy.Hypermedia.Filters;
using RestWithASPNET5Udemy.Model;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNET5Udemy.Controllers
{


    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{Version:apiVersion}")]
    [Authorize("Bearer")]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindByID(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
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
