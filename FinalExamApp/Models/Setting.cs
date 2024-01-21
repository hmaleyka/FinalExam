using FinalExamApp.Models.Common;

namespace FinalExamApp.Models
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
