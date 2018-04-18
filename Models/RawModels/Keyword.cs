using System.ComponentModel;

namespace Models.RawModels
{
    public class RawKeyword
    {
        [DefaultValue(0)]
        public int Id { get; set; }

        public string Value { get; set; }
    }
}