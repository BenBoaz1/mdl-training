namespace MdlTraining.Api.Services;

using MdlTraining.Api.Models;

public class LicenseService {

    private readonly List<License> _licenses = new (){

        new License{
            Id = "MDL100",
            Name = "Lamine Yamal",
            Version = "1.0.0"
        }, 

        new License {
            Id = "MDL200",
            Name = "Raphina",
            Version = "2.0.0"
        }
    };

    public License? GetLicense(string id){
        return _licenses.FirstOrDefault(
            license => license.Id == id
        );
    }

    public List<License> GetAllLicenses(){
        return _licenses;
    }

    public bool AddLicense (License license)
    {
        var existingLicense = _licenses.FirstOrDefault(
            item => item.Id == license.Id
        );

        if (existingLicense != null){
            return false;
        }

        _licenses.Add(license);

        return true;

    }
}