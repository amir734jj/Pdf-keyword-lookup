using System;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class PdfInfo
    {
        public HashSet<string> ImplicitKeywords { get; set; }
        
        public HashSet<string> ExplicitKeywords { get; set; }
        
        public string Path { get; set; }
        
        public DateTime VisitedDateTime { get; set; }
    }
}