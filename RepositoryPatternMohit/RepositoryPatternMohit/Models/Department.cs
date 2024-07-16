using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternMohit.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }
        public string ?DName { get; set; }
    }
}
