
using Microsoft.AspNetCore.Mvc;
// Hii inatupa uwezo wa kutumia ControllerBase,
// [ApiController], [HttpGet], Ok() na NotFound().

using MdlTraining.Api.Services;
// Hii inatuwezesha kutumia LicenseService
// ambayo tulitengeneza kwenye folder ya Services.

namespace MdlTraining.Api.Controllers;
// Namespace ni kama anuani ya class yetu.
// Inaonyesha kwamba VersionController ipo kwenye Controllers.


// [ApiController] inaambia ASP.NET Core kwamba
// class hii ni API Controller.
// Pia inasaidia kushughulikia validation ya requests.
[ApiController]

// [Route("version")] inaweka njia ya kufikia Controller.
// Kwa hiyo URL yetu inaanzia /version.
[Route("version")]


// Tunatengeneza class inayoitwa VersionController.
//
// : ControllerBase maana yake tunarithi uwezo
// wa API Controller kutoka ASP.NET Core,
// mfano Ok() na NotFound().
public class VersionController : ControllerBase
{
    // Hapa tunatangaza variable ya LicenseService.
    //
    // private = inatumika ndani ya class hii tu.
    // readonly = baada ya kupewa value kwenye constructor,
    // hatuwezi kuibadilisha kwenye methods nyingine.
    //
    // _licenseService itatusaidia kuwasiliana
    // na business logic iliyopo kwenye Service.
    private readonly LicenseService _licenseService;


    // HII NI CONSTRUCTOR.
    //
    // ASP.NET Core inatupatia LicenseService
    // kupitia Dependency Injection (DI).
    //
    // Badala ya Controller kujitengenezea Service,
    // mfumo unaitoa Service iliyosajiliwa.
    public VersionController(LicenseService licenseService)
    {
        // Tunahifadhi Service tuliyopewa
        // ili tuweze kuitumia kwenye methods zetu.
        _licenseService = licenseService;
    }


    // [HttpGet("{id}")] inasema:
    // Endpoint hii inapokea HTTP GET request.
    //
    // Mfano:
    // GET /version/MDL100
    //
    // MDL100 ndiyo value ya {id}.
    [HttpGet("{id}")]

    // IActionResult inaruhusu method kurudisha
    // HTTP responses tofauti, mfano:
    // 200 OK au 404 Not Found.
    //
    // string id = ID iliyotumwa kwenye URL.
    public IActionResult GetVersion(string id)
    {
        // STEP 1: Controller inaita LicenseService.
        //
        // Tunaituma ID kwenye GetLicense(id).
        // Service inatafuta license yenye ID hiyo.
        //
        // var license inahifadhi matokeo.
        // Matokeo yanaweza kuwa License object au null.
        var license = _licenseService.GetLicense(id);


        // STEP 2: Tunaangalia kama license imepatikana.
        //
        // null maana yake Service haijapata license.
        if (license == null)
        {
            // Kama haijapatikana, tunarudisha
            // HTTP 404 Not Found.
            //
            // new { ... } inatengeneza anonymous object
            // yenye message ya kuelezea tatizo.
            return NotFound(new
            {
                message = "License not found"
            });
        }


        // STEP 3: Kama license imepatikana,
        // tunarudisha HTTP 200 OK.
        //
        // license.Version inachukua version
        // kutoka kwenye License object.
        //
        // new { version = ... } inatengeneza
        // anonymous object kwa ajili ya response.
        //
        // ASP.NET Core inaitengenezea JSON response.
        return Ok(new
        {
            version = license.Version
        });
    }


    [HttpGet("/licenses")]
    public IActionResult GetAllLicenses(){
        var license = _licenseService.GetAllLicenses();

        return Ok(license);
    }
}
