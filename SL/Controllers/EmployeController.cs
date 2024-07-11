using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        [HttpGet]
        [Route("/Employe/All")]
        public IActionResult All()
        {
            var result = BL.Employe.AllEmploye();

            var response = new DTO.ResultEmploye
            {
                Success = result.Item1,
                Message = result.Item2,
                EmployeData = result.Item3,
                Exception = result.Item4
            };

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
