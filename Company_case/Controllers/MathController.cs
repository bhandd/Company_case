using Company_case.Core.Domain;
using Company_case.Core.Interface;
using Company_case.Models.Math;
using Microsoft.AspNetCore.Mvc;

namespace Company_case.Controllers
{
    public class MathController : Controller
    {
        private readonly IMathService _mathService;

        public MathController(IMathService mathService)
        {
            _mathService = mathService; 
        }
        // GET: MathController
        public ActionResult Index()
        {
            return View();
        }


        public IActionResult Fibonacchi()
        {
            return View(new FibonacchiVm());
        }
        
        [HttpPost]
        public IActionResult Fibonacchi(FibonacchiVm model)
        {
            if (model.Input > 0)
            {
                bool result = _mathService.IsItFibonacchi(model.Input);
                model.IsFibonacchi = result;
                model.Message = result ?  "Ja, det är ett fibonacchi-tal" : "Nej, det är inte ett fibonacchi-tal";
            }
            return View(model);
        }

        public IActionResult Easter()
        {
            EasterTrend trend = _mathService.EasterStatistics();
            EasterTrendVm easterTrend = EasterTrendVm.FromEasterTrend(trend);
            return View(easterTrend);
        }
        
    }
}
