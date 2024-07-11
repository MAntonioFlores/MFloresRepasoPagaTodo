using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmployesController : Controller
    {
        [HttpGet] 
        public IActionResult AllEmployes()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5050/");

                var responseTask = client.GetAsync("Employe/All");
                responseTask.Wait(); 

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.ResultEmploye>();
                    readTask.Wait(); 

                    var apiResponse = readTask.Result;

                    if (apiResponse.Success)
                    {

                        return View(apiResponse.EmployeData);
                    }
                    else
                    {
                        ML.Employe employe = new ML.Employe();
                        return View(employe);
                    }
                }
                else
                {
                    ML.Employe employe = new ML.Employe();
                    return View(employe);
                }
            }
        }
    }
}
