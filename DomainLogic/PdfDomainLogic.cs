using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using Domainlogic.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Models;
using Models.Models;

namespace DomainLogic
{
    public class PdfDomainLogic: IPdfDomainLogic
    {
        private readonly IPdfInfoDataAccessLayer _pdfInfoDataAccessLayer;
        
        public PdfDomainLogic(IPdfInfoDataAccessLayer pdfInfoDataAccessLayer)
        {
            _pdfInfoDataAccessLayer = pdfInfoDataAccessLayer;
        }

        public bool Update(int id, PdfInfo pdfInfo)
        {
            return _pdfInfoDataAccessLayer.Update(id, pdfInfo);
        }

        public PdfInfo Get(int id)
        {
            return _pdfInfoDataAccessLayer.Get(id);
        }

        public bool Save(PdfInfo pdfInfo)
        {
            return _pdfInfoDataAccessLayer.Save(pdfInfo);
        }

        public bool Delete(int id)
        {
            return _pdfInfoDataAccessLayer.Delete(id);
        }

        public IEnumerable<PdfInfo> GetAll()
        {
            return _pdfInfoDataAccessLayer.GetAll();
        }
    }
}