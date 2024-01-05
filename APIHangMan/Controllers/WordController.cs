using BLL.DTO;
using BLL.Forms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIHangMan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{

    private readonly WordService _wordService;

    public WordController(WordService wordService)
    {
        _wordService = wordService;
    }
    
    
    [HttpPost]
    public IActionResult Add(AddWordForm form)
    {
        return _wordService.Add(form) ? Ok("Ajout effectué") : BadRequest();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_wordService.GetAll());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        return _wordService.Delete(id) ? Ok() : BadRequest();
    }

    [HttpGet]
    [Route("GetRandom")]
    public IActionResult Get()
    {
        return Ok(_wordService.GetRandom());
    }
}