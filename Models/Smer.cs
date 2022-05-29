using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test6.Models
{
    public class Smer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID je obavezan")]
        public int SmerID { get; set; }

        [DisplayName("Naziv smera")]
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string NazivSmera { get; set; } = string.Empty;
        [DisplayName("Aktivan")]
        public bool Aktivan { get; set; }

        public IEnumerable<Student> Studenti { get; set; }
    }
}
