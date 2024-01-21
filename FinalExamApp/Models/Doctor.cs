using FinalExamApp.Models.Common;

namespace FinalExamApp.Models
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string ImgUrl { get; set; }
    }
}
