namespace FinalExamApp.Areas.Manage.ViewModels
{
    public class UpdateDoctorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgUrl { get; set; }
    }
}
