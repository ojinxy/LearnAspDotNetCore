using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnAspDotNetCore.Controllers
{
    public class ROIController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(Roi roi)
        {
            roi.RoiValue = 
                (roi.GainFromInvestment - roi.CostOfInvestment) 
                / roi.CostOfInvestment;

            return View("Index", roi);
        }
    }
}
