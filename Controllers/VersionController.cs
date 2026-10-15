using Microsoft.AspNetCore.Mvc;

namespace MdlTraining.Api.Controllers;

[ApiController]
[Route("version")]

public class VersionController : ControllerBase

{
    [HttpGet("{id}")]
    public IActionResult GetVersion(string id) {
        if (id != "MDL100" && id != "MDL200") {
            return NotFound(new { 
                message = "License not found" });
        }

               if (id == "MDL100")
        {
            return Ok(new
            {
                id = id,
                name = "Lamine Yamal",
                version = "1.0.0"
            });
        }

        return Ok(new
        {
            id = id,
            name = "raphina",
            version = "2.0.0"
        });
    }
}