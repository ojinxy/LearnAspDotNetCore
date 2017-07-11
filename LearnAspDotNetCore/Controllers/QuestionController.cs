using System;
using System.Linq;
using System.Threading.Tasks;
using LearnAspDotNetCore.Data;
using LearnAspDotNetCore.Logics;
using LearnAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
        public ActionResult GetTest()
        {
            return Json(new Test()
            {
                ID = 0,
                Name = "Test Person",
                Title = "Test"
            });
        }

        public IActionResult Question5()
        {
            return View();
        }


        public IActionResult Question5AnswerThread(Question5Model q5Model)
        {
            DateTime startTime = DateTime.Now;

            Question5Logics q5Logics = new Question5Logics(q5Model.question);

            ThreadStart threadLoopDel = delegate {
                q5Model.question5Results.Add(
                    new Question5Result(Thread.CurrentThread.ManagedThreadId.ToString()
                                        ,q5Logics.getAnswerFromLoop()
                                       ,"Loop"));
            };
            Thread threadLoop = new Thread(threadLoopDel);
            threadLoop.Start();

			ThreadStart threadRecursiveDel = delegate
			{
				q5Model.question5Results.Add(
					new Question5Result(Thread.CurrentThread.ManagedThreadId.ToString()
                                        , q5Logics.getAnswerFromRecursive()
									   , "Recursive"));
			};
            Thread threadRecursive = new Thread(threadRecursiveDel);
            threadRecursive.Start();

            while(threadRecursive.ThreadState != ThreadState.Stopped 
                  || threadLoop.ThreadState != ThreadState.Stopped){
                
            }

            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime - startTime;
			int ms = (int)span.TotalMilliseconds;

            q5Model.duration = ms;

            return View("Question5", q5Model);

        }

		public IActionResult Question5AnswerSynchronous(Question5Model q5Model)
		{
			DateTime startTime = DateTime.Now;

			Question5Logics q5Logics = new Question5Logics(q5Model.question);

			q5Model.question5Results.Add(
							new Question5Result(Thread.CurrentThread.ManagedThreadId.ToString()
												, q5Logics.getAnswerFromLoop()
											   , "Loop"));

			q5Model.question5Results.Add(
						new Question5Result(Thread.CurrentThread.ManagedThreadId.ToString()
											, q5Logics.getAnswerFromRecursive()
										   , "Recursive"));


			DateTime endTime = DateTime.Now;

			TimeSpan span = endTime - startTime;
			int ms = (int)span.TotalMilliseconds;

			q5Model.duration = ms;

			return View("Question5", q5Model);

		}

		public async Task<IActionResult> Question5AnswerAsynchronous(Question5Model q5Model)
		{
			DateTime startTime = DateTime.Now;

			Question5Logics q5Logics = new Question5Logics(q5Model.question);

            var taskLoop = new TaskCompletionSource<UInt64>();
            var tcsLoop = new TaskCompletionSource<UInt64>();
			ThreadPool.QueueUserWorkItem(_ =>
			{
				try
				{
                    UInt64 result = q5Logics.getAnswerFromLoop();
					tcsLoop.SetResult(result);
				}
				catch (Exception exc) { tcsLoop.SetException(exc); }
			});


			var taskRec = new TaskCompletionSource<UInt64>();
			var tcsRec = new TaskCompletionSource<UInt64>();
            ThreadPool.QueueUserWorkItem(_ =>
			{
				try
				{
					UInt64 result = q5Logics.getAnswerFromLoop();
					tcsRec.SetResult(result);
				}
				catch (Exception exc) { tcsRec.SetException(exc); }
			});

			
            UInt64 ansLoop = await tcsLoop.Task;

            UInt64 ansRec = await tcsRec.Task;

			q5Model.question5Results.Add(
							new Question5Result(Thread.CurrentThread.ManagedThreadId.ToString()
												, ansLoop
											   , "Loop"));

			q5Model.question5Results.Add(
						new Question5Result(Thread.CurrentThread.ManagedThreadId.ToString()
                                            , ansRec
										   , "Recursive"));


			DateTime endTime = DateTime.Now;

			TimeSpan span = endTime - startTime;
			int ms = (int)span.TotalMilliseconds;

			q5Model.duration = ms;

			return View("Question5", q5Model);

		}

    }
}
