﻿using System;
using System.Linq;
using System.Web.Mvc;
using RegexPlayground.Core;
using RegexPlayground.Infrastructure;

namespace RegexPlayground.UI.Controllers
{
	public class RiddleController : Controller
	{
		private readonly IRiddleRepository _riddleRepository;

		public RiddleController() : this(new RiddleRepository()) {}

		public RiddleController(IRiddleRepository repository)
		{
			_riddleRepository = repository;
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