using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jamintech.champs.coreAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GetVersionController : ControllerBase
{
    [HttpGet(Name = "GetVersion")]
    public AppVersion Get()
    {
        var appVersion = new AppVersion();
        appVersion.fileVersion = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;

        return appVersion;
    }
}