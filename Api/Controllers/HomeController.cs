using DataAccessLayer.Interfaces;
using Domainlogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;
using Models.ViewModels;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPdfInfoParser _pdfInfoParser;
        
        private readonly IPdfDomainLogic _pdfDomainLogic;

        public HomeController(IPdfInfoParser pdfInfoParser, IPdfDomainLogic pdfDomainLogic)
        {
            _pdfInfoParser = pdfInfoParser;
            _pdfDomainLogic = pdfDomainLogic;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_pdfDomainLogic.GetAll());
        }
        
        [HttpPost]
        public IActionResult Parse(PathInput path)
        {
            // start the parse
            _pdfInfoParser.Parse(path?.Path ?? @"/Users/HES8493/Downloads/SeyedamirhosseinHesamian-ShortResume.pdf");
            
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult ParseRange(PathInput path)
        {
            // start the parse
            _pdfInfoParser.Parse(path.Path);
            
            return RedirectToAction("Index");
        }
    }
}