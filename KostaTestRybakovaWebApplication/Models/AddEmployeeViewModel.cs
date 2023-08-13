using System.ComponentModel.DataAnnotations;

namespace KostaTestRybakovaWebApplication.Models
{
    public class AddEmployeeViewModel
    {
        //public decimal ID { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Фамилия должна содержать от 1 до 50 символов")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Имя должно содержать от 1 до 50 символов")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Отчество должно содержать от 1 до 50 символов")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime DateOfBirth { get; set; }
        public string? DocSeries { get; set; }
        public string? DocNumber { get; set; }

        [Required(ErrorMessage = "Не указана должность")]
        public string Position { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
