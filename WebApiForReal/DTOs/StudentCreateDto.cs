using System.ComponentModel.DataAnnotations;

namespace WebApiForReal.DTOs
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
