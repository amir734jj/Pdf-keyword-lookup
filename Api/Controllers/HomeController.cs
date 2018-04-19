using DataAccessLayer.Interfaces;
using Domainlogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPdfDomainLogic _pdfDomainLogic;

        public HomeController(IPdfDomainLogic pdfDomainLogic)
        {
            _pdfDomainLogic = pdfDomainLogic;
        }
        
        // GET
        public IActionResult Index()
        {
            return View(_pdfDomainLogic.GetAll());
        }
    }
}