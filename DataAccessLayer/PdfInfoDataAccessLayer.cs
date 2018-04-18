using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DataAccessLayer.Interfaces;
using Models.Models;
using Models.RawModels;

namespace DataAccessLayer
{
    public class PdfInfoDataAccessLayer:  IPdfInfoDataAccessLayer
    {
        private readonly EntityDbContext _database;
        
        private readonly IMapper _mapper;

        public PdfInfoDataAccessLayer(IMapper mapper, EntityDbContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public PdfInfo Get(int id)
        {
            return _mapper.Map<PdfInfo>(_database.RawPdfInfos.Find(id));
        }

        public bool Save(PdfInfo pdfInfo)
        {
            _database.RawPdfInfos.Add(_mapper.Map<RawPdfInfo>(pdfInfo));

            _database.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var rawPdfInfo = _database.RawPdfInfos.FirstOrDefault(x => x.Id == id);

            if (rawPdfInfo == null) return false;

            _database.Remove(rawPdfInfo);

            _database.SaveChanges();

            return true;
        }

        public bool Update(int id, PdfInfo pdfInfo)
        {
            var rawPdfInfo = _database.RawPdfInfos.FirstOrDefault(x => x.Id == id);

            if (rawPdfInfo == null) return false;
            
            _database.RawPdfInfos.Update(rawPdfInfo);

            _database.SaveChanges();

            return true;
        }

        public IEnumerable<PdfInfo> GetAll()
        {
            return _mapper.Map<IEnumerable<PdfInfo>>(_database.RawPdfInfos.ToList());
        }
    }
}