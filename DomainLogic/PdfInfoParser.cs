using System;
using System.Collections.Generic;
using System.Linq;
using Domainlogic.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Models.Models;
using static Models.Constants.Delimiter;

namespace DomainLogic
{
    public class PdfInfoParser: IPdfInfoParser
    {
        
        
        public IEnumerable<PdfInfo> ParseRange(string path)
        {
            
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
                ImplicitKeywords = reader.Info["Keywords"].Split(ExplicitDelimitater).Select(x => new Keyword { Value = x}).ToHashSet(),
                ExplicitKeywords = text.Split(ExplicitDelimitater).Select(x => new Keyword { Value = x}).ToHashSet(),
                VisitedDateTime = DateTime.Now
            };
        }
    }
}