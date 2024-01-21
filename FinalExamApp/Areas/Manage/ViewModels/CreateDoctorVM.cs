﻿using System.ComponentModel.DataAnnotations;

namespace FinalExamApp.Areas.Manage.ViewModels
{
    public class CreateDoctorVM
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Position { get; set; }
        public IFormFile Image { get; set; }
    }
}
