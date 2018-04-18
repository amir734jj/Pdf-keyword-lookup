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
    public class PdfInfoParser: IPdfInfoParser
    {
        private readonly IPdfInfoDataAccessLayer _pdfInfoDataAccessLayer;
        
        private const string ImplicitDelimitater = ";";
        
        private const string ExplicitDelimitater = " ";

        public PdfInfoParser(IPdfInfoDataAccessLayer pdfInfoDataAccessLayer)
        {
            _pdfInfoDataAccessLayer = pdfInfoDataAccessLayer;
        }

        public PdfInfo Parse(string path)
        {
            var reader = new PdfReader(path);
            var text = string.Empty;
            
            for (var page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }

            reader.Close();

            return new PdfInfo
            {
                Path = path,
                ImplicitKeywords = reader.Info["Keywords"].Split(ImplicitDelimitater).Select(x => new Keyword { Value = x}).ToHashSet(),
                ExplicitKeywords = text.Split(ExplicitDelimitater).Select(x => new Keyword { Value = x}).ToHashSet(),
                VisitedDateTime = DateTime.Now
            };
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