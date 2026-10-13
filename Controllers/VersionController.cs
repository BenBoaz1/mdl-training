using Microsoft.AspNetCore.Mvc;

namespace MdlTraining.Api.Controllers;

[ApiController]
[Route("version")]

public class VersionController : ControllerBase

{
    [HttpGet("{id}")]
    public IActionResult GetVersion(string id)
    {
        if (id != "MDL100"){
            return NotFound(new
            {
                message = "License not found"
            });
        }

        return Ok(new
        {
            id = "MDL100",
            name = "Lamine Yamal", 
            version = "1.0.0"

        });
    }
}