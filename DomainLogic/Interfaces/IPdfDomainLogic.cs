using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;
using Models.Models;

namespace Domainlogic.Interfaces
{
    public interface IPdfDomainLogic
    {
        bool Update(int id, PdfInfo pdfInfo);

        PdfInfo Get(int id);

        bool Save(PdfInfo pdfInfo);
        
        bool Delete(int id);

        IEnumerable<PdfInfo> GetAll();
    }
}