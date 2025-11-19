using Microsoft.AspNetCore.Mvc;

namespace jogos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Serviço de Jogos está funcionando!" });
    }
}