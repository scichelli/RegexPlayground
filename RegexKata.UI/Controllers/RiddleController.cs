using System.Web.Mvc;
using RegexKata.Core;
using RegexKata.Infrastructure;

namespace RegexKata.UI.Controllers
{
    public class RiddleController : Controller
    {
        private IRiddleRepository _riddleRepository;

        public RiddleController()
        {
            _riddleRepository = new RiddleRepository();
        }

        // GET: /Riddle/
        public ActionResult Index()
        {
            var riddle = _riddleRepository.GetRandom();
            return View(riddle);
        }
    }
}
