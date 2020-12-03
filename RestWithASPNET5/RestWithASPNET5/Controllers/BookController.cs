using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Services;
using RestWithASPNET5.Models;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Show(long id)
        {
            var book = _bookService.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookService.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
