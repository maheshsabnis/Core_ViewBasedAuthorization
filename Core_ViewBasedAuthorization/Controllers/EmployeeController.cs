using Microsoft.AspNetCore.Mvc;
using Core_ViewBasedAuthorization.Models;
using Microsoft.AspNetCore.Authorization;

namespace Core_ViewBasedAuthorization.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        Employyees employees;

        public EmployeeController()
        {
            employees = new Employyees(); 
        }

        public IActionResult Index()
        {
            return View(employees);
        }
    }
}
