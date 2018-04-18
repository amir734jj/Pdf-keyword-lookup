using DataAccessLayer.Interfaces;
using Domainlogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private IPdfInfoParser _pdfInfoParser;

        public HomeController(IPdfInfoParser pdfInfoParser)
        {
            _pdfInfoParser = pdfInfoParser;
        }
        
        // GET
        public IActionResult Index()
        {
            return View(_pdfInfoParser.GetAll());
        }
    }
}