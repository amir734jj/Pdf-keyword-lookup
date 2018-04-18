using System;
using System.Collections.Generic;
using System.ComponentModel;
using Models.Models;

namespace Models.RawModels
{
    public class RawPdfInfo
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        
        public ICollection<RawKeyword> ImplicitKeywords { get; set; }
        
        public ICollection<RawKeyword> ExplicitKeywords { get; set; }
        
        public string Path { get; set; }
        
        public DateTime VisitedDateTime { get; set; }
    }
}