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
        public PdfInfoParser()
        {
            
        }
        
        public IEnumerable<PdfInfo> ParseRange(string path)
        {
            return DigestPath(path).Select(Parse);
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

        /// <summary>
        /// Digest a path and returns all PDF files given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static IEnumerable<string> DigestPath(string path) => System.IO.Directory.GetFiles(path, "*.pdf");
    }
}