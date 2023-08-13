using System.ComponentModel.DataAnnotations;

namespace KostaTestRybakovaWebApplication.Models
{
    public class EditEmployeeViewModel
    {
        public decimal Id { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Фамилия должна содержать от 1 до 30 символов")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

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
