namespace KostaTestRybakovaWebApplication.Models
{
    public class EmployeeViewModel
    {
        public decimal Id { get; set; }       
        public Guid DepartmentID { get; set; }       
        public string SurName { get; set; }       
        public string FirstName { get; set; }        
        public string? Patronymic { get; set; }        
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return (int.Parse(DateTime.Today.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.Date.ToString("yyyyMMdd"))) / 10000;
            }
        }   
        
        public string? DocSeries { get; set; }        
        public string? DocNumber { get; set; }             
        public string Position { get; set; }       
    }
}
