using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class PdfInfoController : Controller
    {
        private readonly IPdfInfoDataAccessLayer _pdfInfoDataAccessLayer;

        public PdfInfoController(IPdfInfoDataAccessLayer pdfInfoDataAccessLayer)
        {
            _pdfInfoDataAccessLayer = pdfInfoDataAccessLayer;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<PdfInfo> Get()
        {
            return _pdfInfoDataAccessLayer.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PdfInfo Get(int id)
        {
            return _pdfInfoDataAccessLayer.Get(id);
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] PdfInfo pdfInfo)
        {
            return _pdfInfoDataAccessLayer.Save(pdfInfo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] PdfInfo pdfInfo)
        {
            return _pdfInfoDataAccessLayer.Update(id, pdfInfo);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _pdfInfoDataAccessLayer.Delete(id);
        }
    }
}