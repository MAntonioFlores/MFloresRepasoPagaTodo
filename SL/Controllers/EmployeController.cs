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
        [HttpPost]
        [Route("/Employe/Add")]
        public IActionResult Add([FromBody] ML.Employe employe)
        {
            var result = BL.Employe.AddEmploye(employe);

            var response = new DTO.ResultEmploye
            {
                Success = result.Item1,
                Message = result.Item2,
                Exception = result.Item3
            };
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpPut]
        [Route("/Employe/Update")]
        public IActionResult Update([FromBody] ML.Employe employe)
        {
            var result = BL.Employe.UpdateEmploye(employe);

            var response = new DTO.ResultEmploye
            {
                Success = result.Item1,
                Message = result.Item2,
                Exception = result.Item3
            };
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpDelete]
        [Route("/Employe/Delete")]
        public IActionResult Delete(int EmployeeId)
        {
            var result = BL.Employe.DeleteEmploye(EmployeeId);

            var response = new DTO.ResultEmploye
            {
                Success = result.Item1,
                Message = result.Item2,
                Exception = result.Item3
            };
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpGet]
        [Route("/Employe/ById")]
        public IActionResult ById(int EmployeeId)
        {
            var result = BL.Employe.ById(EmployeeId);

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
                return BadRequest(response);
            }
        }
    }
}
