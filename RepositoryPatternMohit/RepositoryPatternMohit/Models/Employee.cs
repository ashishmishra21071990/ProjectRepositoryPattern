using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternMohit.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string ?Name { get; set; }
        public int Age { get; set; }
        public string ?Address { get; set; }
        public int  Salary { get; set; }
    }
}
