using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;

namespace DataAccessLayer.Interfaces
{
    public interface IPdfInfoDataAccessLayer
    {
        bool Save(PdfInfo pdfInfo);

        IEnumerable<PdfInfo> Query(Expression<Func<PdfInfo, bool>> expr);

        IEnumerable<PdfInfo> GetAll();
    }
}