using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;

namespace Domainlogic.Interfaces
{
    public interface IPdfInfoParser
    {
        PdfInfo Parse(string path);
        
        bool Save(PdfInfo pdfInfo);

        IEnumerable<PdfInfo> GetAll();
    }
}