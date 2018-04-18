using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Models.Models
{
    public class PdfInfo
    {
        public int Id { get; set; }
        
        public HashSet<Keyword> ImplicitKeywords { get; set; }
        
        public HashSet<Keyword> ExplicitKeywords { get; set; }
        
        public string Path { get; set; }
        
        public DateTime VisitedDateTime { get; set; }
    }
}