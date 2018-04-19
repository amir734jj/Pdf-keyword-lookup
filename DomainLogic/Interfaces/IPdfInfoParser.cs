using Models.Models;

namespace Domainlogic.Interfaces
{
    public interface IPdfInfoParser
    {
        PdfInfo Parse(string path);
    }
}