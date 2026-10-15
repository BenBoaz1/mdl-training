namespace MdlTraining.Api.Services;

using MdlTraining.Api.Models;

public class LicenseService {

public License? GetLicense (string Id){

            if (Id == "MDL100")
    {
        return new License
        {
            Id = Id,
            Name = "Lamine Yamal",
            Version = "1.0.0"
        };
    }
            if (Id == "MDL200")
{
    return new License
    {
        Id = Id,
        Name = "raphina",
        Version = "2.0.0"
    };
}
return null;
}
}