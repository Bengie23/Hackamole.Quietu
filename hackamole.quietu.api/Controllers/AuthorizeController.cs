
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AuthorizeController: ControllerBase {

  [HttpPost]
  [Route("Api/[Controller]/Authorize")]
  public IActionResult Post() {
    
    return Ok("");
  }

}