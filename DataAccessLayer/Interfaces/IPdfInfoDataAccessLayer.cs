using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;
using Models.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IPdfInfoDataAccessLayer
    {
        PdfInfo Get(int id);

        bool Save(PdfInfo pdfInfo);
        
        bool Delete(int id);

        bool Update(int id, PdfInfo pdfInfo);

        IEnumerable<PdfInfo> GetAll();
    }
}