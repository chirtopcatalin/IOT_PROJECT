using System.ComponentModel.DataAnnotations.Schema;

namespace garbage_collection.Models
{
    [Table("citizen")]
    public class CitizenModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string CNP { get; set; }
    }
}