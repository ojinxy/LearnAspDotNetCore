using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LearnAspDotNetCore.Data;
using LearnAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnAspDotNetCore.Controllers
{
    public class QuestionController : Controller
    {
		private readonly LearnAspDotNetCoreContext _context;

        public QuestionController(LearnAspDotNetCoreContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Questions_Day_1()
        {
            TestComposite testComposite = new TestComposite();
            var listTest = _context.Test.ToList();
            testComposite.tests = listTest;
            return View(testComposite);
        }

        public async Task<IActionResult> Questions_Day_1_q1(TestComposite testComp)
        {
            //testComp.test.Title = HtmlEncoder.Default.Encode($"Test title = {testComp.test.Title}");
            _context.Test.Add(testComp.test);
            await _context.SaveChangesAsync();

            return RedirectToAction("Questions_Day_1");
        }

        [HttpGet]
        public ActionResult GetTest(){
            return Json(new Test()
            {
                ID = 0,
                Name = "Test Person",
                Title = "Test"
            });
        }

    }
}
