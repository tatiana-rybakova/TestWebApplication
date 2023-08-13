using System.ComponentModel.DataAnnotations;

namespace KostaTestRybakovaWebApplication.Models
{
    public class AddDepartmentViewModel
    {
        public Guid Id { get; set; }
        public Guid? ParentDepartmentID { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "Код должен содержать от 1 до 10 символов")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Не указано название")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Название должен содержать от 1 до 50 символов")]
        public string Name { get; set; }        
    }
}
