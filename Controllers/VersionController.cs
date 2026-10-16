using Microsoft.AspNetCore.Mvc;

using MdlTraining.Api.Services;

namespace MdlTraining.Api.Controllers;

[ApiController]
[Route("version")]

public class VersionController : ControllerBase

{
    private readonly LicenseService _licenseService;

    public VersionController(LicenseService licenseService)
    {
        _licenseService = licenseService;
    }
    [HttpGet("{id}")]
    public IActionResult GetVersion(string id) {
         var license = _licenseService.GetLicense(id);

    if (license == null)
    {
        return NotFound(new
        {
            message = "License not found"
        });
    }

    return Ok(license);

    }
}