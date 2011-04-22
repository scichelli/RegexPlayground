using System;
using System.Linq;
using System.Web.Mvc;
using RegexKata.Core;
using RegexKata.Infrastructure;

namespace RegexKata.UI.Controllers
{
	public class RiddleController : Controller
	{
		private readonly IRiddleRepository _riddleRepository;

		public RiddleController()
		{
			_riddleRepository = new RiddleRepository();
		}

		public ViewResult Index()
		{
			return View();
		}

		public PartialViewResult GetRiddle()
		{
			Riddle riddle = _riddleRepository.GetRandom();
			return PartialView("_Riddle", riddle);
		}

		[HttpPost]
		public JsonResult TestRiddle(Guid id, string pattern)
		{
			Riddle selectedRiddle = _riddleRepository.GetById(id);
			RiddleResult riddleResult = selectedRiddle.Evaluate(pattern);

			return Json(new
				{
					FailedResults = riddleResult.FailedClues.Select(c => c.GetHashCode()).ToArray(),
					SucceededResults = riddleResult.SuccessfulClues.Select(c => c.GetHashCode()).ToArray()
				});
		}
	}
}