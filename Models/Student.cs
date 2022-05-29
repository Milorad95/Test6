using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test6.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID je obavezan")]
        public int StudentID { get; set; }

        [DisplayName("Ime")]
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; } = string.Empty;

        [DisplayName("Prezime")]
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; } = string.Empty;

        [DisplayName("Broj indeksa")]
        [Required(ErrorMessage = "Broj indeksa je obavezan")]
        public string BrojIndeksa { get; set; } = string.Empty;

        [DisplayName("Naziv smera")]
        [Required(ErrorMessage = "Naziv je obavezan")]
        public Smer Smer { get; set; } = new Smer();

        [DisplayName("Aktivan")]
        public bool Aktivan { get; set; }
    }
}
