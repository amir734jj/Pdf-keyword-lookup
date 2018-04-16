using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PdfInfo pdfInfo)
        {
            _pdfInfoDataAccessLayer.Save(pdfInfo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}