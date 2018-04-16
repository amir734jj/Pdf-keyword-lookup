using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccessLayer.Interfaces;
using LiteDB;
using Models;

namespace DataAccessLayer
{
    public class PdfInfoDataAccessLayer:  IPdfInfoDataAccessLayer
    {
        private readonly LiteCollection<PdfInfo> _collection;

        public PdfInfoDataAccessLayer(LiteDatabase liteDatabase)
        {
            _collection = liteDatabase.GetCollection<PdfInfo>();
        }

        public bool Save(PdfInfo pdfInfo)
        {
            return _collection.Insert(pdfInfo);
        }

        public IEnumerable<PdfInfo> Query(Expression<Func<PdfInfo, bool>> expr)
        {
            return _collection.Find(expr);
        }

        public IEnumerable<PdfInfo> GetAll()
        {
            return _collection.FindAll();
        }
    }
}