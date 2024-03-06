using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var connection = new SqlConnection("Data Source=.;Initial Catalog=Blog;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            var command = new SqlCommand($"select count(1) from post where id=1", connection);
           // var usernameParameter = new SqlParameter("username", username);
           // var passwordParameter = new SqlParameter("password", password);
           // command.Parameters.Add(usernameParameter);
           // command.Parameters.Add(passwordParameter);


            connection.Open();
            var isExists = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (isExists >= 1)
                return Content("Ok");
            return Content("Not OK");


            // return View();
            //Data Source=.;Initial Catalog=Blog;Integrated Security=True;Encrypt=True;Trust Server Certificate=True

            return Json(new { title = ":))))))"});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
